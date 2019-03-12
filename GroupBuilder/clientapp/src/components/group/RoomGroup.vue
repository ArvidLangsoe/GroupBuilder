<template>
    <div class="group background-box" v-bind:class="{mygroup: isMyGroup}">
        <h5> Group Id: {{group.id}}</h5>
        <draggable v-model="members" group="users" @start="drag=true" @end="drag=false" @change="changeMembers" :sort="false" class="scrollable-groups-members">
            <ul v-for="participant in members" v-bind:key="participant.user.id" class="list-group list-group-flush">
                <li class="list-group-item">{{participant.user.email}}</li>
            </ul>
        </draggable>
    </div>
</template>

<script>
    import draggable from 'vuedraggable'
    export default {
        components: {
            draggable
        },
        props: {
            group: Object,
            isMyGroup: Boolean
        },
        computed: {
            members: {
                get: function () {
                    return this.group.members;
                },
                set: function (value) {
                    //might wanna not update this, instead retrieve from server?
                    this.group.members = value;
                }
            }
        },
        methods: {
            changeMembers: function (added, removed, moved) {
                console.log(added);
                console.log(removed);
                console.log(moved);
            }
        }
    }

</script>

<style scoped>

    .mygroup {
        background-color: var(--secondary-light-blue)
    }

        .mygroup li {
            background-color: var(--secondary-light-blue)
        }

    .group {
        border: solid 2px;
        border-color: var(--secondary-light-blue);
    }

    .scrollable-groups-members {
        overflow-y: auto;
        min-height: 100px;
        max-height: 300px;
    }
</style>