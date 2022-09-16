import React, { useState } from "react";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";
import Typography from "@mui/material/Typography";
import InputLabel from "@mui/material/InputLabel";
import NativeSelect from "@mui/material/NativeSelect";
import Container from "@mui/material/Container";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";

import { PostEmployee } from "../../services/api/Requests/EmployeeControllersRequests";

const theme = createTheme();
export default function CreateEmployee() {
  const [input, setInput] = useState({
    username: "",
    emailAddress: "",
    password: "",
    firstName: "",
    lastName: "",
    dateOfBirth: "",
    seniority: -1,
    role: -1
  });
  const [ConfirmPwd, setConfirmPwd] = useState("");
  const [error, setError] = useState({
    username: "",
    password: "",
    confirmPassword: "",
    email: "",
    FirstName: "",
    LastName: "",
    DateOfBirth: ""
  });
  const enumSeniority = {
    junior: 0,
    midLevel: 1,
    senior: 2
  } as const;
  const enumRole = {
    employee: 0,
    teamLead: 1,
    admin: 2
  } as const;

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    let MsgEr = "";
    Object.entries(error).forEach(
      ([key, value]) => {
        if (value !== "") MsgEr = value;
      }
    );
    if (MsgEr !== ""){
      alert(MsgEr);
      return;
    } 
    PostEmployee(input);
  };

  const checkValidation = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    if (name === "confirmPassword") { setConfirmPwd(value); }
    else{
      setInput(prev => ({
        ...prev,
        [name]: value
      }));
    }
    validateInput(e);
  };

  const validateInput = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement | HTMLSelectElement>) => {
    let { name, value } = e.target;
    setError(prev => {
      const stateObj = { ...prev, [name]: "" };
   
      switch (name) {
      case "username":
        if (!value) {
          stateObj[name] = "Please enter Username.";
        }
        break;
   
      case "password":
        if (!value) {
          stateObj[name] = "Please enter Password.";
        } else if (ConfirmPwd && value !== ConfirmPwd) {
          stateObj["confirmPassword"] = "Password and Confirm Password does not match.";
        } else {
          stateObj["confirmPassword"] = ConfirmPwd ? "" : error.confirmPassword;
        }
        break;
   
      case "confirmPassword":
        if (!value) {
          stateObj[name] = "Please enter Confirm Password.";
        } else if (input.password && value !== input.password) {
          stateObj[name] = "Password and Confirm Password does not match.";
        }
        break;
          
      case "email":
        if (!value) {
          stateObj[name] = "Please enter email.";
        }else if((/^[\w-.]+@([\w-]+\.)+[\w-]{1,1}$/).test(value)){
          stateObj[name] = "Please enter valid email.";
        }
        break;

      case "FirstName":
        if (!value) {
          stateObj[name] = "Please enter first name.";
        }
        break;

      case "LastName":
        if (!value) {
          stateObj[name] = "Please enter last name.";
        }
        break;

      case "DateOfBirth":
        if (!value) {
          stateObj[name] = "Please enter date.";
        }else if((/\d{2}\/\d{2}\/\d{4}/).test(value)){
          stateObj[name] = "Please enter valid date.";
        }
        break;

      default:
        break;
      }
   
      return stateObj;
    });
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
            alignItems: "center"
          }}>
          <Typography component="h1" variant="h5">
              Create New Employee
          </Typography>
          <form onSubmit={handleSubmit}>
            <TextField
              margin="normal"
              autoFocus
              required
              fullWidth
              id="firstName"
              label="First Name"
              name="firstName"
              autoComplete="firstName"
              onChange={e => checkValidation(e)}
              error={!!error?.FirstName}
              helperText={error.FirstName}
            />
            <TextField
              margin="normal"
              autoFocus
              required
              fullWidth
              id="lastName"
              label="Last Name"
              name="lastName"
              autoComplete="lastName"
              onChange={e => checkValidation(e)}
              error={!!error?.LastName}
              helperText={error.LastName}
            />
            <TextField
              margin="normal"
              autoFocus
              required
              fullWidth
              id="dateOfBirth"
              name="dateOfBirth"
              autoComplete="dateOfBirth"
              type="date"
              onChange={e => checkValidation(e)}
              error={!!error?.DateOfBirth}
              helperText={error.DateOfBirth}
            />
            <InputLabel htmlFor="seniority">Seniority</InputLabel>
            <NativeSelect id="seniority" name="seniority" fullWidth required autoFocus onChange={e => checkValidation(e)}>
              <option value=""></option>
              <option value={enumSeniority.junior}>Junior</option>
              <option value={enumSeniority.midLevel}>Mid Level</option>
              <option value={enumSeniority.senior}>Senior</option>
            </NativeSelect>
            <InputLabel htmlFor="role">Role</InputLabel>
            <NativeSelect id="role" name="role" fullWidth required autoFocus onChange={e => checkValidation(e)}>
              <option value=""></option>
              <option value={enumRole.employee}>Employee</option>
              <option value={enumRole.teamLead}>Team lead</option>
              <option value={enumRole.admin}>Admin</option>
            </NativeSelect>
            <TextField
              margin="normal"
              autoFocus
              required
              fullWidth
              id="email"
              label="Email Address"
              name="emailAddress"
              autoComplete="email"
              type="text"
              onChange={e => checkValidation(e)}
              error={!!error?.email}
              helperText={error.email}
            />
            <TextField
              margin="normal"
              autoFocus
              fullWidth
              id="userName"
              label="User Name"
              name="username"
              autoComplete="userName"
              onChange={e => checkValidation(e)}
              error={!!error?.username}
              helperText={error.username}
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
              onChange={e => checkValidation(e)}
              error={!!error?.password}
              helperText={error.password}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="confirmPassword"
              name="confirmPassword"
              label="Confirm password"
              type="password"
              onChange={e => checkValidation(e)}
              error={!!error?.confirmPassword}
              helperText={error.confirmPassword}
            />
            <Button type="submit" fullWidth color="primary" variant="contained" sx={{ mt: 3, mb: 2 }}>
                Save
            </Button>
          </form>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
  