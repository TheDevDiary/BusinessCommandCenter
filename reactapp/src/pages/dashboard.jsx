import React, { useEffect, useState } from 'react';
import Sidebar from '../components/Sidebar/Sidebar';
import Header from '../components/Header/Header';
import '../assets/styles.css';

const Dashboard= () => {   
    const [user, setUser] = useState(null);

    //useEffect(() => {
    //    const fetchUser = async () => {
    //        try {
    //            // Fetch the user data from your API or wherever you get it from
    //            const response = await fetch('https://localhost:7047/api/User', {
    //                headers: {
    //                    'Authorization': `Bearer ${localStorage.getItem('token')}`
    //                }
    //            });
    //            const userData = await response.json();
    //            setUser(userData); // Set the user data
    //        } catch (error) {
    //            console.error('Error fetching user:', error);
    //        }
    //    };

    //    fetchUser(); // Fetch user information when the component mounts
    //}, []);

    return (
        <div className="dashboard">

            <Sidebar />
            <div className="container">
                <Header user={user} />
                <p>dashboard</p>
            </div>
            
        </div>
    );
};

export default Dashboard;