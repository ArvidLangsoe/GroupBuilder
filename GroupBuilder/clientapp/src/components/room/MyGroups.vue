<template>
    <div class="background-box">
        <h5>My Groups</h5>
        <hr />


        <div v-if="hasError">
            <div class="error">
                <p>{{errorMessage}}</p>
            </div>
        </div>
        <div v-else>
            <ol v-for="group in userGroups" :key="group.group.id" class="list-group list-group-flush">
                <li class="list-group-item list-group-item-action ">
                    <div class="group-container">
                        <div>
                            <h5>Room:</h5>
                            {{group.group.roomId}}
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
                errorMessage: ""
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


                this.erroMessage = "";
                return false;

            },
            userGroups: function () {
                let groups = this.$store.getters.currentUser.groups;
                return groups;

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

    .group-container {
        display: flex;

    }
</style>