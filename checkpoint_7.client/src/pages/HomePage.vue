<template>
  <section class="row">
    <div class="col-12 text-end">

      <!-- SECTION FilterBarArea -->
      <section class="row justify-content-center">

        <!-- STUB FilterBar_Component -->
        <div
          class="col-5 d-flex justify-content-around text-success bg-light rounded elevation-3 px-3 py-2 filterBar no-select">
          <h3 class="mb-0 filters">Home</h3>
          <h3 class="mb-0 filters">My Recipes</h3>
          <h3 class="mb-0 filters">Favorites</h3>
        </div>

      </section>


      <!-- SECTION Recipes -->
      <section class="row px-4 justify-content-around">

        <div class="col-4 pb-5 px-5" v-for="rec in recipes">
          <!-- STUB RecipeCard -->
          <RecipeCardVue :rec="rec" />
        </div>

      </section>

      <!-- SECTION Add Recipe Button -->
      <div class="sticky-bottom">
        <span class="filters rounded-circle bg-success fs-2 p-2 border border-dark me-3" data-bs-toggle="modal"
          data-bs-target="#modalId"><i class="mdi mdi-plus fs-1"></i></span>
        <div class="spacing"></div>
      </div>

      <Modal />

    </div>
  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js'
import { AppState } from '../AppState.js';
import RecipeCardVue from '../components/RecipeCard.vue'
import Modal from '../components/Modal.vue';

export default {
  setup() {
    onMounted(() => {
      getRecipes();
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    return {
      recipes: computed(() => AppState.recipes)
    };
  },
  components: { RecipeCardVue, Modal }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}

.filterBar {
  position: relative;
  top: -2.5em;
}

.filters:hover {
  cursor: pointer;
  filter: drop-shadow(1px 0px);
}

.filters:active {
  transform: scale(0.95);
  filter: brightness(0.80);
}

.spacing {
  min-height: 3vh;
}
</style>
