<template>
  <div class="">
    <form @submit.prevent="" class="d-flex">
      <input class="form-control" type="text" id="search" required placeholder="Search..." minlength="3" maxlength="25">

      <button type="submit" class="btn btn-warning"> <i class="mdi mdi-magnify"></i> </button>
    </form>
  </div>
</template>


<script lang="ts">
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>