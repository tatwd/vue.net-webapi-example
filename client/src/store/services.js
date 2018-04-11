import Axios from 'axios'
import BooksService from '../services/BooksService'

const apiUrl = 'http://localhost:56364/api'

// Axois config
Axios.defaults.headers.common.Accept = 'application/json'

export default {
  booksService: new BooksService(Axios, apiUrl)
}
