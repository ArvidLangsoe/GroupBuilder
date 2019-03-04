<template>
    <div id="app" >
        <div class="nav">
            <div>
                <router-link to="/">Home</router-link>
                <router-link to="/about">About</router-link>

                <router-link to="/about">About</router-link>
                <router-link to="/about">About</router-link>
            </div>
            <div>
                <span v-if="isLoggedIn"> <a id="logout-btn" @click="logout">Logout</a></span>
            </div>
        </div>
        <div id="content">
            <LoginWindow />
            <router-view />
        </div>
    </div>
</template>


<script>
    import LoginWindow from './components/account/LoginWindow.vue'

    export default {
        created: function () {
            this.$http.interceptors.response.use(undefined, function (err) {
                return new Promise(function (resolve, reject) {
                    if (err.status === 401 && err.config && !err.config.__isRetryRequest) {
                        this.$store.dispatch(logout)
                    }
                    throw err;
                });
            });
        },
        components: {
            LoginWindow,

        },
        computed: {
            isLoggedIn: function () { return this.$store.getters.isLoggedIn }
        },
        methods: {
            logout: function () {
                this.$store.dispatch('logout')
                    .then(() => {
                        this.$router.push('/')
                    })
            }
        }
    }

</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
    }

    .nav {
        background-color: #333;
        overflow: hidden;
        display: flex;
        justify-content: space-between;
    }

        .nav a {
            float: left;
            color: #f2f2f2;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
            font-size: 17px;
        }

            .nav a.router-link-exact-active {
                background-color: #4CAF50;
                color: white;
            }

            .nav a.router-link-active:hover,
            .nav a.router-link-active:focus {
                background-color: #4CAF50;
                color: white;
            }

    #logout-btn {
        float: left;
        color: #f2f2f2;
        text-align: center;
        padding: 14px 16px;
        text-decoration: none;
        font-size: 17px;
    }


        #logout-btn:hover,
        #logout-btn:focus {
            background-color: #4CAF50;
            color: white;
            cursor: pointer;
        }
        

</style>
