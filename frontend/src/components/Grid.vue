<template>
    <div>
        <div class="title">
            {{ title }}
        </div>
        <div class="grid">
            <div v-for="item in data" class="item">
                {{ item.name }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'VGrid',
    props: {
        data: {
            default: []
        },
        title: {
            type: String
        }
    },
}

</script>

<style scoped>
.title{
    display: flex;
    justify-content: center;
    font-size: 2rem;
    padding: 0.5rem 0 1rem 0;
}
.grid{
    padding: 0 1rem;
    display: flex;
    width: 80rem;
    flex-wrap: wrap;

    /* justify-content: ; */
}
.item{
    margin: 0.5rem;
    border: 1px solid black;
    padding: 0.5rem;
    min-width: 5rem;
    text-align: center;
    border-radius: 5px;
    transition: 0.2s;
}
.item:hover{
    background-color: whitesmoke;
    /* color: #008170; */
    /* font-weight: bold; */
    cursor: pointer;
}
</style>