<template>
    <div class="home">

        <div class="home-join">

            <JoinRoom />
        </div>
        <div class="home-info">
            <div class="my-rooms">
                <MyRooms />
            </div>
            <div class="my-groups">
                <MyGroups />
            </div>

        </div>
    </div>
</template>

<script>
    import JoinRoom from '../components/room/Joinroom.vue';
    import MyRooms from '../components/room/MyRooms.vue';
    import MyGroups from '../components/room/MyGroups.vue';

    export default {
        name: 'home',
        components: {
            JoinRoom,
            MyRooms,
            MyGroups
        },
        created() {
            this.$store.dispatch('refreshCurrentUser');
        }
    }
</script>

<style scoped>
    .home {
        display: flex;
        flex-direction: column;
    }

    .home-join {
        margin-bottom: 30px;
        display: flex;
        flex-direction: row;
        justify-content: center;
        background: var(--main-dark-blue);
        box-shadow: 0px 10px 5px 5px var(--main-dark-blue);
    }

    .home-info {
        display: flex;
        justify-content: space-around;
        flex-wrap: wrap;
    }
    .my-rooms {
        min-width: 50%
        
    }
    .my-groups {
        min-width: 50%
    }


</style>
