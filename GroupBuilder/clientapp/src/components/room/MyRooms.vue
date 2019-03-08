<template>
    <div class="background-box background-box-standard">
        <h5>My Rooms</h5>
        <hr />


        <div v-if="hasError">
            <div class="error">
                <p>{{errorMessage}}</p>
            </div>
        </div>
        <div v-else>
            <ol v-for="room in userRooms" v-on:click="openRoom(room)" :key="room.room.id" class="list-group list-group-flush">
                <li class="list-group-item list-group-item-action ">
                    <div class="room-container">
                        <div class="room-left">
                            <div style="font-weight:bold;">{{room.room.name}}</div>
                            <div class="small text-muted">({{room.room.id}})</div>
                        </div>
                        <div class="room-right">
                            <div>
                                Code: <span class="code">{{room.room.roomCode}}</span>
                            </div>
                            <div class="data-count">
                                <div class="count">
                                    {{room.room.numberOfParticipants}}
                                    <v-icon name="user"></v-icon>

                                </div>
                                <div class="count">
                                    {{room.room.numberOfGroups}}
                                    <v-icon name="users"></v-icon>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
            </ol>

        </div>

    </div>

</template>


<script>

    export default {
        data: function () {
            return {
                errorMessage: "loading"
            }
        },
        computed: {
            hasError: function () {
                if (!this.$store.getters.isLoggedIn) {
                    this.errorMessage = "You have to login to see your rooms."
                    return true;
                }
                if (!this.userRooms || this.userRooms.length <= 0) {
                    this.errorMessage = "There are no rooms to show."
                    return true;
                }

                this.errorMessage = "";
                return false;
            },
            userRooms: function () {
                let rooms = this.$store.getters.currentUser.rooms;
                return rooms;

            }
        },
        methods: {
            openRoom: function (room) {
                this.$router.push('/room/'+room.room.id)
            }
        }
    }


</script>

<style scoped>

    hr {
        display: block;
        height: 1px;
        border: 0;
        border-top: 1px solid #ccc;
        margin: 1em 0;
        padding: 0;
    }

    .error {
        text-align: center;
        font-size: larger;
        color: #333;
    }

    .room-container {
       display: flex;
       justify-content: space-between;
    }

    .data-count {
        display: flex;
        flex-direction: row;
        justify-content: flex-end;
    }
    .room-left {
        display: flex;
        flex-direction: column;
        justify-content: flex-start;
        align-items: flex-start;
    }

    .room-right {
        display:flex;
        flex-direction:column;
        align-items: flex-end;

    }

    .code {
        font-weight:bold;
    }

    .count {
        margin-left: 15px;
    }


</style>