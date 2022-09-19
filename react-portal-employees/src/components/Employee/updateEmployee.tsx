import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

import { createTheme, ThemeProvider } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";
import Typography from "@mui/material/Typography";
import InputLabel from "@mui/material/InputLabel";
import NativeSelect from "@mui/material/NativeSelect";
import Container from "@mui/material/Container";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";
import dayjs, { Dayjs } from "dayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";

import { EditEmployee } from "../../services/api/Requests/EmployeeControllersRequests";
import { GetEmployeeProfile } from "../../services/api/Requests/UserInfoControllerRequests";
import { RefreshToken } from "../../services/api/Requests/LoginControllersRequests";
import { useJwt } from "react-jwt";
import Cookies from "js-cookie";

const theme = createTheme();

export default function UpdateEmployee() {
  console.log(window.location.href.split("/").pop());
  const [input, setInput] = useState({
    username: "",
    emailAddress: "",
    password: "",
    firstName: "",
    lastName: "",
    seniority: -1,
    role: -1
  });

  const [date, setDate] = React.useState<Dayjs | null>(
    dayjs(),
  );

  const [ConfirmPwd, setConfirmPwd] = useState("");
  const [error, setError] = useState({
    username: "",
    password: "",
    confirmPassword: "",
    email: "",
    firstName: "",
    lastName: "",
    dateOfBirth: ""
  });
  const enumSeniority = {
    junior: 0,
    midLivel: 1,
    senior: 2
  } as const;
  const enumRole = {
    employee: 0,
    teamLead: 1,
    admin: 2
  } as const;

  let navigate = useNavigate();
  
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
    EditEmployee(window.location.href.split("/").pop(), input, date);
    navigate("/employees", { replace: true });
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
        } else if (value.length < 7) {
          stateObj[name] = "Password must be at least 7 characters long.";
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
        }else if((/^[\w-\.]+@([\w-]+\.)+[\w-]{1,1}$/).test(value)){
          stateObj[name] = "Please enter valid email.";
        }
        break;

      case "firstName":
        if (!value) {
          stateObj[name] = "Please enter first name.";
        }
        break;

      case "lastName":
        if (!value) {
          stateObj[name] = "Please enter last name.";
        }
        break;

      case "dateOfBirth":
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

  const handleChange = (newValue: Dayjs | null) => {
    if (newValue != null) {
      var timeOffsetInMS:number = newValue.toDate().getTimezoneOffset() * 60000;
      setDate(dayjs(new Date().setTime(newValue.toDate().getTime() - timeOffsetInMS)));
    }
    else {
      setDate(dayjs(new Date().setTime(0)));
    }
  };

  const { decodedToken, isExpired, reEvaluateToken } = useJwt(
    Cookies.get("user_session")
  );

  useEffect(() => {
    const refreshToken = async () => {
      let isSuccessfully = await RefreshToken();
      if (isSuccessfully) {
        reEvaluateToken(Cookies.get("user_session"));
      }
    };

    const getEmployee = async () => {
      let employee = await GetEmployeeProfile(window.location.href.split("/").pop());
      if (employee) {
        setInput({
          username: employee.username,
          emailAddress:employee.emailAddress,
          password: "",
          firstName: employee.firstName,
          lastName: employee.lastName,
          seniority: employee.seniority,
          role: employee.role
        }); 
        setDate(employee.dateOfBirth);
      }
    };

    if (decodedToken) {
      if (isExpired) {
        refreshToken();
      }
      getEmployee();
    }
  }, [decodedToken, isExpired]);

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
              Update Employee
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
              value={input.firstName}
              onChange={e => checkValidation(e)}
              error={!!error?.firstName}
              helperText={error.firstName}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              id="lastName"
              label="Last Name"
              name="lastName"
              autoComplete="lastName"
              value={input.lastName}
              onChange={e => checkValidation(e)}
              error={!!error?.lastName}
              helperText={error.lastName}
            />
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DesktopDatePicker
                label="Date of Birth"
                inputFormat="MM/DD/YYYY"
                value={date}
                onChange={handleChange}
                renderInput={(params) => 
                  <TextField {...params} 
                    margin="normal"
                    fullWidth
                    id="dateOfBirth"
                    name="dateOfBirth"
                    autoComplete="dateOfBirth" 
                  />}
              />
            </LocalizationProvider>
            <InputLabel htmlFor="seniority">Seniority</InputLabel>
            <NativeSelect id="seniority" name="seniority" fullWidth required onChange={e => checkValidation(e)} value={input.seniority}>
              <option value=""></option>
              <option value={enumSeniority.junior}>Junior</option>
              <option value={enumSeniority.midLivel}>Mid Level</option>
              <option value={enumSeniority.senior}>Senior</option>
            </NativeSelect>
            <InputLabel htmlFor="role">Role</InputLabel>
            <NativeSelect id="role" name="role" fullWidth required onChange={e => checkValidation(e)} value={input.role}>
              <option value=""></option>
              <option value={enumRole.employee}>Employee</option>
              <option value={enumRole.teamLead}>Team lead</option>
              <option value={enumRole.admin}>Admin</option>
            </NativeSelect>
            <TextField
              margin="normal"
              required
              fullWidth
              id="email"
              label="Email Address"
              name="emailAddress"
              autoComplete="email"
              type="text"
              value={input.emailAddress}
              onChange={e => checkValidation(e)}
              error={!!error?.email}
              helperText={error.email}
            />
            <TextField
              margin="normal"
              fullWidth
              id="userName"
              label="User Name"
              name="username"
              autoComplete="userName"
              value={input.username}
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
