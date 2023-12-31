import React, { useEffect, useState } from 'react';
import Header from '../components/Header/Header';
import '../assets/styles.css';
import { Link } from 'react-router-dom';
import RegistrationForm from '../components/Forms/RegistrationForm';

const Home = () => {
    const [message, setMessage] = useState('');

    useEffect(() => {
        fetch('https://localhost:7047/api/Home')
            .then(response => response.json())
            .then(data => setMessage(data.message))
            .catch(error => console.error('Error:', error));
    }, []);

    return (
        <div className="homePage">
            
            <h1>Welcome to Our Website</h1>
            <p>Message from WebAPI: {message}</p>
            <Link to="/register">Register</Link>
            <Link to="/login">Login</Link>
        </div>
    );
};

export default Home;