<template>
  <div class="container">
    <Data   :key="dt.id"
            :dt="dt"/>
  </div>
</template>

<script>
// @ is an alias to /src
import Data from '@/components/Data'
export default {
  name: 'monitor',
  components: {
    Data
  },
  data (){
    return {
      dt: {
        id: '',
        timeStamp: '',
        pump1State: '',
        pump2State: '',
        pump3State: '',
        pump4State: '',
        waterLevelSensor1State: '',
        waterLevelSensor2State: '',
        waterLevelSensor3State: '',
        waterLevelSensor4State: ''
      }
    }
  },
  created() {
    this.$dataHub.$on('state-changed', this.onStateChanged)
  },
  beforeDestroy() {
    this.$dataHub.$off('state-changed', this.onStateChanged)
  },
  methods: {
    onStateChanged({id, timeStamp, pump1State, pump2State, pump3State, pump4State,
                     waterLevelSensor1State, waterLevelSensor2State, waterLevelSensor3State, waterLevelSensor4State}){
      Object.assign(this.dt, {id, timeStamp, pump1State, pump2State, pump3State, pump4State,
        waterLevelSensor1State, waterLevelSensor2State, waterLevelSensor3State, waterLevelSensor4State})
    }
  }
}
</script>
