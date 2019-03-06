import Router from '../router';

import axios from 'axios'


export default {
    state: {
        currentUser: {}
    },
    getters: {
        currentUser: state => state.currentUser
    },
    mutations: {
        set(state, user) {
            state.currentUser = user;
        }
    },
    actions: {
        refreshCurrentUser({ commit }) {
                axios({ url: ('/api/user/' + this.getters.jwtUserId), method: 'GET' })
                    .then(response => {
                        commit('set', response.data);
                    }).catch(err => {
                        console.log(err);
                    })
        },
    }
}