import axios from 'axios';

export default {

    list() {
        return axios.get('/motionPicture');
    },
    add(motionPicture) {
        return axios.post('/motionPicture', motionPicture);
    },
    update(motionPicture) {
        return axios.put(`/motionPicture`, motionPicture);
    },
    delete(id) {
        return axios.delete(`/motionPicture/${id}`);
    },
    copy(id) {
        return axios.post(`/motionPicture/copy/${id}`);
    },
}
