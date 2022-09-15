import React from "react";
import { Link } from "react-router-dom";

import Cookies from "js-cookie";

import MenuItem from "@mui/material/MenuItem";
import Tooltip from "@mui/material/Tooltip";
import Menu from "@mui/material/Menu";
import Box from "@mui/material/Box";

import AccountCircle from "@mui/icons-material/AccountCircle";
import IconButton from "@mui/material/IconButton";

import { isInvalid } from "../../redux/slice/authSlice";
import { visitor } from "../../redux/slice/roleSlice";
import { useAppDispatch } from "../../redux/hooks";

function MenuUser() {
  const dispatch = useAppDispatch();

  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(
    null
  );

  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const handleLogoutUserMenu = () => {
    Cookies.remove("user_session");
    dispatch(isInvalid());
    dispatch(visitor());
    setAnchorElUser(null);
  };

  return (
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
        <MenuItem key="Colleagues" onClick={handleCloseUserMenu}>
          <Link to="/colleagues" style={{ color: "#000" }}>
            Colleagues
          </Link>
        </MenuItem>
        <MenuItem key="Item2" onClick={handleCloseUserMenu}>
          <Link to="#" style={{ color: "#000" }}>
            Item 2
          </Link>
        </MenuItem>
        <MenuItem key="Logout" onClick={handleLogoutUserMenu}>
          <Link to="/signin" style={{ color: "#000" }}>
            Logout
          </Link>
        </MenuItem>
      </Menu>
    </Box>
  );
}

export default MenuUser;
