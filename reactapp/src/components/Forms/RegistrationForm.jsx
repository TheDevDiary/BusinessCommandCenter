import React, { useState } from 'react';

const RegisterForm = () => {
    const [user, setUser] = useState({
        username: '',
        firstName: '',
        lastName: '',
        email: '',
        password: '',
        role: 'Employee',  // Set a default role or provide a way for the user to choose
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch('https://localhost:7047/api/Users/Register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });

            if (response.ok) {
                console.log('User registered successfully.');
            } else {
                console.error('Registration failed:', response.statusText);
            }
        } catch (error) {
            console.error('Registration failed:', error);
        }
    };


    return (
        <div>
            <h2>User Registration</h2>
            <form onSubmit={handleSubmit}>
                <input type="text" name="username" value={user.username} onChange={handleChange} placeholder="Username" />
                <input type="text" name="firstName" value={user.firstName} onChange={handleChange} placeholder="First Name" />
                <input type="text" name="lastName" value={user.lastName} onChange={handleChange} placeholder="Last Name" />
                <input type="email" name="email" value={user.email} onChange={handleChange} placeholder="Email" />
                <input type="password" name="password" value={user.password} onChange={handleChange} placeholder="Password" />
                <select name="role" value={user.role} onChange={handleChange}>
                    <option value="Employee">Employee</option>
                    <option value="Manager">Manager</option>
                    <option value="Admin">Admin</option>
                </select>
                <button type="submit">Register</button>
            </form>
        </div>
    );
};

export default RegisterForm;
