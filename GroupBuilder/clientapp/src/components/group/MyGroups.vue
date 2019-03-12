<template>
    <div class="background-box background-box-standard">
        <h5>My Groups</h5>
        <hr />


        <div v-if="hasError">
            <div class="error">
                <p>{{errorMessage}}</p>
            </div>
        </div>
        <div v-else>
            <ol v-for="group in userGroups" v-on:click="openRoom(group.group.roomId)" :key="group.group.id" class="list-group list-group-flush">
                <li class="list-group-item list-group-item-action ">
                    <div class="group-container">
                        <div class="group-left">
                            <div style="font-weight:bold;" title="Group Id">{{group.group.id}}</div>
                            <div class="small text-muted" title="Room ID">({{group.group.roomId}})</div>
                        </div>
                        <div class="group-right">
                            <div class="data-count">
                                <div class="count"  title="Number of members">
                                    {{group.group.numberOfMembers}}
                                    <v-icon name="user"></v-icon>
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
                    this.errorMessage = "You have to login to see your groups."
                    return true;
                }


                if (!this.userGroups || this.userGroups.length <= 0) {
                    this.errorMessage = "There are no groups to show."
                    return true;
                }


                this.errorMessage = "";
                return false;

            },
            userGroups: function () {
                let groups = this.$store.getters.currentUser.groups;
                return groups;

            }

        },
        methods: {
            openRoom: function (roomId) {
                this.$router.push('/room/' + roomId)
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

    .group-container {
        display: flex;
        justify-content: space-between;
    }

    .group-left {
        display: flex;
        flex-direction: column;
        justify-content: flex-start;
        align-items: flex-start;
    }

    .group-right {
        display: flex;
        flex-direction: column;
        align-items: flex-end;
    }

    .count {
        margin-left: 15px;
    }
</style>