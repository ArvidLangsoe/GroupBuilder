import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store/store'
import Axios from 'axios'
import feather from 'vue-icon'
import VeeValidate from 'vee-validate'
import draggable from 'vuedraggable'

import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'


Vue.config.productionTip = false
Vue.prototype.$http = Axios;
const token = localStorage.getItem('token')
if (token) {
    Vue.prototype.$http.defaults.headers.common['Authorization'] = 'Bearer ' +token
}
Vue.use(VeeValidate);
Vue.use(feather, 'v-icon');
Vue.use(draggable);

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app')

