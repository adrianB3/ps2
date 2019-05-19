import Vue from 'vue'
import Router from 'vue-router'
import Monitor from "./views/Monitor";
import Log from "./views/Log";

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'monitor',
      component: Monitor
    },
    {
      path: '/log',
      name: 'log',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component:  Log//() => import(/* webpackChunkName: "log" */ './views/Log.vue')
    }
  ]
})
