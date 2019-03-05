<template>
    <div class="background-box">
        <h5>My Groups</h5>
        <hr />


        <div v-if="hasError" >
            <div class="error">
                <p>{{errorMessage}}</p>
            </div>
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
                    this.errorMessage= "You have to login to see your groups."
                    return true;
                }
                this.errorMessage = "There are no groups to show."
                return true;
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
</style>