import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { styled, useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import MuiDrawer from '@mui/material/Drawer';
import MuiAppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import CssBaseline from '@mui/material/CssBaseline';
import Divider from '@mui/material/Divider';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import DashboardIcon from '@mui/icons-material/Dashboard';

export default function Links() {



    return (
        <Box sx={{ display: 'flex' }}>
            <CssBaseline />

            <Divider />
            <List>
                {/*<ListItem disablePadding sx={{ display: 'block' }}>*/}
                {/*    <ListItemButton*/}
                {/*        component={Link}*/}
                {/*        to="/"*/}
                {/*        sx={{*/}
                {/*            minHeight: 48,*/}
                {/*            justifyContent: 'flex-start',*/}
                {/*            px: 2.5,*/}
                {/*            width: '100%',*/}
                {/*            '&.active': {*/}
                {/*                background: 'rgba(0, 0, 0, 0.1)',*/}
                {/*            },*/}
                {/*        }}>*/}
                {/*        <ListItemIcon>*/}
                {/*            <InboxIcon />*/}
                {/*        </ListItemIcon>*/}
                {/*        <ListItemText primary="Home" />*/}
                {/*    </ListItemButton>*/}
                {/*</ListItem>*/}

                <ListItem disablePadding sx={{ display: 'block' }}>
                    <ListItemButton
                        component={Link}
                        to="/dashboard"
                        sx={{
                            minHeight: 48,
                            justifyContent: 'flex-start',
                            px: 2.5,
                            width: '100%',
                            '&.active': {
                                background: 'rgba(0, 0, 0, 0.1)',
                            },
                        }}>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="Dashboard" />
                    </ListItemButton>
                </ListItem>

                <ListItem disablePadding sx={{ display: 'block' }}>
                    <ListItemButton
                        component={Link}
                        to="/crm"
                        sx={{
                            minHeight: 48,
                            justifyContent: 'flex-start',
                            px: 2.5,
                            width: '100%',
                            '&.active': {
                                background: 'rgba(0, 0, 0, 0.1)',
                            },
                        }}>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="CRM" />
                    </ListItemButton>
                </ListItem>

                <ListItem disablePadding sx={{ display: 'block' }}>
                    <ListItemButton
                        component={Link}
                        to="/documents"
                        sx={{
                            minHeight: 48,
                            justifyContent: 'flex-start',
                            px: 2.5,
                            width: '100%',
                            '&.active': {
                                background: 'rgba(0, 0, 0, 0.1)',
                            },
                        }}>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="Documents" />
                    </ListItemButton>
                </ListItem>

                <ListItem disablePadding sx={{ display: 'block' }}>
                    <ListItemButton
                        component={Link}
                        to="/employees"
                        sx={{
                            minHeight: 48,
                            justifyContent: 'flex-start',
                            px: 2.5,
                            width: '100%',
                            '&.active': {
                                background: 'rgba(0, 0, 0, 0.1)',
                            },
                        }}>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="Employees" />
                    </ListItemButton>
                </ListItem>

                <ListItem disablePadding sx={{ display: 'block' }}>
                    <ListItemButton
                        component={Link}
                        to="/hr"
                        sx={{
                            minHeight: 48,
                            justifyContent: 'flex-start',
                            px: 2.5,
                            width: '100%',
                            '&.active': {
                                background: 'rgba(0, 0, 0, 0.1)',
                            },
                        }}>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="HR" />
                    </ListItemButton>
                </ListItem>

                <ListItem disablePadding sx={{ display: 'block' }}>
                    <ListItemButton
                        component={Link}
                        to="/projects"
                        sx={{
                            minHeight: 48,
                            justifyContent: 'flex-start',
                            px: 2.5,
                            width: '100%',
                            '&.active': {
                                background: 'rgba(0, 0, 0, 0.1)',
                            },
                        }}>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="Projects" />
                    </ListItemButton>
                </ListItem>

                <ListItem disablePadding sx={{ display: 'block' }}>
                    <ListItemButton
                        component={Link}
                        to="/transactions"
                        sx={{
                            minHeight: 48,
                            justifyContent: 'flex-start',
                            px: 2.5,
                            width: '100%',
                            '&.active': {
                                background: 'rgba(0, 0, 0, 0.1)',
                            },
                        }}>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="Transactions" />
                    </ListItemButton>
                </ListItem>
            </List>
        </Box>
    );
}

