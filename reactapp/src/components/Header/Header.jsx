import React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Avatar from '@mui/material/Avatar';
import './header.css';


function Header() {
  return (
      <Box className="header">
          <AppBar position='sticky' disablegutters='true'>
              <Toolbar>
                  <Avatar
                      sx={{ width: 40, height: 40 }}
                      alt='edupala profile'
                      src='https://miro.medium.com/max/1400/0*0fClPmIScV5pTLoE.jpg'
                  />
              </Toolbar>
          </AppBar>
      </Box>
  );
}

export default Header;