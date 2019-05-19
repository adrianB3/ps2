<template>
    <li class="card container">
        <div class="card-header">State change: {{ dt.id }} @ {{dt.timeStamp}}</div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-6">
                    <ol class="list-group">
                        <li class="list-group-item"> Pump 1 state: {{dt.pump1State}}</li>
                        <li class="list-group-item"> Pump 2 state: {{dt.pump2State}}</li>
                        <li class="list-group-item"> Pump 3 state: {{dt.pump3State}}</li>
                        <li class="list-group-item"> Pump 4 state: {{dt.pump4State}}</li>
                    </ol>
                </div>
                <div class="col-md-6">
                    <ol class="list-group">
                        <li class="list-group-item"> Water sen 1 state: {{dt.waterLevelSensor1State}}</li>
                        <li class="list-group-item"> Water sen 2 state: {{dt.waterLevelSensor2State}}</li>
                        <li class="list-group-item"> Water sen 3 state: {{dt.waterLevelSensor3State}}</li>
                        <li class="list-group-item"> Water sen 4 state: {{dt.waterLevelSensor4State}}</li>
                    </ol>
                </div>
            </div>

        </div>
    </li>
</template>

<script>
    export default {
        name: "Data",
        props: {
            dt: {
                type: Object,
                required: true
            }
        }
    }
</script>

<style scoped>

</style>