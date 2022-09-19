import API from "../ApiConfig";
import Cookies from "js-cookie";

export async function GetRole() {
  let response = await API.get("/UserInfo/GetUserRole", {
    headers: {
      Authorization: `Bearer ${Cookies.get("user_session")}`,
    },
  }).catch((error) => {
    return "";
  });

  if (response.status === 200) {
    return response.data;
  }
  return "";
}

export async function GetUserColleagues() {
  let response = await API.get("/UserInfo/GetUserColleagues", {
    headers: {
      Authorization: `Bearer ${Cookies.get("user_session")}`,
    },
  }).catch((error) => {
    return "";
  });

  if (response.status === 200) {
    return response.data;
  }
  return "";
}

export async function GetEmployeeProfile(id) {
  let response = await API.get(`/UserInfo/GetEmployeeProfile?targetId=${id}`, {
    headers: {
      Authorization: `Bearer ${Cookies.get("user_session")}`,
    },
  }).catch((error) => {
    return "";
  });

  if (response.status === 200) {
    return response.data;
  }
  return "";
}