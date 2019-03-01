import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)


import AccountStore from './accountstore';

export default new Vuex.Store({
    state: {

    },
    mutations: {

    },
    actions: {

    },
    modules: {
        account: AccountStore,
    }
})
