<template>
    <div class="warn">
        <div class="container-errorIcon">
            <i class='bx bxs-error-circle errorIcon'></i>   
        </div>
        <div class="message">
            {{ message }}
        </div>
    </div>
</template>

<script>
export default {
    name: 'VWarn',
    props: {
        message: {
            type: String,
            default: ''
        },
    },
};
</script>

<style scoped>
.warn{
    width: 30rem;
    min-height: 5rem;
    display: flex;
    justify-content: center;
}
.message{
    padding: 1rem;
    background-color: palegoldenrod;
    min-height: 3rem;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 0 5px 5px 0;

}
.container-errorIcon{
    display: flex;
    min-height: 3rem;
    justify-content: center;
    align-items: center;
    background-color: red;
    min-width: 5rem;
    border-radius: 5px 0 0 5px;

}
.errorIcon{
    color: white;
    font-size: 2.5rem;
}
</style>