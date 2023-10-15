import React, { useState } from 'react';

const RegisterForm = () => {
    const [user, setUser] = useState({
        username: '',
        firstName: '',
        lastName: '',
        email: '',
        password: '',
        profileImage: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Remove the id field from the user object
        const { id, ...userWithoutId } = user;

        try {
            const response = await fetch('https://localhost:7047/api/User/Register', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(userWithoutId)
            });

            if (response.ok) {
                const data = await response.json();
                console.log('User registered successfully:', data);
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
                <input type="text" name="profileImage" value={user.profileImage} onChange={handleChange} placeholder="Profile Image URL" />
                <button type="submit">Register</button>
            </form>
        </div>
    );
};

export default RegisterForm;
