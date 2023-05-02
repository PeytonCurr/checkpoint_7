<template>
  <section class="row">
    <div class="col-6">
      <span class="bg-grey rounded p-1">{{ rec.category }}</span>
    </div>
    <div class="col-6"></div>
    <div class="col-12"></div>
  </section>
</template>


<script lang="ts">
import { Recipe } from '../models/Recipe';

export default {

  props: {
    rec: { type: Recipe, required: true }
  },

  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>