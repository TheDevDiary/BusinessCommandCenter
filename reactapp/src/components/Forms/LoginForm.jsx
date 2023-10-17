import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { Link } from 'react-router-dom';
import './styles.css';

const Login = () => {
    const history = useNavigate();
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleUsernameChange = (e) => {
        setUsername(e.target.value);
    };

    const handlePasswordChange = (e) => {
        setPassword(e.target.value);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const loginRequest = {
            username: username,
            password: password
        };

        try {
            const response = await fetch('https://localhost:7047/api/User/Login', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(loginRequest)
            });

            if (response.ok) {
                const token = await response.text();
                console.log('Login successful. Token:', token);

                // Store the token in local storage
                localStorage.setItem('token', token);

                // Redirect to the dashboard or any other page
                // Use React Router's useHistory hook here
                history('/dashboard');
            }
        } catch (error) {
            console.error('Login failed:', error);
        }
    };

    return (
        <Box className="formContainer">
            <form onSubmit={handleSubmit}>
                <Typography variant="p" component="p">
                    Login
                </Typography>
                <TextField
                    className="input"
                    type="text"
                    value={username}
                    onChange={handleUsernameChange}
                    placeholder="Username"
                    label="User Name"
                    required
                />

                <TextField
                    className="input"
                    type="text"
                    value={password}
                    onChange={handlePasswordChange}
                    placeholder="Password"
                    label="Password"
                    required
                />
                <Button variant="contained" color="primary" type="submit">
                    Login
                </Button>

                <Link to="/register">Register</Link>

            </form>
        </Box>
    );
};

export default Login;
