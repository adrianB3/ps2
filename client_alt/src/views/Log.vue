<template>
  <ul class="container list-group mt-4">
    <Data
            v-for="dt in fetched_data.reverse()"
            :key="dt.id"
            :dt="dt"
            class="list-group-item list-group-item-action mb-3"
    />
  </ul>
</template>


<script>
  // @ is an alias to /src
  import Data from '@/components/Data'
  export default {
    name: 'log',
    components: {
      Data
    },
    data (){
      return{
        fetched_data: []
      }
    },
    created() {
      this.$http.get('/data').then(res => {
        this.fetched_data = res.data
      })
    }
  }
</script>

<style scoped>
.container .list-group{
  height: 100vh;
  overflow: auto;
}
</style>