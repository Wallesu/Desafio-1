<template>
    <div class="container">
        <select class="select" v-model="selectedValue">
            <option selected value="artist">Artist</option>
            <option value="genre">Genre</option>
        </select>
    </div>
</template>

<script>
export default {
    name: 'VSelect',
    data() {
        return {
            selectedValue: 'artist'
        };
    },
    props: {
        input: {
            default: 'artist'
        },
    },
    model: {
        prop: 'input',
        event: 'emitValue'
    },
    watch: {
        selectedValue(newValue) {
            this.$emit('emitValue', newValue)
        },
        input(){
            this.selectedValue = input
        }
    },
};
</script>

<style scoped>
.select{
    height: 2.2rem;
    width: 5rem;
    padding-left: 0.4rem;
    /* padding-right: 0.1rem; */
}
.container{
    height: 2.2rem;
    /* width: 4rem; */
    /* background-color: purple; */
}
</style>