<template>
  <div id="book-detail">
    <ul class="collection with-header">
      <li class="collection-header">
        <h3>#{{ book.BookId }} {{ book.Title }}</h3>
      </li>
      <li class="collection-item">Authors: {{ book.Authors }}</li>
      <li class="collection-item">Price: ￥{{ book.Price }}</li>
      <li class="collection-item">BookCoverUrl: {{ book.BookCoverUrl }}</li>
    </ul>
    <router-link to="/books" class="btn grey">Back</router-link>
    <button @click="addToCart" class="btn blue">Add To Cart</button>
  </div>
</template>

<script>
export default {
  name: 'book-detail',
  data () {
    return {
      book: {
        BookId: 0,
        Title: null,
        Authors: null,
        Price: null,
        BookCoverUrl: null
      }
    }
  },
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.$store.state.services.booksService
        .getById(to.params.id)
        .then(res => {
          vm.book.BookId = res.data.BookId
          vm.book.Title = res.data.Title
          vm.book.Authors = res.data.Authors
          vm.book.Price = res.data.Price
          vm.book.BookCoverUrl = res.data.BookCoverUrl
        })
        .catch(err => console.log(err))
    })
  },
  watch: {
    '$route': 'getBook'
  },
  methods: {
    getBook() {
      let self = this
      self.$store.services.booksService
        .getById(self.$route.params.id)
        .then(res => {
          let _book = self.book
          _book.BookId = res.data.BookId
          _book.Title = res.data.Title
          _book.Authors = res.data.Authors
          _book.Price = res.data.Price
          _book.BookCoverUrl = res.data.BookCoverUrl
        })
        .catch(err => console.log(err))
    },
    addToCart () {
      if(confirm('Are you sure to add the book to your cart?')) {
        console.info('i will buy this book.')
      }
    }
  }
}
</script>

<style>

</style>
