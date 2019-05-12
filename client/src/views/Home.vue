<template>
  <div class="home">
    <monitor></monitor>
  </div>
</template>

<script>
// @ is an alias to /src
import monitor from '@/components/monitor.vue'

export default {
  name: 'home',
  components: {
    monitor
  }
}
</script>
