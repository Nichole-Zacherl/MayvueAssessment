import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    motionPictures: [],
  },
  mutations: {
    SET_MOTION_PICTURES(state, data) {
      state.motionPictures = data;
    },
  },
})
