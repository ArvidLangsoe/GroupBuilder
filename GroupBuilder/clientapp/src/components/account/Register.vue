<template>
    <div>
        <h4>Register</h4>
        <form @submit.prevent="register">
            <div class="form-group">
                <label for="email">E-Mail Address</label>
                <input required type="email" v-model="email" id="email" placeholder="Email" class="form-control" aria-describedby="emailHelp">
                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <div class="form-group">
                <label for="password">Password</label>
                <input required id="password" type="password" v-model="password" placeholder="Password" class="form-control" name="password" ref="password">
            </div>

            <div class="form-group">
                <label for="password-confirm">Confirm Password</label>
                <input required id="password-confirm" type="password" v-model="password_confirmation" placeholder="Repeat Password" class="form-control" v-validate="'confirmed:password'" name="password_confirmation" data-vv-as="password">
            </div>
            <!-- ERRORS -->
            <div class="alert alert-danger" v-show="errors.any()">

                <!-- Kept this for later. -->
                <div v-if="errors.has('password')">
                    {{ errors.first('password') }}
                </div>
                <div v-if="errors.has('password_confirmation')">
                    Passwords dont match.
                </div>
            </div>
            <div>
                <button type="submit" class="btn btn-primary login-form-button">Register</button>
            </div>
        </form>
    </div>
</template>

<script>


    export default {
        data() {
            return {
                email: "",
                password: "",
                password_confirmation: "",
            }
        },
        methods: {
            register: function () {
                let data = {
                    email: this.email,
                    password: this.password,
                }
                this.$store.dispatch('register', data)
                    .then(() => {
                        this.$router.push('/');
                        this.$store.dispatch('login', data)
                    })
                    .catch(err => console.log(err))
            }
        }
    }
</script>