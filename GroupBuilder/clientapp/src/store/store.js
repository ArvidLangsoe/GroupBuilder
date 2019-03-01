import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)


import AccountStore from './accountstore';

export default new Vuex.Store({
    state: {
        status: '',
        token: localStorage.getItem('token') || '',
        user : {}
    },
    mutations: {

    },
    actions: {

    },
    modules: {
        account: AccountStore,
    }
})
