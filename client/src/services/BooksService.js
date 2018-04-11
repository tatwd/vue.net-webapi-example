/**
 * Books Service
 */
class BooksService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = `${apiUrl}/books`
  }

  // get all books
  getAll () {
    let self = this;
    return self.axios.get(`${self.baseUrl}`)
  }

  // get book by id
  getById (id) {
    let self = this;
    return self.axios.get(`${self.baseUrl}/${id}`)
  }
}

export default BooksService
