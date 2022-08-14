import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'


Vue.use(Vuex)

axios.defaults.headers['Access-Control-Allow-Origin'] = '*';

export default new Vuex.Store({
  state: {
    motionPictures: [],
    activeMotionPicture: {
      id: 0,
      name: "",
      description: "",
      releaseYear: 0
    },
  },
  mutations: {
    //adds to table 
    ADD_MOTION_PICTURE(state, motionPicture) {
      state.motionPictures.push(motionPicture)
    },
    //grabs individual
    SET_ACTIVE_MOTION_PICTURE(state, data) {
      state.activeMotionPictures = data;
    },
    //grabs list
    SET_MOTION_PICTURES(state, data) {
      state.motionPictures = data;
    },
    //deletes from table
    DELETE_MOTION_PICTURE(state, id) {
      state.activeMotionPicture = state.motionPictures.filter((motionPicture) => {
        return motionPicture.id !== id;
      })
    },
  },
})
