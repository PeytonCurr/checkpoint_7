<template>
  <main class="container-fluid bg-secondary">
    <Navbar class="nav m-3 rounded" />
    <router-view />
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.nav {
  min-height: 30vh;
  background-image: url('../src/assets/img/unsplash_pqJ21tErTgI.png');
  background-position: center;
  background-size: cover;
}
</style>
