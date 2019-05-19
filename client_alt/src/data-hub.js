import {HubConnectionBuilder, LogLevel} from '@aspnet/signalr'

export default{
    install(Vue) {
        const connection = new HubConnectionBuilder()
            .withUrl(`${Vue.prototype.$http.defaults.baseURL}/data-hub`)
            .configureLogging(LogLevel.Information)
            .build()

        const dataHub = new Vue()

        connection.on('StateChange', (id, timeStamp, pump1State, pump2State, pump3State, pump4State,
                                      waterLevelSensor1State, waterLevelSensor2State, waterLevelSensor3State, waterLevelSensor4State) => {
            dataHub.$emit('state-changed', {id, timeStamp, pump1State, pump2State, pump3State, pump4State,
                waterLevelSensor1State, waterLevelSensor2State, waterLevelSensor3State, waterLevelSensor4State})
        })

        Vue.prototype.$dataHub = dataHub

        let startedPromise = null
        function start () {
            startedPromise = connection.start().catch(err => {
                console.error('Failed to connect with hub', err)
                return new Promise((resolve, reject) =>
                    setTimeout(() => start().then(resolve).catch(reject), 5000))
            })
            return startedPromise
        }
        connection.onclose(() => start())

        start()
    }
}