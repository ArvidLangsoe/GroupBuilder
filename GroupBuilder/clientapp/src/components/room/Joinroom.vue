<template>
    <div class="join-room">
        <h1><b>Join Room</b></h1>
        <form>
            <div class="form-group">
                <input id="room-code" v-model="roomCode" class="form-control" type="text" placeholder="Enter Roomcode" aria-describedby="roomCodeHelp">
                <small id="roomCodeHelp" class="form-text ">All members of a room can see the room code.</small>
            </div>

            <div>
                <button v-on:click="joinRoom" type="submit" class="btn btn-primary join-btn">Join</button>
            </div>
        </form>

    </div>


</template>


<script>
    export default {
        data: function () {
            return {
                roomCode: ""
            }
        },
        methods: {

            joinRoom: function () {
                this.$store.dispatch('addCurrentUserToRoom', this.roomCode);
            }
        }
    }

</script>


<style scoped>

    .join-room {
        margin: 20px;
        padding: 20px;
        min-width: 400px;
        border-radius: 25px;
        background: var(--secondary-light-blue);
        color: #000000;
    }

    .join-btn {
        background: var(--main-dark-blue);
        font-size: larger;
    }

    #room-code {
        color: #000000;
        font-size: x-large;
        text-transform: uppercase;
    }
    #room-code::placeholder { /* Placeholders for Browsers */
        text-transform: none;
    }
    :-ms-input-placeholder { /* Placeholders for Internet Explorer 10+ */
        text-transform: none;
    }
</style>