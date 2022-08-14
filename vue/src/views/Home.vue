<template>
  <div class="home">
    <motion-picture-list />
  </div>
</template>

<script>
import MotionPictureList from "../components/MotionPictureList.vue";
export default {
  components: { MotionPictureList },
  name: "home",
};
</script>
