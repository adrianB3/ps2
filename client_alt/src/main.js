import Vue from 'vue'
import App from './App.vue'
import router from './router'

import axios from 'axios'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import '@fortawesome/fontawesome-free/css/all.css'
import dataHub from '@/data-hub.js'

Vue.config.productionTip = false

axios.defaults.baseURL = 'https://localhost:5001/api' // same as the Url the server listens to
Vue.prototype.$http = axios

// Install Vue extensions
Vue.use(BootstrapVue)
Vue.use(dataHub)

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
