import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:7147/api/",
  responseType: "json",
});
