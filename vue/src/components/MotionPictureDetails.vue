<template
  ><div class="motion-picture-details">
    <h1 class="name">{{ motionPicture.name }}</h1>
    <h3 class="description">{{ motionPicture.description }}</h3>
    <h3 class="release-year">{{ motionPicture.releaseYear }}</h3>
  </div>
</template>

<script>
import motionPictureService from "@/services/MotionPictureService.js";

export default {
  name: "motion-picture-details",
  props: {
    motionPictureId: Number,
  },
  data() {
    return {
      motionPicture: {
        id: 0,
        name: "",
        description: "",
        releaseYear: 0,
      },
    };
  },
  //single get with id
  created() {
    motionPictureService.get(this.motionPictureId).then((response) => {
      this.motionPicture = response.data;
    });
  },
};
</script>

<style></style>
