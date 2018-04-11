import Vue from 'vue'
import Router from 'vue-router'

import HelloWorld from '@/components/HelloWorld'
import Dashboard from '@/components/Dashboard'
import BooksIndex from '@/components/books/Index'
import BookDetail from '@/components/books/Detail'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/books',
      name: 'books-index',
      component: BooksIndex
    },
    {
      path: '/books/:id',
      name: 'book-detail',
      component: BookDetail
    }
  ]
})
