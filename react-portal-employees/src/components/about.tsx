import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import CssBaseline from '@mui/material/CssBaseline';
import Divider from '@mui/material/Divider';
import Drawer from '@mui/material/Drawer';
import IconButton from '@mui/material/IconButton';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import MenuIcon from '@mui/icons-material/Menu';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Avatar from '@mui/material/Avatar';
import FolderIcon from '@mui/icons-material/Folder';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import PersonIcon from '@mui/icons-material/Person';
import Select from '@mui/material/Select';
import { FormControl, InputLabel, MenuItem } from '@mui/material';



const drawerWidth = 240;

interface Props {
    /**
     * Injected by the documentation to work in an iframe.
     * You won't need it on your project.
     */
    window?: () => Window;
}

export default function ResponsiveDrawer(props: Props) {
    const { window } = props;
    const [mobileOpen, setMobileOpen] = React.useState(false);

    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    const drawer = (
        <div>
            <Toolbar />
            <Avatar
                sx={{
                    width: 100, height: 100,
                    marginBlock: 3,
                    marginLeft: 10,
                }}>H</Avatar>
            <Divider />
            <List>
                {['Name', 'Surname', 'Years in company', 'Position in company'].map((text, index) => (
                    <ListItem key={text} disablePadding>
                        <ListItemButton>
                            <ListItemIcon>
                                {index % 2 === 0 ? <PersonIcon /> : <PersonIcon />}
                            </ListItemIcon>
                            <ListItemText primary={text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>
            <Divider />
            <List>
                {['Current self-assestments', 'Previous self-assetments', 'Return'].map((text, index) => (
                    <ListItem key={text} disablePadding>
                        <ListItemButton>
                            <ListItemIcon>
                                {index % 2 === 0 ? <FolderIcon /> : <FolderIcon />}
                            </ListItemIcon>
                            <ListItemText primary={text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>
        </div>
    );

    const container = window !== undefined ? () => window().document.body : undefined;

    return (
        <Box sx={{ display: 'flex' }}>
            <CssBaseline />
            <AppBar
                position="fixed"
                sx={{
                    width: { sm: `calc(100% - ${drawerWidth}px)` },
                    ml: { sm: `${drawerWidth}px` },
                }}
            >
                <Toolbar>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        edge="start"
                        onClick={handleDrawerToggle}
                        sx={{ mr: 2, display: { sm: 'none' } }}
                    >
                        <MenuIcon />
                    </IconButton>
                    <Typography variant="h6" noWrap component="div"
                        sx={{
                            color: 'white',
                        }} >
                        Evaluation
                    </Typography>
                </Toolbar>
            </AppBar>
            <Box
                component="nav"
                sx={{ width: { sm: drawerWidth }, flexShrink: { sm: 0 } }}
                aria-label="mailbox folders"
            >
                {/* The implementation can be swapped with js to avoid SEO duplication of links. */}
                <Drawer
                    container={container}
                    variant="temporary"
                    open={mobileOpen}
                    onClose={handleDrawerToggle}
                    ModalProps={{
                        keepMounted: true, // Better open performance on mobile.
                    }}
                    sx={{
                        display: { xs: 'block', sm: 'none' },
                        '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
                    }}
                >
                    {drawer}
                </Drawer>
                <Drawer
                    variant="permanent"
                    sx={{
                        display: { xs: 'none', sm: 'block' },
                        '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
                    }}
                    open
                >
                    {drawer}
                </Drawer>
            </Box>
            <Box
                component="main"
                sx={{ flexGrow: 1, p: 3, width: { sm: `calc(100% - ${drawerWidth}px)` } }}
            >
                <Toolbar />
                <Typography>
                    Soft Skills
                    </Typography>
                
                <FormGroup>
                    <FormControl fullWidth sx={{
                        marginBlock: 2,
                    }} >
                        <InputLabel id="demo-simple-select-label">English Level</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            label="C#"
                        >
                            <MenuItem value={10}>A1</MenuItem>
                            <MenuItem value={20}>A2</MenuItem>
                            <MenuItem value={30}>B1</MenuItem>
                            <MenuItem value={40}>B2</MenuItem>
                            <MenuItem value={50}>C1</MenuItem>
                            <MenuItem value={60}>C2</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl fullWidth sx={{
                        marginBlock: 2,
                    }}>
                        <InputLabel id="demo-simple-select-label">Leadership</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            label="Leadership">
                            <MenuItem value={10}>Novice</MenuItem>
                            <MenuItem value={20}>Advanced Beginner</MenuItem>
                            <MenuItem value={30}>Competent</MenuItem>
                            <MenuItem value={40}>Proficient</MenuItem>
                            <MenuItem value={50}>Expert</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl fullWidth sx={{
                        marginBlock: 2,
                    }}>
                        <InputLabel id="demo-simple-select-label">Communication Skills</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            label="Communication">
                            <MenuItem value={10}>Novice</MenuItem>
                            <MenuItem value={20}>Advanced Beginner</MenuItem>
                            <MenuItem value={30}>Competent</MenuItem>
                            <MenuItem value={40}>Proficient</MenuItem>
                            <MenuItem value={50}>Expert</MenuItem>
                        </Select>
                    </FormControl>
                </FormGroup>

                <Typography>
                    Hard Skills
                </Typography>

                <FormGroup>
                    <FormControl fullWidth sx={{
                        marginBlock: 2,
                    }}>
                        <InputLabel id="demo-simple-select-label">C#</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            label="C#">
                            <MenuItem value={10}>Novice</MenuItem>
                            <MenuItem value={20}>Advanced Beginner</MenuItem>
                            <MenuItem value={30}>Competent</MenuItem>
                            <MenuItem value={40}>Proficient</MenuItem>
                            <MenuItem value={50}>Expert</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl fullWidth sx={{
                        marginBlock: 2,
                    }}>
                        <InputLabel id="demo-simple-select-label">SQL</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            label="SQL">
                            <MenuItem value={10}>Novice</MenuItem>
                            <MenuItem value={20}>Advanced Beginner</MenuItem>
                            <MenuItem value={30}>Competent</MenuItem>
                            <MenuItem value={40}>Proficient</MenuItem>
                            <MenuItem value={50}>Expert</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl fullWidth sx={{
                        marginBlock: 2,
                    }}>
                        <InputLabel id="demo-simple-select-label">React</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            label="React">
                            <MenuItem value={10}>Novice</MenuItem>
                            <MenuItem value={20}>Advanced Beginner</MenuItem>
                            <MenuItem value={30}>Competent</MenuItem>
                            <MenuItem value={40}>Proficient</MenuItem>
                            <MenuItem value={50}>Expert</MenuItem>
                        </Select>
                    </FormControl>
                </FormGroup>
            </Box>
        </Box>
    );
}

function setValue(newValue: number) {
    throw new Error('Function not implemented.');
}
