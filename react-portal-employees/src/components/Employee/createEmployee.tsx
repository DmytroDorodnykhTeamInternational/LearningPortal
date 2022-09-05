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
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
      event.preventDefault();
      const data = new FormData(event.currentTarget);
      var json = {
        UserName: data.get('UserName'),
        EmailAddress: data.get('email'),
        Password: data.get('password'),
        FirstName: data.get('FirstName'),
        LastName: data.get('LastName'),
        DateOfBirth: data.get('DateOfBirth'),
        Seniority: 1,
        Role: 1
      };
      ApiEmployee.CreateEmployee(json);      
      console.log(JSON.stringify(json));
    };

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
              />
              <InputLabel htmlFor="Seniority">Seniority</InputLabel>
              <NativeSelect id="Seniority" fullWidth required autoFocus>
                <option value="0">Junior</option>
                <option value="1">Mid Level</option>
                <option value="2">Senior</option>
              </NativeSelect>
              <InputLabel htmlFor="Role">Role</InputLabel>
              <NativeSelect id="Role" fullWidth required autoFocus>
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
              />
              <TextField
                margin="normal"
                autoFocus
                required
                fullWidth
                id="UserName"
                label="User Name"
                name="UserName"
                autoComplete="UserName"
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
              <TextField
                margin="normal"
                required
                fullWidth
                id="Confirmpwd"
                name="Confirmpwd"
                label="Confirm password"
                type="password"
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
  