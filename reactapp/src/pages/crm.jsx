import React, { useEffect, useState } from 'react';
import Sidebar from '../components/Sidebar/Sidebar';
import Header from '../components/Header/Header';
import '../assets/styles.css';

const CRM = () => {

    return (
        <div className="crm">

            <Sidebar />
            <div className="container">
                <Header />
                <p>CRM</p>
            </div>

        </div>
    );
};

export default CRM;