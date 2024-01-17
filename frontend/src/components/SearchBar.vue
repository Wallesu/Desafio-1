<template>
    <div class="container">
        <i class='bx bx-search searchIcon'></i>
        <input
            @input="emitValue(value)"
            v-model="value"
            class="input"
            type="search"
            :placeholder="placeholder"
            aria-label="Search"
        />
        <i v-if="isLoading" class='bx bx-loader-alt bx-spin loadIcon' ></i>
    </div>
</template>

<script>
export default {
    name: 'VSearchBar',
    props: {
        input: {
            default: ''
        },
        isLoading: {
            type: Boolean,
            default: false
        },
        placeholder: {
            type: String,
            default: 'Search'
        }
    },
    data() {
        return {
            value: ''
        }
    },
    mounted () {
        this.value = this.input;
    },
    model: {
        prop: 'input',
        event: 'emitValue'
    },
    methods: {
        emitValue() {
            this.$emit('emitValue', this.value)
        }
    },
}

</script>

<style scoped>
.container{
    background-color: white;
    border-radius: 5px;
    display: flex;
    align-items: center;
    height: 2.2rem;
}
.input{
    width: 100%;
    border: none;
}
.input textarea:focus, input:focus{
    outline: none;
}
.searchIcon{
    font-size: 1.4rem;
    color: black;
    transform: translateY(1px);
    padding-right: 0.5rem;
}
.loadIcon{
    color: black;
    font-size: 1.3rem;
}
</style>