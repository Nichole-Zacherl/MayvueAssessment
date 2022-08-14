<template>
  <form class="new-motion-picture-form" v-on:submit.prevent>
    <div>
      <div class="field">
        <label for="name-input"> Title: </label>
      </div>
      <div class="control">
        <input class="name-input" type="text" placeholder="Title" />
      </div>
    </div>
    <div class="description">
      <div class="field">
        <label class="label">Description:</label>
      </div>
      <div class="control">
        <textarea class="textarea" placeholder="Description"></textarea>
      </div>
    </div>
    <div>
      <div class="field">
        <label for="year-input"> Release Year: </label>
      </div>
      <div class="control">
        <input class="year-input" type="text" placeholder="year" />
      </div>
    </div>

    <b-button class="button is-primary">
      Submit
    </b-button>
  </form>
</template>

<script>
export default {
  name: "create",
  data() {
    return {
      newMotionPicture: {
        id: 0,
        name: "",
        description: "",
        releaseYear: 0,
      },
    };
  },
  methods: {
    addNewMotionPicture() {
      this.$store.commit("ADD_MOTION_PICTURE", this.newMotionPicture);
      this.$router.push({ name: "home" });
    },
  },
};
</script>

<style>
form {
  padding: 50px;
}
.field {
  padding: 1px;
}
.description {
  width: 1000px;
}
.button {
  margin: 10px;
}
</style>
