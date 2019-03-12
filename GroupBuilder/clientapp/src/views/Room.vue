<template>

    <div class="room-grid">
        <div class="room-details background-box">
            <p>
                Room id:
                {{currentRoom.id}}
            </p>
            <p>
                Code:
                {{currentRoom.roomCode}}
            </p>
        </div>

        <div class="room-members background-box">
            <h3>Members</h3> 
            <div class="scrollable-members">
                <draggable v-model="roomMembers" :group="{name:'users', pull: 'clone'}" @start="drag=true" @end="drag=false" :sort="false">
                    <ul v-for="participant in roomMembers" class="list-group list-group-flush">
                        <li class="list-group-item">{{participant.user.email}}</li>
                    </ul>
                </draggable>
            </div>

        </div>

        <div class="group-overview">
            <h4>Groups: </h4>
            <div class="scrollable-groups group-container">

                <div v-for="groupItem in myRoomGroups" class="group-item">
                        <roomgroup v-bind:group="groupItem" v-bind:isMyGroup="true" />
                </div>
                <div v-for="groupItem in roomGroups" class="group-item">
                        <roomgroup v-bind:group="groupItem" v-bind:isMyGroup="false" />
                </div>

            </div>

        </div>

        <div class="admin-panel">
            <h4>Admin</h4>

        </div>

    </div>


</template>

<script>

    import draggable from 'vuedraggable'
    import roomgroup from '../components/group/RoomGroup.vue'


    export default {
        components: {
            draggable,
            roomgroup
        },
        watch: {
            '$route'(to, from) {
                this.$store.dispatch('refreshCurrentRoom', this.$route.params.id);
            }
        },
        created() {
            this.$store.dispatch('refreshCurrentUser', this.$route.params.id);
            this.$store.dispatch('refreshCurrentRoom', this.$route.params.id);
        },
        computed: {
            currentRoom: function () {
                return this.$store.getters.currentRoom;
            },
            myRoomGroups: function () {
                var allGroups = this.$store.getters.currentRoom.groups;
                var currentUserGroups = this.$store.getters.currentUser.groups;
                var currentUserGroupIds = currentUserGroups.map(y => y.group.id);
                return allGroups.filter(x => currentUserGroupIds.includes(x.id));
            },
            roomGroups: function () {
                
                var allGroups = this.$store.getters.currentRoom.groups;

                return allGroups.filter(x => !this.myRoomGroups.includes(x));
            },
            roomMembers: {
                get: function(){
                    return this.$store.getters.currentRoom.participants;
                },
                set: function (value) {
                    //ignore any values set. 
                    //They are of no interest since the members list should be static.
                }
            }
        },
        methods: {
            groupMembers: function (group) {
                return group.members;
            }
        }
    }

</script>

<style scoped>

    .room-grid {
        text-align: left;
        display: grid;
        grid-template-columns: 300px auto 200px;
        grid-template-rows: 100px auto;
        grid-template-areas: "members header admin" "members groups admin";
    }

    .room-details {
        grid-area: header;
    }

    .room-members {
        grid-area: members;
    }

    .group-overview {
        grid-area: groups;
    }

    .admin-panel {
        grid-area: admin;
        border-left: solid 2px var(--main-dark-blue);
        border-bottom: solid 2px var(--main-dark-blue);
        background-color: var(--primary-box-background);
        margin-top: 3px;
        padding: 4px;
        position: fixed;
        right: 0px;
        width: 200px;
        height: 100%;
    }

    /*Mobile changes*/
    @media only screen and (max-width: 1000px) {
        .room-grid {
            text-align: left;
            display: grid;
            grid-template-columns: 200px auto;
            grid-template-rows: 100px auto;
            grid-template-areas: "members header" "members groups";
        }
        .admin-panel {
            visibility: hidden;
        }
    }


    .group-container {
        display: flex;
        justify-content: flex-start;
        align-items: stretch;
        flex-wrap: wrap;
    }

    .group-item {
        flex-grow: 1;
        max-width: 30%;
        min-width: 200px;
    }

    .scrollable-members {
        overflow-y: auto;
        min-height: 100px;
        max-height: calc(100vh - 135px);
    }

    .scrollable-groups {
        overflow-y: auto;
        min-height: 100px;
        max-height: calc(100vh - 215px);
    }
</style>