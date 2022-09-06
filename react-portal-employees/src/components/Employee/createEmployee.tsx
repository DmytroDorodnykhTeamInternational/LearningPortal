import React, { useState } from 'react';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import Typography from '@mui/material/Typography';
import InputLabel from '@mui/material/InputLabel';
import NativeSelect from '@mui/material/NativeSelect';
import Container from '@mui/material/Container';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';

import ApiEmployee from '../../services/api/TasksEmployee/ApiEmployee';

const theme = createTheme();

export default function CreateEmployee() {
    const [input, setInput] = useState({
      username: '',
      password: '',
      confirmPassword: '',
      email: '',
      FirstName: '',
      LastName: '',
      DateOfBirth: '',
      Seniority:''
    });
    const [error, setError] = useState({
      username: '',
      password: '',
      confirmPassword: '',
      email: '',
      FirstName: '',
      LastName: '',
      DateOfBirth: '',
      Seniority:''
    })   

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
      event.preventDefault();
      let MsgEr = "";
      Object.entries(error).forEach(
        ([key, value]) => {
          if (value != "") MsgEr = value;
        }
      );

      if (MsgEr != ""){
        alert(MsgEr);
        return
      } 
      
      const data = new FormData(event.currentTarget);
      var json = {
        UserName: data.get('username'),
        EmailAddress: data.get('email'),
        Password: data.get('password'),
        FirstName: data.get('FirstName'),
        LastName: data.get('LastName'),
        DateOfBirth: data.get('DateOfBirth'),
        Seniority: Number(data.get('Seniority')),
        Role: Number(data.get('Role'))
      };
      ApiEmployee.CreateEmployee(json);      
    };

    const checkValidation = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => {
      const { name, value } = e.target;
      setInput(prev => ({
        ...prev,
        [name]: value
      }));
      validateInput(e);
    };

    const validateInput = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => {
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
            } else if (input.confirmPassword && value !== input.confirmPassword) {
              stateObj["confirmPassword"] = "Password and Confirm Password does not match.";
            } else {
              stateObj["confirmPassword"] = input.confirmPassword ? "" : error.confirmPassword;
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
    }

    return (
      <ThemeProvider theme={theme}>
        <Container component="main" maxWidth="xs">
          <CssBaseline />
          <Box
            sx={{
              marginTop: 8,
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center'
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
                id="FirstName"
                label="First Name"
                name="FirstName"
                autoComplete="FirstName"
                onChange={e => checkValidation(e)}
                error={!!error?.FirstName}
                helperText={error.FirstName}
              />
              <TextField
                margin="normal"
                autoFocus
                required
                fullWidth
                id="LastName"
                label="Last Name"
                name="LastName"
                autoComplete="LastName"
                onChange={e => checkValidation(e)}
                error={!!error?.LastName}
                helperText={error.LastName}
              />
              <TextField
                margin="normal"
                autoFocus
                required
                fullWidth
                id="DateOfBirth"
                name="DateOfBirth"
                autoComplete="DateOfBirth"
                type="Date"
                onChange={e => checkValidation(e)}
                error={!!error?.DateOfBirth}
                helperText={error.DateOfBirth}
              />
              <InputLabel htmlFor="Seniority">Seniority</InputLabel>
              <NativeSelect id="Seniority" name="Seniority" fullWidth required autoFocus>
                <option value="0">Junior</option>
                <option value="1">Mid Level</option>
                <option value="2">Senior</option>
              </NativeSelect>
              <InputLabel htmlFor="Role">Role</InputLabel>
              <NativeSelect id="Role" name="Role" fullWidth required autoFocus>
                <option value="0">Employee</option>
                <option value="1">Team lead</option>
                <option value="2">Admin</option>
              </NativeSelect>
              <TextField
                margin="normal"
                autoFocus
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
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
                id="UserName"
                label="User Name"
                name="username"
                autoComplete="UserName"
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
  