import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import CreateForm from '../views/CreateForm.vue'
import Update from '../views/Update.vue'

Vue.use(Router)

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/create',
      name: 'new-form',
      component: CreateForm,
    },
    {
      path: '/update',
      name: 'update',
      component: Update,
    },
  ]
})

export default router;
