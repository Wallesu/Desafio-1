<template>
    <div class="d-flex justify-content-center" v-if="items">
        <div
            v-for="item in items"
            class="nav-item"
            :class="{'selected-nav-item': selectedTab == item}"
            @click="changeTab(item)"
        >
            {{ item }}
        </div>
    </div>
</template>

<script>
export default {
    name: 'VNavBar',
    props: {
        items: {
            default: null
        },
    },
    data() {
        return {
            selectedTab: 'Songs'
        }
    },
    methods: {
        changeTab(item) {
            this.selectedTab = item
            this.$emit('selected', item)
        }
    },
};
</script>

<style scoped>
.nav-item{
    padding: 1.5rem 1rem 0.5rem 1rem;
    font-weight: bold;
    font-size: 1.1rem;
    cursor: pointer;
}
.nav-item:hover{
    color: #008170;
}
.selected-nav-item{
    color: #008170;
}
</style>