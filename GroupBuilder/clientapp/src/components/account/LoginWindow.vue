<template>
    <div v-if="showLogin" v-on:show-login="setVisible">
        <div class="login-mask" @click.self="showLogin = false">
            <div class="login-container">
                <div class="login-window">
                    <div class="login-box">
                        <h4>Login</h4>
                        <form class="login-form" @submit.prevent="login">
                            <div class="form-group">
                                <label for="inputLoginEmail">E-Mail Address</label>
                                <input required v-model="email" type="email" id="inputLoginEmail" placeholder="Email" class="form-control" aria-describedby="emailHelp">
                                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword">Password</label>
                                <input required v-model="password" type="password" class="form-control" id="inputPassword" placeholder="Password">
                                <a class="small text-muted" href="/">Forgotten password?</a>
                            </div>

                            <div class="login-form-buttons">
                                <button type="submit" class="btn btn-primary login-form-button">Login</button>
                                <button class="btn btn-secondary login-form-button" v-on:click.prevent="register">Create Account</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { EventBus } from '../../event-bus.js';
    import store from '../../store/store.js'

export default {
    name: 'LoginForm',
    props: {
        show: Boolean
    },
    data: function () {
        return {
            showLogin: this.show,
            email: "",
            password: ""
        }
    },
    methods:  {
        setVisible: function(){
            this.showLogin=true;
        },
        login: function () {
            let email = this.email 
            let password = this.password
            this.$store.dispatch('login', { email, password })
                .then(() => {this.$router.push('/'); this.showLogin=false})
                .catch(err => console.log(err))
        },
        register: function () {
            this.showLogin = false;
            this.$router.push('/register');
        }
    },
    mounted(){
        EventBus.$on('show-login', () => {
            if (!store.getters.isLoggedIn) {
                this.showLogin = true;
            }
        });
    }

}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .login-mask {
        position: fixed;
        z-index: 9998;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, .5);
        transition: opacity .3s ease;
    }

    .login-container {
        position: fixed;
        top: 50%;
        left: 50%;
        /* bring your own prefixes */
        transform: translate(-50%, -50%);
        transition: all 0.3s ease;
    }


    .login-window {
        display: flex;
        justify-content: space-around;
    }

    .login-box {
        border: 2px solid #EEEEEE;
        border-radius: 25px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 1.0);
        min-width: 300px;
        padding: 10px;
        background: #FAFAFA;
    }

    .login-form {
        text-align: left;
    }

    .login-form-buttons {
        display: flex;
        justify-content: center;
    }

    .login-form-button {
        margin: 5px;
    }
</style>
