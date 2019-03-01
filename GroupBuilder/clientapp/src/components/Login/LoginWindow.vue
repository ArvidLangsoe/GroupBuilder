<template>
    <div class="login-window">
        <div class="login-box">
            <form>
                <div class="form-group">
                    <label for="inputLoginEmail">Email address</label>
                    <input type="email" id="inputLoginEmail" placeholder="Email" class="form-control" aria-describedby="emailHelp">
                    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                </div>
                <div class="form-group">
                    <label for="inputPassword">Password</label>
                    <input type="password" class="form-control" id="inputPassword" placeholder="Password">
                    <a class="small text-muted" href="/">Forgotten password?</a>
                </div>
                
                <div class="login-buttons">
                    <button type="submit" class="btn btn-primary login-button">Login</button>
                    <button class="btn btn-secondary login-button">Create Account</button>
                </div>
            </form>
        </div>
    </div>
</template>




<script>
    export default {
        name: 'HelloWorld',
        props: {
            msg: String
        }

    }</script>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    

    .login-window {
        display: flex;
        justify-content: space-around;

    }
    .login-box {
        border: 2px solid #CCCCCC;
        border-radius: 25px;
        min-width: 400px;
        padding: 10px;
        background: #FAFAFA;
        text-align: left;
    }
    .login-buttons {
        display: flex;
        justify-content: center;
    }
    .login-button {
        margin: 5px;
    }


</style>
