import API from "../ApiConfig";
import Cookies from "js-cookie";

export async function AuthRequest(data) {
  const response = await API.post("/Login", {
    username: data.get("username"),
    password: data.get("password"),
  }).catch((error) => {
    return false;
  });

  if (response.status === 200) {
    if (data.get("remember") != null) {
      Cookies.set("user_session", encodeURIComponent(response.data), {
        expires: 365,
      });
    } else {
      Cookies.set("user_session", encodeURIComponent(response.data));
    }
    return true;
  }
  return false;
}

export async function RefreshToken() {
  let response = await API.post(
    `/Login/RefreshToken?oldToken=${Cookies.get("user_session")}`
  ).catch((error) => {
    return false;
  });

  if (response.status === 200) {
    Cookies.set("user_session", response.data);
    return true;
  }
  return false;
}
