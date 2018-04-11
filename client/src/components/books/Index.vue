<template>
  <div id="books-index">
    <ul class="collection with-header">
      <li class="collection-header">
        <h3>Books</h3>
      </li>
      <li class="collection-item" v-for="book in books" v-bind:key="book.BookId">
        《{{ book.Title }}》 @{{ book.Authors }}
        <div class="chip">￥{{ book.Price }}</div>

        <router-link class="secondary-content" :to="{ name: 'book-detail', params: { id : book.BookId} }">
          <i class="fa fa-eye"></i>
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'books-index',
  data () {
    return {
      books: []
    }
  },
  created() {
    let self = this
    self.getAll()
  },
  methods: {
    getAll() {
      let self = this
      self.$store.state.services.booksService
        .getAll()
        .then(res => {
          res.data
            .sort((a, b) => a.BookId - b.BookId) // sort by id
            .forEach(item => {
              let book = {
                'BookId': item.BookId,
                'Title': item.Title,
                'Authors': item.Authors,
                'Price': item.Price
              }
              self.books.push(book)
            })
          // console.log(self.books)
        })
        .catch(err => console.log(err))
    }
  }
}
</script>

<style>

</style>
