<template>
  <section class="row recipeImg p-2 rounded  elevation-5">
    <div class="col-12 d-flex flex-column justify-content-between">
      <div class="d-flex justify-content-between">
        <span class="glass rounded p-1 text-light">{{ rec.category }}</span>
        <span class="glass rounded p-1"><i class="mdi mdi-heart-outline"></i></span>
      </div>
      <b class="glass rounded p-1 text-light text-center">{{ rec.title }}</b>
    </div>
  </section>
</template>


<script lang="ts">
import { computed } from 'vue';
import { Recipe } from '../models/Recipe';

export default {

  props: {
    rec: { type: Recipe, required: true }
  },

  setup(props) {
    return {
      recipeImg: computed(() => `url(${props.rec.img})`)
    }
  }
}
</script>


<style lang="scss" scoped>
.recipeImg {
  min-height: 30vh;
  background-image: v-bind(recipeImg);
  background-position: center;
  background-size: cover;
}

.glass {
  background-color: rgba(128, 128, 128, 0.739);
}
</style>