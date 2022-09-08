import React from "react";
import { Link } from "react-router-dom";

import MenuItem from "@mui/material/MenuItem";
import Tooltip from "@mui/material/Tooltip";
import Menu from "@mui/material/Menu";
import Box from "@mui/material/Box";

import ConstructionIcon from "@mui/icons-material/Construction";
import IconButton from "@mui/material/IconButton";

function MenuAdmin() {
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(
    null
  );

  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  return (
    <Box sx={{ flexGrow: 0, display: "flex" }}>
      <Tooltip title="Open settings" color="secondary">
        <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
          <ConstructionIcon fontSize="large" />
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
        <MenuItem key="Item 1" onClick={handleCloseUserMenu}>
          <Link to="#" style={{ color: "#000" }}>
            Item 1
          </Link>
        </MenuItem>
        <MenuItem key="Item2" onClick={handleCloseUserMenu}>
          <Link to="#" style={{ color: "#000" }}>
            Item 2
          </Link>
        </MenuItem>
      </Menu>
    </Box>
  );
}

export default MenuAdmin;
