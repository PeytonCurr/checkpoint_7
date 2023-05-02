<template>
  <nav class="bg-dark px-3 d-flex align-items-top justify-content-end">
    <SearchBar class="pt-3 me-2" />
    <!-- LOGIN COMPONENT HERE -->
    <Login />
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
