import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)


import AccountStore from './accountstore';
import UserStore from './userstore';
import RoomStore from './roomstore';

export default new Vuex.Store({
    mutations: {

    },
    actions: {

    },
    modules: {
        account: AccountStore,
        user: UserStore,
        room: RoomStore
    }
})
