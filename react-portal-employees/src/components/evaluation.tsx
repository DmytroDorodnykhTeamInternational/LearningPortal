import * as React from "react";
import Divider from "@mui/material/Divider";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import Toolbar from "@mui/material/Toolbar";
import Avatar from "@mui/material/Avatar";
import FolderIcon from "@mui/icons-material/Folder";
import PersonIcon from "@mui/icons-material/Person";
import Box from "@mui/material/Box";
import { Typography } from "@mui/material";
import Select from "@mui/material/Select";
import FormControl from "@mui/material/FormControl";

function Evaluation() {
  const arr = [
    { value: "C#", text: "C#" },
    { value: "SQL", text: "SQL" },
    { value: "React", text: "React" },
  ];



  return (
    <div>
      <div style={{ width: "300px", float: "left" }}>
        <Toolbar />
        <Avatar
          sx={{
            width: 100,
            height: 100,
            marginBlock: 3,
            marginLeft: 10,
          }}
        >
          H
        </Avatar>
        <Divider />
        <List>
          {["Name", "Surname", "Years in company", "Position in company"].map(
            (text) => (
              <ListItem key={text} disablePadding>
                <ListItemButton>
                  <ListItemIcon>
                    <PersonIcon />
                  </ListItemIcon>
                  <ListItemText primary={text} />
                </ListItemButton>
              </ListItem>
            )
          )}
        </List>
        <Divider />
        <List>
          {["Current self-assestments", "Previous self-assetments"].map(
            (text) => (
              <ListItem key={text} disablePadding>
                <ListItemButton>
                  <ListItemIcon>
                    <FolderIcon />
                  </ListItemIcon>
                  <ListItemText primary={text} />
                </ListItemButton>
              </ListItem>
            )
          )}
        </List>
      </div>
      <div>
        <Box
          style={{
            float: "right",
            width: "1200px",
            height: "100%",
          }}
        >
          <Typography style={{ width: "800px" }}>
            <h1 style={{ textAlign: "center" }}>Evaluation</h1>
          </Typography>
          <FormControl fullWidth>
            
            <Select name="skills" id="skill=select">
              {arr.map((option, index) => (
                <option key={index} value={option.value}>
                  {option.text}
                </option>
              ))}
            </Select>
          </FormControl>
        </Box>
      </div>
    </div>
  );
}

export default Evaluation;
