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
        setUser(state, user) {
            state.currentUser = user;
        }
    },
    actions: {
        refreshCurrentUser({ commit }) {
                axios({ url: ('/api/user/' + this.getters.jwtUserId), method: 'GET' })
                    .then(response => {
                        commit('setUser', response.data);
                    }).catch(err => {
                        console.log(err);
                    })
        },
        addCurrentUserToRoom({ commit }, roomCode) {
            axios({ url: ('/api/room/participants?roomCode='+ roomCode), method: 'Post', data: { "id": this.getters.jwtUserId} })
                .then(response => {
                    Router.push('/room/' + response.data.id)
                }).catch(err => {
                    console.log(err);
                })
        }
    }
}