<template>
  <form class="update-motion-picture-form" v-on:submit.prevent>
    <div>
      <div class="field">
        <label for="name-input"> Title: </label>
      </div>
      <div class="control">
        <input
          class="name-input"
          type="text"
          maxlength="50"
          placeholder="Title"
          v-model="title"
          required
        />
      </div>
    </div>
    <div class="description">
      <div class="field">
        <label class="label">Description:</label>
      </div>
      <div class="control">
        <textarea
          class="textarea"
          maxlength="500"
          placeholder="Description"
        ></textarea>
      </div>
    </div>
    <div>
      <div class="field">
        <label for="year-input"> Release Year: </label>
      </div>
      <div class="control">
        <input
          class="year-input"
          type="text"
          maxlength="4"
          placeholder="year"
          required
        />
      </div>
    </div>

    <b-button class="button is-primary">
      Submit
    </b-button>
  </form>
</template>

<script>
export default {
  name: "update",
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
    update() {},
  },
  created() {},
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
