import React from "react";
import { Routes, Route, Link } from "react-router-dom";

import MenuContainer from "./menu/menuContainer";

import Home from "./home";
import About from "./about";
import Contact from "./contact";
import SignUp from "./signUp";
import SignIn from "./signIn";
import EmployeesTable from "./employees";

import IconButton from "@mui/material/IconButton";
import Container from "@mui/material/Container";
import MenuItem from "@mui/material/MenuItem";
import Toolbar from "@mui/material/Toolbar";

import AppBar from "@mui/material/AppBar";
import Button from "@mui/material/Button";
import Menu from "@mui/material/Menu";
import Box from "@mui/material/Box";

import MenuIcon from "@mui/icons-material/Menu";

import { ThemeProvider, createTheme } from "@mui/material/styles";

const theme = createTheme({
  palette: {
    primary: {
      main: "#2B3139",
    },
    secondary: {
      main: "#ffffff",
    },
  },
});

const NavBar = () => {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(
    null
  );

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  return (
    <div>
      <ThemeProvider theme={theme}>
        <AppBar position="static" color="primary">
          <Container maxWidth="xl">
            <Toolbar disableGutters>
              <Box sx={{ flexGrow: 1, display: { xs: "flex", sm: "none" } }}>
                <IconButton
                  size="large"
                  aria-label="account of current user"
                  aria-controls="menu-appbar"
                  aria-haspopup="true"
                  onClick={handleOpenNavMenu}
                  color="secondary"
                >
                  <MenuIcon />
                </IconButton>
                <Menu
                  sx={{
                    display: { xs: "block", sm: "none" },
                    mt: "45px",
                  }}
                  id="menu-navbar"
                  anchorEl={anchorElNav}
                  anchorOrigin={{
                    vertical: "top",
                    horizontal: "left",
                  }}
                  keepMounted
                  transformOrigin={{
                    vertical: "top",
                    horizontal: "left",
                  }}
                  open={Boolean(anchorElNav)}
                  onClose={handleCloseNavMenu}
                >
                  <MenuItem key="Home" onClick={handleCloseNavMenu}>
                    <Link to="/" style={{ color: "#000" }}>
                      Home
                    </Link>
                  </MenuItem>
                  <MenuItem key="About Us" onClick={handleCloseNavMenu}>
                    <Link to="/about" style={{ color: "#000" }}>
                      About Us
                    </Link>
                  </MenuItem>
                  <MenuItem key="Contact Us" onClick={handleCloseNavMenu}>
                    <Link to="/contact" style={{ color: "#000" }}>
                      Contact Us
                    </Link>
                  </MenuItem>
                </Menu>
              </Box>

              <Box sx={{ flexGrow: 1, display: { xs: "none", sm: "flex" } }}>
                <MenuItem key="Home" onClick={handleCloseNavMenu}>
                  <Link to="/">
                    <Button color="secondary">Home</Button>
                  </Link>
                </MenuItem>
                <MenuItem key="About Us" onClick={handleCloseNavMenu}>
                  <Link to="/about">
                    <Button color="secondary">About Us</Button>
                  </Link>
                </MenuItem>
                <MenuItem key="Contact Us" onClick={handleCloseNavMenu}>
                  <Link to="/contact">
                    <Button color="secondary">Contact Us</Button>
                  </Link>
                </MenuItem>
              </Box>
              <MenuContainer />
            </Toolbar>
          </Container>
        </AppBar>
      </ThemeProvider>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/signin" element={<SignIn />} />
        <Route path="/signup" element={<SignUp />} />
        <Route path="/employees" element={<EmployeesTable />} />
      </Routes>
    </div>
  );
};
export default NavBar;
