
<template>
  <div class="main">
    <div class="d-flex justify-content-center" id="p5Canvas"></div>
    <div class="message d-flex justify-content-center">
      {{message}}
    </div>
    <div class="message d-flex justify-content-right">
      {{hellomessage}}
    </div>
  </div>
</template>

<script>

var monitor = require('@/js/monitor.js')

export default {
  name: 'monitor',
  props: {
    msg: String
  },
  created() {
    this.$dataHub.$on('data-changed', this.onDataChange)
    this.hellomessage = 'Hello me'
  },
  beforeDestroy() {
    this.$dataHub.$off('data-changed', this.onDataChange)
  },
  data() {
      return {
          message: "", 
          hellomessage: ""
      }
  },
  mounted(){
      const P5 = require('p5')
      new P5(monitor.main)

      monitor.setDelegate(this.callbackOnP5)
  },
  methods: {
      onDataChange({message}){
        this.hellomessage = message
      },
      callbackOnP5: function(timeStr){
          this.message = timeStr;
      }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
