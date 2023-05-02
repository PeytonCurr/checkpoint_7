<template>
  <nav class="bg-dark p-3 row">
    <div class="col-8"></div>
    <div class="col-4 d-flex justify-content-end">
      <SearchBar class="me-2" />
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
import Login from './Login.vue'
import SearchBar from './SearchBar.vue';
export default {
  setup() {
    return {}
  },
  components: { Login, SearchBar }
}
</script>

<style scoped></style>
