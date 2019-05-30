<template>
  <div class="container">
    <div class="d-flex justify-content-center" id="p5Canvas"></div>
    <Data   :key="dt.id"
            :dt="dt"/>
      <div class="message d-flex justify-content-center">
          {{message}}
      </div>
  </div>
</template>

<script>

let monitor = require('@/monitor.js');
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
      },
        message: ""
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
        monitor.getData(
            this.dt.pump1State, this.dt.pump2State, this.dt.pump3State, this.dt.pump4State,
            this.dt.waterLevelSensor1State, this.dt.waterLevelSensor2State,this.dt.waterLevelSensor3State, this.dt.waterLevelSensor4State
        )
    },
      callbackOnP5: function(timeStr){
          this.message = timeStr;

      }
  },
    mounted() {
      const P5 = require('p5')
        new P5(monitor.main)

        monitor.setDelegate(this.callbackOnP5)
    }
}
</script>
