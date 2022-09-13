import React, { useEffect } from "react";
import { Link } from "react-router-dom";

import MenuAdmin from "./menuAdmin";
import MenuUser from "./menuUser";

import MenuItem from "@mui/material/MenuItem";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";

import LoginIcon from "@mui/icons-material/Login";

import { useAppSelector } from "../../redux/hooks";
import { isValid, isInvalid } from "../../redux/slice/authSlice";
import { visitor, user, admin } from "../../redux/slice/roleSlice";
import { useAppDispatch } from "../../redux/hooks";

import { RefreshToken, GetRole } from "../../services/api/ApiRequests";
import { useJwt } from "react-jwt";
import Cookies from "js-cookie";

function MenuContainer() {
  const { decodedToken, isExpired, reEvaluateToken } = useJwt(
    Cookies.get("user_session")
  );

  const dispatch = useAppDispatch();

  useEffect(() => {
    const refreshToken = async () => {
      let isSuccessfully = await RefreshToken();
      if (isSuccessfully) {
        getRole();
        dispatch(isValid());
        reEvaluateToken(Cookies.get("user_session"));
      } else {
        dispatch(isInvalid());
      }
    };

    const getRole = async () => {
      let data = await GetRole();
      if (data) {
        if ((await data) === "Admin") {
          dispatch(admin());
        } else if ((await data) === "Employee" || (await data) === "Teamlead") {
          dispatch(user());
        } else {
          dispatch(visitor());
        }
      } else {
        dispatch(visitor());
      }
    };

    if (decodedToken) {
      if (isExpired) {
        refreshToken();
      } else {
        dispatch(isValid());
      }
      getRole();
    } else {
      dispatch(isInvalid());
    }
  });

  const isAuth = useAppSelector((state) => state.isAuth.value);
  const role = useAppSelector((state) => state.role.value!);

  return isAuth ? (
    role === "Admin" ? (
      <Box
        sx={{ display: "flex", flexGrow: 0.05, justifyContent: "space-around" }}
      >
        <MenuUser />
        <MenuAdmin />
      </Box>
    ) : (
      <MenuUser />
    )
  ) : (
    <Box sx={{ flexGrow: 0, display: "flex" }}>
      <MenuItem key="Login">
        <Link to="/signin">
          <Button variant="outlined" color="secondary">
            <LoginIcon />
            &nbsp;Sign In
          </Button>
        </Link>
      </MenuItem>
      <MenuItem key="Register">
        <Link to="/signup">
          <Button variant="outlined" color="secondary">
            Sign Up
          </Button>
        </Link>
      </MenuItem>
    </Box>
  );
}

export default MenuContainer;
