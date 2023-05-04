<template>
  <!-- Modal Body -->
  <!-- if you want to close by clicking outside the modal, delete the last endpoints: [data-bs-backdrop="static" data-bs-keyboard="false"]-->
  <div class="modal fade" id="modalId" tabindex="-1" role="dialog" aria-labelledby="modalTitleId" aria-hidden="true">
    <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered" :class="size" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="modalTitleId">
            <slot name="header">Test Modal</slot>
          </h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <slot name="body">You Didn't Put anything in here</slot>
        </div>
      </div>
    </div>
  </div>
</template>


<script lang="ts">

export default {
  props: {
    size: { type: String, default: 'modal-sm' }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>