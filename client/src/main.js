import Vue from 'vue'
import App from './App.vue'
import router from './router'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import '@fortawesome/fontawesome-free/css/all.css'
import Axios from 'axios'
import DataHub from '@/js/data-hub.js'

Vue.config.productionTip = false
Vue.prototype.$http = Axios

Vue.use(BootstrapVue)
Vue.use(DataHub)

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
