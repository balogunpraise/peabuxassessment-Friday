import axios from "axios";

export default axios.create({
    baseURL: "http://localhost:5288"
})

axios.defaults.withCredentials = false