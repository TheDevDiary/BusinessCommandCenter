import React, { useEffect, useState } from 'react';
import Header from '../components/Header/Header';
import '../assets/styles.css';

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
            <Header />
            <h1>Welcome to Our Website</h1>
            <p>Message from WebAPI: {message}</p>
        </div>
    );
};

export default Home;