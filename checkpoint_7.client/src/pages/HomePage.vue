<template>
  <section class="row">

    <div class="col-4 g-3" v-for="rec in recipes">
      <!-- STUB RecipeCard -->
      <RecipeCardVue :rec="rec" />
    </div>

  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js'
import { AppState } from '../AppState.js';
import RecipeCardVue from '../components/RecipeCard.vue'

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
  components: { RecipeCardVue }
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
</style>
