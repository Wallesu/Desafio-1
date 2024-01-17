<template>
    <div class="m-md-3">
        <div class="position-relative overflow-hidden p-5 p-md-0 m-md-0 text-center bg-body-secondary">
            <div class="col-md-6 p-lg-5 mx-auto my-1 mb-2">
                <h1 class="display-4 fw-bold px-5">{{ titulo }}</h1>
                <h3 class="fw-normal text-muted mb-2">
                    The most beautiful API in the world
                </h3>
            </div>
            <div class="product-device shadow-sm d-none d-md-block"></div>
            <div class="product-device product-device-2 shadow-sm d-none d-md-block"></div>

            <div class="position- bottom-0 start-0 w-100">
                <nav class="navbar navbar-expand-lg" aria-label="Offcanvas navbar large">
                    <div class="container-fluid">
                        <div
                        class="offcanvas offcanvas-end text-bg-dark"
                        tabindex="-1"
                        id="offcanvasNavbar2"
                        aria-labelledby="offcanvasNavbar2Label"
                        >

                            <!-- Barra de pesquisa -->
                            <div class="w-75 m-md-auto d-flex justify-content-center" role="search">
                                <input
                                    v-model="search"
                                    class="form-control me-5 ml-5"
                                    type="search"
                                    placeholder="Search"
                                    aria-label="Search"
                                />
                            </div>

                            <!-- Botoes -->
                            <div class="d-flex justify-content-center mt-3">
                                <button @click="SearchByGenre" class="btn btn-outline-success formataBotao" type="submit">
                                    Search by genre
                                </button>
                                <div class="px-2"></div>
                                <button @click="SearchByArtist" class="btn btn-outline-success formataBotao" type="submit">
                                    Search by artist
                                </button>
                            </div>

                            <!-- Links -->
                            <div class="offcanvas-body">
                                <ul class="navbar-nav justify-content-center flex-grow-1 pe-3 mt-4">
                                    <li class="nav-item">
                                        <a class="btn btn-link text-muted">Songs A-Z</a>
                                    </li>
                                    <li @click="showGenres" class="nav-item">
                                        <a class="btn btn-link text-success">Genres</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </nav>
            </div>
        </div>

        <!-- Tabela de musicas -->
        <table class="table">
            <thead>
                <tr>
                    <th>Song</th>
                    <th>Artist</th>
                    <th>Genre</th>
                    <th>Year</th>
                </tr>
            </thead>

            <tbody>
                <tr v-for="(music, index) in musics" :key="index">
                    <td>{{ music.name }}</td>
                    <td>{{ music.artist.name }}</td>
                    <td>{{ music.genres.map(genre => genre.name).toString() }}</td>
                    <td>{{ music.year }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
    name: 'Musics',
    // variaveis que vou usar no template
    data () {
        return {
            musics: [],
            search: '',
        }
    },

    props: {
        titulo: String
    },

    methods: {
        // Externaliza o metodo MusicList. Scope é o escopo que ele está no momento
        MusicList () {
            axios.get(process.env.VUE_APP_SONGS_API + '/songs').then((resp) => {
                this.musics = resp.data
            })
        },

        SearchByGenre () {
            axios.get(process.env.VUE_APP_SONGS_API + '/songs?genreName=' + this.search).then((resp) => {
                this.musics = resp.data
            })
        },

        SearchByArtist () {
            axios.get(process.env.VUE_APP_SONGS_API + '/songs?artistName=' + this.search).then((resp) => {
                this.musics = resp.data
            })
        },
        showGenres(){
            axios.get(process.env.VUE_APP_SONGS_API + '/genres').then((resp) => {   
                this.musics = resp.data.map(genre => {
                    return {
                        name: '- - - - -',
                        artist: { name: '- - - - -' },
                        genres: [ { name: genre.name } ],
                        year: '- - - - -'
                    }
                })
            })
        }
    },

    created () {
        this.MusicList()
    }
}
</script>

<style scoped>
.formataBotao {
    width: 200px;
}
</style>
