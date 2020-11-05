import Vue from 'vue'
import App from './App.vue'
import Router from 'vue-router'
import VueAxios from 'vue-axios'
import VueContentPlaceholders from 'vue-content-placeholders'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(VueContentPlaceholders)
Vue.use(VueAxios)
Vue.use(Router);

Vue.config.productionTip = false

const router = new Router({
	routes: [
		{ path: "/list", component: () => import(/*webpackChunkName: "viewuser"*/ "./components/ListView.vue") },
		{ path: "/view/:id", name: "Details", component: () => import(/*webpackChunkName: "detailspage"*/"./components/View.vue") },
		{ path: "/", component: () => import(/* webpackChunkName: "homepage" */ "./components/Home.vue"), name:"/home" }

	],
	mode: "history"
})

new Vue({
	el: "#app",
	render: h => h(App),
	router
})