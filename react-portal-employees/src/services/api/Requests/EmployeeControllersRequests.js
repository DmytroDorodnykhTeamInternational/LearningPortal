import API from "../ApiConfig";
import Cookies from "js-cookie";

export async function GetEmployees() {
  let response = await API.get("/Employee", {
    headers: {
      Authorization: `Bearer ${Cookies.get("user_session")}`,
    },
  }).catch((error) => {
    return [];
  });

  if (response.status === 200) {
    return response.data;
  }
  return [];
}
