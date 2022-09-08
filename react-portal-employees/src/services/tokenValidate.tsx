import { isValid, isInvalid } from "../redux/slice/authSlice";
import { useAppDispatch } from "./../redux/hooks";
import { RefreshToken } from "./api/ApiRequests";
import { useJwt } from "react-jwt";
import Cookies from "js-cookie";

export default async function tokenValidate() {
  console.log("TokenValidate -init-");
  const { decodedToken, isExpired, reEvaluateToken } = useJwt(
    Cookies.get("user_session") || ""
  );
  console.log("TokenValidate -get JWT token-");

  const dispatch = useAppDispatch();

  if (decodedToken === true) {
    if (isExpired === false) {
      dispatch(isValid());
    } else {
      let isSuccessfully = RefreshToken();
      if ((await isSuccessfully) === true) {
        reEvaluateToken(Cookies.get("user_session") || "");
        dispatch(isValid());
      } else {
        dispatch(isInvalid());
      }
    }
  } else {
    dispatch(isInvalid());
  }
}
