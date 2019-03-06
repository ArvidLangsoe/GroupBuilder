<template>

    <div class="room-grid">
        <div class="room-details background-box">
            Details of room. this is some details that are important.

        </div>

        <div class="room-members background-box">
            <h3>Members</h3>
            <ul>
                <li>Member1</li>
                <li>Member2</li>
                <li>Member3</li>
                <li>Member4</li>
            </ul>

        </div>

        <div class="group-overview">
            <h3>My Groups</h3>
            <div class="group-container">
                <div class="group my-group background-box">
                    <p>My group</p>
                    <p>My group</p>
                    <p>My group</p>
                    <p>My group</p>
                    <p>My group</p>
                    <p>My group</p>
                </div>
                <div class="group my-group background-box">
                    Another group of mine
                </div>
            </div>

            <h3>Other Groups</h3>
            <div class="group-container">
                <div class="group background-box">
                    Other groups
                </div>
            </div>
        </div>

        <div class="admin-panel">
            <h4>Admin</h4>

        </div>

    </div>


</template>

<script>


</script>

<style scoped>
    .room-grid {
        text-align: left;
        display: grid;
        grid-template-columns: 200px auto 200px;
        grid-template-rows: 100px auto 200px;
        grid-template-areas: "members header admin" "members groups admin";
    }

    .room-details {
        grid-area: header;
    }

    .room-members {
        grid-area: members;
    }

    .group-overview {
        grid-area: groups;
    }

    .admin-panel {
        grid-area: admin;
        border-left: solid 2px var(--main-dark-blue);
        border-bottom: solid 2px var(--main-dark-blue);
        background-color: var(--primary-box-background);
        margin-top: 3px;
        padding: 4px;
        position: fixed;
        right: 0px;
        width: 200px;
        height: 100%;
    }
    /*Mobile changes*/
    @media only screen and (max-width: 1000px) {
        .room-grid {
            text-align: left;
            display: grid;
            grid-template-columns: 200px auto;
            grid-template-rows: 200px auto;
            grid-template-areas: "members header" "members groups";
        }
        .admin-panel {
            visibility: hidden;
        }
    }


    .group-container {
        display: flex;
        align-content: stretch;
        flex-wrap: wrap;
    }

    .my-group {
        background-color: var(--secondary-light-blue)
    }

    .group {
        min-width: 200px;
        border: solid 2px;
        border-color: var(--secondary-light-blue);
    }
</style>