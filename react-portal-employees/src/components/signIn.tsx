import * as React from "react";
import { Link, useNavigate } from "react-router-dom";

import { createTheme, ThemeProvider } from "@mui/material/styles";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormHelperText from "@mui/material/FormHelperText";
import CssBaseline from "@mui/material/CssBaseline";
import Typography from "@mui/material/Typography";
import AlertTitle from "@mui/material/AlertTitle";
import Container from "@mui/material/Container";
import TextField from "@mui/material/TextField";
import Checkbox from "@mui/material/Checkbox";
import Button from "@mui/material/Button";
import Avatar from "@mui/material/Avatar";
import Alert from "@mui/material/Alert";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";

// import TokenValidate from "../services/tokenValidate";
import { AuthRequest } from "../services/api/ApiRequests";
import { GetRole } from "../services/api/ApiRequests";
import { isValid, isInvalid } from "../redux/slice/authSlice";
import { visitor, user, admin } from "../redux/slice/roleSlice";
import { useAppDispatch } from "./../redux/hooks";

const theme = createTheme();

export default function SignIn() {
  const [errorText, setErrorText] = React.useState("");

  let navigate = useNavigate();

  const dispatch = useAppDispatch();

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    var isSuccessfully = await AuthRequest(data);
    if (isSuccessfully === true) {
      // TokenValidate();
      dispatch(isValid());
      let data = GetRole();
      if (data) {
        if ((await data) === "Admin") {
          dispatch(admin());
        } else if ((await data) === "Employee" || (await data) === "Teamlead") {
          dispatch(user());
        } else {
          dispatch(visitor());
        }
      }
      navigate("/", { replace: true });
    } else {
      dispatch(isInvalid());
      setErrorText("Wrong username or password!");
    }
  };

  return (
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign in
          </Typography>
          <Box component="form" onSubmit={handleSubmit} sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              autoFocus
              required
              fullWidth
              id="username"
              label="Username"
              name="username"
              autoComplete="username"
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="password"
              name="password"
              label="Password"
              autoComplete="current-password"
              type="password"
            />
            <FormControlLabel
              control={
                <Checkbox
                  value="remember"
                  id="remember"
                  name="remember"
                  color="primary"
                />
              }
              label="Remember me"
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign In
            </Button>
            <Grid container>
              <Grid item xs>
                <Link to="#">{"Forgot password?"}</Link>
              </Grid>
              <Grid item>
                <Link to="/signup">{"Don't have an account? Sign Up"}</Link>
              </Grid>
            </Grid>
            {errorText && (
              <FormHelperText error sx={{ mt: 5 }}>
                <Alert severity="error">
                  <AlertTitle>Error</AlertTitle>
                  {errorText}
                </Alert>
              </FormHelperText>
            )}
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
