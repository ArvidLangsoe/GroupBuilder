<template>
    <div id="app" >
        <div class="nav">
            <div>
                <router-link to="/">Home</router-link>
                <router-link to="/about">About</router-link>

            </div>
            <div>
                <span v-if="!isLoggedIn"> <a id="nav-btn-pull-right" class="nav-btn-important" @click="login">Login</a></span>
                <span v-if="isLoggedIn"> <a id="nav-btn-pull-right" @click="logout">Logout</a></span>
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
    import { EventBus } from './event-bus.js';

    export default {
        created: function () {
            this.$http.interceptors.response.use(undefined, function (err) {
                return new Promise(function (resolve, reject) {
                    if (err.status === 401 && err.config && !err.config.__isRetryRequest) {
                        this.$store.dispatch('logout')
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
            },
            login: function () {
                EventBus.$emit('show-login');
            }
        }
    }

</script>

<style>
    :root {
        --main-dark-blue: #00245e;
        --secondary-dark-blue: #0c1421;
        --primary-light-blue: #2164d1;
        --secondary-light-blue: #a5c7ff;
        --primary-box-background: #f2f5ff;
    }

    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #000000;

    }


    .nav {
        background-color: var(--secondary-dark-blue);
        overflow: hidden;
        display: flex;
        justify-content: space-between;
        position: fixed;
        width: 100%;
        z-index: 1000;
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
                background-color: var(--primary-light-blue);
                color: white;
            }

            .nav a:hover {
                background-color: var(--primary-light-blue);
                color: white;
                text-decoration: none;
            }

    #nav-btn-pull-right {
        float: left;
        color: #f2f2f2;
        text-align: center;
        padding: 14px 16px;
        text-decoration: none;
        font-size: 17px;
    }


        #nav-btn-pull-right:hover {
            background-color: var(--primary-light-blue);
            color: white;
            cursor: pointer;
        }

    .nav-btn-important {
        background: var(--primary-light-blue);
    }


    .background-box {
        text-align: left;
        background: var( --primary-box-background);
        margin: 10px;
        padding: 10px;
        border-radius: 5px;
    }

    .background-box-standard {
        min-width: 350px;
    }


    #content{
        padding-top: 51px;
    }

    li.list-group-item {
        background: var(--primary-box-background);
        cursor: pointer;
        color: #111;
    }
    li.list-group-item-action:hover {
        background: var(--secondary-light-blue);
        color: #000;
    }

    .icon {
        height: 1.5em;
    }



</style>
