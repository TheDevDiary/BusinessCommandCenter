import React, { useState } from 'react';
//import { useHistory } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { Link } from 'react-router-dom';
import './styles.css';

const RegisterForm = () => {
    const history = useNavigate();

    const [user, setUser] = useState({
        username: '',
        firstName: '',
        lastName: '',
        email: '',
        password: '',
    });

    const [errorMessage, setErrorMessage] = useState('');

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const formData = new FormData();
        formData.append('username', user.username);
        formData.append('firstName', user.firstName);
        formData.append('lastName', user.lastName);
        formData.append('email', user.email);
        formData.append('password', user.password);

        try {
            const response = await fetch('https://localhost:7047/api/User/Register', {
                method: 'POST',
                body: formData,
                headers: {
                    'Accept': 'application/json',
                }
            });

            if (response.ok) {
                const data = await response.json();
                console.log('User registered successfully:', data);

                // Show success message and redirect to login
                alert('User registered successfully! Redirecting to login.');
                history('/login');

                setUser({
                    username: '',
                    firstName: '',
                    lastName: '',
                    email: '',
                    password: ''
                });
                setErrorMessage('');
            } else {
                const errorData = await response.json();
                setErrorMessage(errorData);
            }
        } catch (error) {
            console.error('Registration failed:', error);
            setErrorMessage('Registration failed. Please try again.');
        }
    };
    return (
        <Box className="formContainer">
            <form onSubmit={handleSubmit}>
                <Typography variant="p" component="p">
                   Registation
                </Typography>
                <TextField
                    className="input"
                    type="text"
                    name="username"
                    value={user.username}
                    onChange={handleChange}
                    placeholder="Username"
                    label="User Name"
                    required
                />
                <TextField
                    className="input"
                    type="text"
                    name="firstName"
                    value={user.firstName}
                    onChange={handleChange}
                    placeholder="First Name"
                    label="First Name"
                    required
                />
                <TextField
                    className="input"
                    type="text"
                    name="lastName"
                    value={user.lastName}
                    onChange={handleChange}
                    placeholder="Last Name"
                    label="Last Name"
                    required
                />
                <TextField
                    className="input"
                    type="email"
                    name="email"
                    value={user.email}
                    onChange={handleChange}
                    label="Email"
                    required
                />
                <TextField
                    className="input"
                    type="password"
                    name="password"
                    value={user.password}
                    onChange={handleChange}
                    placeholder="Password"
                    label="Password"
                    required
                />
                <Button variant="contained" color="primary" type="submit">
                    Register
                </Button>

                <Link to="/login">Login</Link>
            </form>
            {errorMessage && (
                <div style={{ color: 'red', marginTop: '10px' }}>
                   *{errorMessage}
                </div>
            )}
        </Box>
    );
};

export default RegisterForm;
