<template>

    <div class="room-grid">
        <div class="room-details background-box">
            Details of room. this is some details that are important.

        </div>

        <div class="room-members background-box">
            <h3>Members</h3> 
            <div class="scrollable-members">
                <ul v-for="participant in roomMembers" class="list-group list-group-flush">
                    <li class="list-group-item">{{participant.user.email}}</li>
                </ul>
            </div>

        </div>

        <div class="group-overview">
            <h4>Groups: </h4>
            <div class="group-container scrollable-groups">

                <div v-for="groupItem in myRoomGroups" class="group-container">
                    <div class="group my-group background-box">
                        <h5> Group Id: {{groupItem.id}}</h5>
                        
                    </div>
                </div>
                <div v-for="groupItem in roomGroups">
                    <div class="group background-box">
                        <h5> Group Id: {{groupItem.id}}</h5>
                        
                    </div>
                </div>

            </div>

        </div>

        <div class="admin-panel">
            <h4>Admin</h4>

        </div>

    </div>


</template>

<script>

    export default {
        watch: {
            //Needs to be update to switch to the correct room.
            '$route'(to, from) {
                console.log("route changed from: ");
                console.log(from);
                console.log("route changed to: ");
                console.log(to);
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
            roomGroups: function() {
                var allGroups = this.$store.getters.currentRoom.groups;

                return allGroups.filter(x => !this.myRoomGroups.includes(x));
            },
            roomMembers: function () {
                return this.$store.getters.currentRoom.participants;
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
        align-content: stretch;
        flex-wrap: wrap;
    }

    .my-group {
        background-color: var(--secondary-light-blue)
    }

    .group {
        min-width: 200px;
        border: solid 2px;
        border-color: var(--secondary-light-blue);
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