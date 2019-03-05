<template>
    <div class="background-box">
        <h5>My Rooms</h5>
        <hr />


        <div v-if="hasError">
            <div class="error">
                <p>{{errorMessage}}</p>
            </div>
        </div>
        <div v-else>
            <ol v-for="room in userRooms" :key="room.room.id" class="list-group list-group-flush">
                <li class="list-group-item list-group-item-action ">
                    <div class="room-container">
                        <div>
                            <h5>Room Id:</h5>
                            {{room.room.id}}
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

    .list-group-item-action:hover {
        background: var(--secondary-light-blue)
    }


    .list-group-item {
        background: var(--primary-box-background);
        cursor: pointer;
    }

    .room-container {
        display: flex;
    }
</style>