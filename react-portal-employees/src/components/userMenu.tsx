import React, { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";

import { RefreshToken } from "../services/api/ApiRequests";
import { useJwt } from "react-jwt";
import Cookies from "js-cookie";

import IconButton from "@mui/material/IconButton";
import MenuItem from "@mui/material/MenuItem";
import Tooltip from "@mui/material/Tooltip";
import Button from "@mui/material/Button";
import Menu from "@mui/material/Menu";
import Box from "@mui/material/Box";

import AccountCircle from "@mui/icons-material/AccountCircle";
import LoginIcon from "@mui/icons-material/Login";

function UserMenu() {
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(
    null
  );

  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  let navigate = useNavigate();
  const handleLogoutUserMenu = () => {
    localStorage.removeItem("user_session");
    Cookies.remove("user_session");
    navigate("/signin");
    setAnchorElUser(null);
  };

  const { decodedToken, isExpired, reEvaluateToken } = useJwt(
    Cookies.get("user_session")
  );

  useEffect(() => {
    const refreshToken = async () => {
      var isSuccessfully = RefreshToken();
      if (isSuccessfully) {
        reEvaluateToken(Cookies.get("user_session"));
      }
    };
    if (decodedToken) {
      if (isExpired) {
        refreshToken();
      }
    }
  });

  var isValid;
  if (decodedToken) {
    isValid = true;
  } else {
    isValid = false;
  }

  return isValid ? (
    <Box sx={{ flexGrow: 0, display: "flex" }}>
      <Tooltip title="Open settings" color="secondary">
        <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
          <AccountCircle fontSize="large" />
        </IconButton>
      </Tooltip>
      <Menu
        sx={{ mt: "45px" }}
        id="menu-userbar"
        anchorEl={anchorElUser}
        anchorOrigin={{
          vertical: "top",
          horizontal: "right",
        }}
        keepMounted
        transformOrigin={{
          vertical: "top",
          horizontal: "right",
        }}
        open={Boolean(anchorElUser)}
        onClose={handleCloseUserMenu}
      >
        <MenuItem key="Profile" onClick={handleCloseUserMenu}>
          <Link to="#" style={{ color: "#000" }}>
            Profile
          </Link>
        </MenuItem>
        <MenuItem key="Colleagues" onClick={handleCloseUserMenu}>
          <Link to="#" style={{ color: "#000" }}>
            Colleagues
          </Link>
        </MenuItem>
        <MenuItem key="Logout" onClick={handleLogoutUserMenu}>
          <Link to="/signin" style={{ color: "#000" }}>
            Logout
          </Link>
        </MenuItem>
      </Menu>
    </Box>
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

export default UserMenu;
