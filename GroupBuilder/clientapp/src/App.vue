<template>
    <div id="app" class="">
        <div class="nav">
            <router-link to="/">Home</router-link> |
            <router-link to="/about">About</router-link>

            <router-link to="/about">About</router-link>
            <router-link to="/about">About</router-link>

        </div>
        <div id="content">
            <LoginWindow />
            <router-view />
        </div>
    </div>
</template>


<script>
    import LoginWindow from './components/account/LoginWindow.vue'

    export default{
        components: {
            LoginWindow,

        },
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

        
</style>
