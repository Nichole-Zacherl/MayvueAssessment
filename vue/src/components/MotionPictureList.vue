<template>
  <div class="motion-picture-container">
    <div class="add-btn">
      <b-button variant="primary" @click="showCreateModal()">
        <b-icon icon="plus-circle-fill" />
        Add
      </b-button>
    </div>
    <div class="motion-picture-table">
      <b-table
        striped
        hover
        :items="this.$store.state.motionPictures"
        :fields="fields"
      >
        <template #cell(Actions)="row">
          <div id="btn-grouping">
            <div id="edit-btn-modal">
              <b-button
                id="show-btn"
                @click="showEditModal()"
                variant="outline-secondary"
              >
                <font-awesome-icon
                  icon="fa-solid fa-pen-to-square"
                  class="text-dark"
                />
              </b-button>
            </div>

            <b-button
              variant="outline-secondary"
              @click="copyMotionPicture(row.item.id)"
            >
              <font-awesome-icon icon="fa-regular fa-copy " class="text-dark" />
            </b-button>
            <b-button
              variant="outline-secondary"
              @click="deleteMotionPicture(row.item.id)"
            >
              <font-awesome-icon
                icon="fa-solid fa-trash-can"
                class="text-danger"
              />
            </b-button>
          </div>
        </template>
      </b-table>
    </div>

    <b-modal
      ref="edit-modal"
      id="edit-modal"
      title="Edit Motion Picture"
      hide-header-close
    >
      <form class="update-motion-picture-form">
        <div class="name">
          <div class="field">
            <label for="name-input"> Title: </label>
          </div>
          <div class="control">
            <input
              class="name-input"
              type="text"
              maxlength="50"
              v-model="motionPicture.name"
              required
            />
          </div>
        </div>

        <div class="description">
          <div class="field">
            <label for="textarea-input">Description:</label>
          </div>
          <div class="control">
            <textarea class="textarea-input" maxlength="500"></textarea>
          </div>
        </div>

        <div class="year">
          <div class="field">
            <label for="year-input"> Release Year: </label>
          </div>
          <div class="control">
            <input class="year-input" type="text" maxlength="4" required />
          </div>
        </div>
      </form>
      <template v-slot:modal-footer="{ ok, cancel, deleteMotionPicture }">
        <b-button @click="ok()">Save</b-button>
        <b-button @click="cancel()">Cancel</b-button>
        <b-button @click="deleteMotionPicture(motionPicture.id)"
          >Delete</b-button
        >
      </template>
    </b-modal>
    <b-modal
      hide-header-close
      ref="create-modal"
      id="create-modal"
      title="Create A Motion Picture"
      ok-title="Save"
    >
      <form class="create-motion-picture-form">
        <div>
          <div class="field">
            <label for="name-input"> Title: </label>
          </div>
          <div class="control">
            <input class="name-input" type="text" maxlength="50" required />
          </div>
        </div>

        <div class="description">
          <div class="field">
            <label for="textarea-input">Description:</label>
          </div>
          <div class="control">
            <textarea class="textarea-input" maxlength="500"></textarea>
          </div>
        </div>

        <div>
          <div class="field">
            <label for="year-input"> Release Year: </label>
          </div>
          <div class="control">
            <input class="year-input" type="text" maxlength="4" required />
          </div>
        </div>
      </form>
    </b-modal>
  </div>
</template>

<script>
import motionPictureService from "@/services/MotionPictureService.js";

export default {
  name: "motion-picture-list",
  props: [],
  data() {
    return {
      fields: [
        {
          key: "name",
          sortable: true,
        },
        {
          key: "description",
          sortable: true,
        },
        {
          key: "releaseYear",
          sortable: true,
        },
        "Actions",
      ],
      motionPicture: {
        id: "",
        name: "",
        description: "",
      },
    };
  },
  methods: {
    addNewMotionPicture() {
      this.$store.commit("ADD_MOTION_PICTURE", this.newMotionPicture);
      this.$router.push({ name: "home" });
    },
    showEditModal() {
      this.$bvModal.show("edit-modal");
    },
    showCreateModal() {
      this.$bvModal.show("create-modal");
    },
    getMotionPictures() {
      motionPictureService.list().then((response) => {
        this.$store.commit("SET_MOTION_PICTURES", response.data);
      });
    },
    deleteMotionPicture(id) {
      motionPictureService.delete(id).then((response) => {
        if (response.status === 200) {
          this.getMotionPictures();
        }
      });
    },
    copyMotionPicture(id) {
      motionPictureService.copy(id).then((response) => {
        if (response.status === 200) {
          console.log("COPY:ID", id);
          this.getMotionPictures();
        }
      });
    },
    //  updateMotionPicture() {
    //   const motionPicture = { id: this.id, name: this.name };
    //   if (this.id === 0) {
    //     motionPictureService.add(motionPicture).then((response) => {
    //       if (response.status === 201) {
    //         this.$router.push(`/`);
    //       }
    //     });
    //   } else {
    //     motionPicture.name = this.name;
    //     motionPictureService.update(motionPicture).then((response) => {
    //       if (response.status === 200) {
    //         this.$router.push(`/`);
    //       }
    //     });
    //   }
    // },
  },
  created() {
    this.getMotionPictures();
  },
  // created() {
  //   topicService
  //     .get(this.topicID)
  //     .then((response) => {
  //       this.$store.commit("SET_ACTIVE_MOTION_PICTURE", response.data);
  //       this.title = response.data.title;
  //     })
  //     .catch((error) => {
  //       if (error.response.status == 404) {
  //         this.$router.push({ name: "NotFound" });
  //       }
  //     });
};
</script>

<style>
.motionPicture {
  margin: 10px;
}
#btn-grouping {
  display: flex;
  gap: 2px;
}
.textarea-input {
  width: 380px;
  height: 100px;
}
/* .name-input {
  width: 380px;
} */
.add-btn {
  display: flex;
  justify-content: flex-end;
  margin: 10px;
}
.update-motion-picture-form {
  padding: 20px;
}
</style>
