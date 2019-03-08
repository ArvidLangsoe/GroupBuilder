import axios from 'axios'

export default {

    state: {
        currentRoom: {}
    },
    getters: {
        currentRoom: state => state.currentRoom
    },
    mutations: {
        setRoom(state, room) {
            state.currentRoom = room;
        }
    },
    actions: {
        refreshCurrentRoom({ commit }, roomId) {
            axios({ url: ('/api/room/' + roomId), method: 'GET' })
                .then(response => {
                    commit('setRoom', response.data);
                }).catch(err => {
                    console.log(err);
                })
        },
    }
}