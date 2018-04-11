<template>
  <div id="app">
    <!-- <img src="./assets/logo.png"> -->
    <Navbar/>
    <div class="container">
      <router-view/>
    </div>

    <div class="fixed-action-btn">
      <router-link to="#" class="btn-floating btn-large red">
        <i class="fa fa-cart-plus"></i>
      </router-link>
    </div>
  </div>
</template>

<script>
import Navbar from './components/shared/Navbar'
export default {
  name: 'App',
  components: {
    Navbar
  }
}
</script>

<style>

</style>
