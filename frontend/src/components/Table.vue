<template>
    <div>
        <div v-if="title" class="title">
            {{ title }}
        </div>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th v-for="header in headers">{{ header }}</th>
                </tr>
            </thead>

            <tbody v-if="data.length && !isLoading">
                <tr v-for="(song, index) in data" :key="index" class="tr">
                    <td>{{ song.name || '' }}</td>
                    <td>{{ song.artist ? song.artist.name : '' }}</td>
                    <td>{{ song.genres ? song.genres.map(genre => genre.name).toString().replace(',', ', ') : ''}}</td>
                    <td>{{ song.year }}</td>
                </tr>
            </tbody>
        </table>
        <div class="noRecords" v-if="!data.length && !isLoading">
            Nenhum registro encontrado!
        </div>
        <div class="loading" v-if="isLoading">
            <i class='bx bx-loader-alt bx-spin' ></i>
        </div>
    </div>
</template>

<script>
export default {
    name: 'VTable',
    props: {
        data: {
            default: []
        },
        headers: {
            default: []
        },
        title: {
            type: String
        },
        isLoading: {
            default: false,
            type: Boolean
        }
    }
};

</script>

<style scoped>
.title{
    display: flex;
    justify-content: center;
    font-size: 2rem;
    padding: 0.5rem 0 1rem 0;
}
.noRecords{
    display: flex;
    justify-content: center;
    font-size: 1.2rem;
    padding: 1rem;
}
.loading{
    display: flex;
    justify-content: center;
    padding: 1.5rem;
    font-size: 2rem;
}
.tr:hover{
    background: blue !important;
}
</style>