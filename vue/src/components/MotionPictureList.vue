b<template>
  <div class="motion-picture-container">
    <div class="add-btn">
      <b-button variant="primary" @click="showModal()">
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
                @click="showModal(row.item.id)"
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
      hide-header-close
      ref="modal"
      id="modal"
      :title="
        motionPicture.id ? 'Edit A Motion Picture' : 'Create A Motion Picture'
      "
      hide-footer
      @hide="resetModal"
    >
      <form ref="form" validated="" :class="wasValidated && 'was-validated'">
        <b-form-group label="Name" label-for="name-input">
          <b-form-input
            id="name-input"
            class="name-input"
            v-model="motionPicture.name"
            maxlength="50"
            required
          />
          <b-form-invalid-feedback>
            Name is required and must be under 50 characters.
          </b-form-invalid-feedback>
        </b-form-group>
        <b-form-group label="Description" label-for="description-input">
          <b-form-textarea
            id="description-input"
            v-model="motionPicture.description"
            maxlength="500"
          />
          <b-form-invalid-feedback>
            Description must be under 500 characters.
          </b-form-invalid-feedback>
        </b-form-group>
        <b-form-group label="Release Year" label-for="year-input">
          <b-form-input
            class="year-input"
            v-model="motionPicture.releaseYear"
            required
            type="number"
            min="1000"
            max="9999"
            number
          />
          <b-form-invalid-feedback>
            Year must be four digits.
          </b-form-invalid-feedback>
        </b-form-group>
        <div class="modal-footer">
          <b-button
            v-if="motionPicture.id"
            variant="danger"
            @click="deleteMotionPicture(motionPicture.id)"
            >Delete</b-button
          >
          <b-button @click="hideModal">Cancel</b-button>
          <b-button @click="submitMotionPicture" variant="primary"
            >Save</b-button
          >
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
      wasValidated: false,
      motionPicture: {
        id: 0,
        name: "",
        description: "",
        releaseYear: "",
      },
    };
  },
  methods: {
    submitMotionPicture() {
      const valid = this.$refs.form.checkValidity();
      if (!valid) {
        this.wasValidated = true;
        return;
      }
      if (this.motionPicture.id) {
        this.updateMotionPicture();
      } else {
        this.addNewMotionPicture();
      }
    },
    addNewMotionPicture() {
      motionPictureService.add(this.motionPicture).then((response) => {
        if (response.status === 200) {
          this.$bvModal.hide("modal");
          this.getMotionPictures();
        }
      });
    },
    resetModal() {
      this.wasValidated = false;
      this.motionPicture.id = 0;
      this.motionPicture.name = "";
      this.motionPicture.description = "";
      this.motionPicture.releaseYear = "";
    },
    showModal(id) {
      if (id) {
        const existing = this.getMotionPicture(id);
        this.motionPicture = { ...existing };
      }
      this.$bvModal.show("modal");
    },
    hideModal() {
      this.$bvModal.hide("modal");
    },
    getMotionPictures() {
      return motionPictureService.list().then((response) => {
        this.$store.commit("SET_MOTION_PICTURES", response.data);
      });
    },
    getMotionPicture(id) {
      return this.$store.state.motionPictures.find((m) => m.id === id);
    },
    deleteMotionPicture(id) {
      const mp = this.getMotionPicture(id);
      this.$bvModal
        .msgBoxConfirm(`Are you sure you want to delete "${mp.name}"?`, {
          title: "Please Confirm",
          size: "sm",
          buttonSize: "sm",
          okVariant: "danger",
          okTitle: "YES",
          cancelTitle: "NO",
          footerClass: "p-2",
        })
        .then((value) => {
          if (value) {
            motionPictureService
              .delete(id)
              .then((response) => {
                if (response.status === 200) {
                  const mp = this.getMotionPicture(id);
                  this.getMotionPictures().then(() => {
                    this.$nextTick(() => {
                      setTimeout(() => {
                        this.makeToast(`Deleted "${mp.name}"`, "danger");
                      });
                    });
                  });
                }
              })
              .catch((e) =>
                this.makeToast("Error deleting motion picture: " + e, "danger")
              );
          }
        });
    },
    copyMotionPicture(id) {
      console.log("here");
      if (id) {
        const existing = this.getMotionPicture(id);
        this.motionPicture = { ...existing, id: 0 };
        this.$bvModal.show("modal");
      }
    },
    updateMotionPicture() {
      motionPictureService.update(this.motionPicture).then((response) => {
        if (response.status === 200) {
          this.getMotionPictures();
          this.hideModal();
        }
      });
    },
    makeToast(message, variant = "success") {
      this.toastCount++;
      this.$bvToast.toast(message, {
        title: "BootstrapVue Toast",
        autoHideDelay: 5000,
        appendToast: true,
        variant,
        noCloseButton: true,
      });
    },
  },
  created() {
    this.getMotionPictures();
  },
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
.add-btn {
  display: flex;
  justify-content: flex-end;
  margin: 10px;
}
.modal-footer {
  margin: 15px;
}
.form-group {
  margin-bottom: 1rem;
}
th {
  min-width: 150px;
}
.toast:not(.show) {
  display: block;
}
</style>
