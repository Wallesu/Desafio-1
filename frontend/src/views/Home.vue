
<template>
    <div>
        <div class="banner">
            <div class="pb-5">
                <div class="d-flex justify-content-center align-items-center">
                    <h1 class="title">{{ titulo }}</h1>
                    <i class='bx bxs-music songIcon'></i>
                </div>    
                <h3 class="subtitle">
                    The most beautiful API in the world
                </h3>
            </div>
        
            <div class="w-100 d-flex justify-content-center">
                <div v-show="selectedTab =='Songs'" class="searchBar">
                    <SearchBar v-model="search" :isLoading="isLoading.search" :placeholder="searchBy == 'artist' ? 'Search by artists' : 'Search by genres'"/>
                    <div>
                        <VSelect v-model="searchBy"/>
                    </div>
                </div>
                <div v-show="selectedTab != 'Songs'" class="noSearchBar"></div>
            </div>
            
            <div class="">
                <VNavBar :items="['Songs', 'Genres']" @selected="changeTab($event)"></VNavBar>
            </div>
              
        </div>

        <div class="px-5 d-flex justify-content-center">
            <div v-if="selectedTab == 'Songs'" class="container-table">
                <VTable
                    v-if="!errors.songsRequest"
                    :headers="songsHeaders"
                    :data="songs"
                    title="Songs"
                    :isLoading="isLoading.songs"
                />
                <div v-else class="d-flex justify-content-center p-5">
                    <Warn :message="errors.songsRequest"></Warn>
                </div>
            </div>
            <div v-else-if="selectedTab == 'Genres'" class="container-table">
                <VGrid
                    v-if="!errors.genresRequest"
                    :data="genres"
                    title="Genres"
                />
                <div v-else class="d-flex justify-content-center p-5">
                    <Warn :message="errors.genresRequest"></Warn>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    import VTable from '../components/Table.vue'
    import SearchBar from '../components/SearchBar.vue'
    import VSelect from '../components/Select.vue'
    import VNavBar from '../components/NavBar.vue'
    import Warn from '../components/Warn.vue'
    import VGrid from '../components/Grid.vue'

    export default {
    name: 'Home',
    components: {
        VTable,
        SearchBar,
        VSelect,
        VNavBar,
        Warn,
        VGrid
    },
    data () {
        return {
            songs: [],
            genres: [],
            search: '',
            searchBy: 'artist',
            selectedTab: 'Songs',
            songsHeaders: ['Name', 'Artist', 'Genres', 'Year'],
            genresHeaders: ['Name'],
            timer: null,
            isLoading: {
                search: false,
                songs: false,
                genres: false
            },
            errors: {
                songsRequest: null,
                genresRequest: null
            }
        }
    },

    props: {
        titulo: String
    },

    methods: {
        GetSongs(){
            this.isLoading.songs = true
            axios.get(process.env.VUE_APP_SONGS_API + '/songs/show-all').then((response) => {
                this.songs = response.data.result
                this.errors.songsRequest = null
            })
            .catch(error => {
                this.errors.songsRequest = error.response.data || 'Ocorreu um erro no servidor! Tente novamente mais tarde.'
            })
            .finally(() => {
                this.isLoading.songs = false
            })
        },
        SearchSongsByGenre (search) {
            if(!search.length) {
                this.GetSongs()
                this.isLoading.search = false
                return
            }
            axios.get(process.env.VUE_APP_SONGS_API + '/artists/search-by-genre/' + search).then(response => {
                this.songs = response.data
                this.errors.songsRequest = null
            })
            .finally(() => {
                this.isLoading.search = false
            })
        },
        SearchSongsByArtist (search) {
            if(!search.length) {
                this.GetSongs()
                this.isLoading.search = false
                return
            }
            axios.get(process.env.VUE_APP_SONGS_API + '/artists/search-songs/' + search).then(response => {
                this.songs = response.data
                this.errors.songsRequest = null
            })
            .finally(() => {
                this.isLoading.search = false
            })
        },
        GetGenres(){
            this.isLoading.genres = true
            axios.get(process.env.VUE_APP_SONGS_API + '/genres/show-all-genres').then((resp) => {   
                this.genres = resp.data
                this.errors.genresRequest = null
            })
            .catch(error => {
                this.errors.genresRequest = error.response.data || 'Ocorreu um erro no servidor! Tente novamente mais tarde.'
            })
            .finally(() => {
                this.isLoading.genres = false
            })
        },
        changeTab(tab){
            this.selectedTab = tab
        }
    },

    mounted () {
        this.GetSongs()
        this.GetGenres()
    },

    watch: {
        search(newValue) {
            clearTimeout(this.timer)
            this.isLoading.search = true
            this.timer = setTimeout(() => {
                
                if(this.searchBy === 'artist'){
                    this.SearchSongsByArtist(newValue)
                }
                else if(this.searchBy === 'genre'){
                    this.SearchSongsByGenre(newValue)
                }
            }, 250)
        },
        searchBy(){
            this.isLoading.search = true
            if(this.searchBy === 'artist'){
                this.SearchSongsByArtist(this.search)
            }
            else if(this.searchBy === 'genre'){
                this.SearchSongsByGenre(this.search)
            }
        }
    },
}
</script>

<style scoped>
.formataBotao {
    width: 200px;
}
.banner{
    background-color: #0F0F0F;
    color: white;
    text-align: center;
    padding: 4rem 1rem 1rem 1rem;
}
.subtitle{
    color: #008170
}
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
.searchBar{
    width: 50rem;
    display: flex;
    height: 3rem;
}
.noSearchBar{
    height: 3rem;
}
.songIcon{
    font-size: 2rem;
    padding: 0 0 0 1rem
}
.container-table{
    width: 80rem;

}
</style>
