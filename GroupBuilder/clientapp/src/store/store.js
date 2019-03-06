import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)


import AccountStore from './accountstore';
import UserStore from './userstore';

export default new Vuex.Store({
    mutations: {

    },
    actions: {

    },
    modules: {
        account: AccountStore,
        user: UserStore
    }
})
