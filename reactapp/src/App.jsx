import React, { Component } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Sidebar from './components/Sidebar/Sidebar';
import Home from './pages/home';
import Dashboard from './pages/dashboard';
import CRM from './pages/CRM';
import Documents from './pages/Documents';
import Employees from './pages/Employees';
import Transactions from './pages/Transactions';
import HR from './pages/HR';
import Projects from './pages/Projects';
import './assets/styles.css'
import Header from './components/Header/Header';

export default class App extends Component {
    render() {
        return (
            <Router>
                <div className="page">
                    {/*<Header />*/}
                    <Sidebar />
                    <Routes>
                        <Route exact path='/' element={<Home />}></Route>
                        <Route exact path='/dashboard' element={<Dashboard />}></Route>
                        <Route exact path='/CRM' element={<CRM />}></Route>
                        <Route exact path='/Documents' element={<Documents />}></Route>
                        <Route exact path='/Employees' element={<Employees />}></Route>
                        <Route exact path='/Transactions' element={<Transactions />}></Route>
                        <Route exact path='/HR' element={<HR />}></Route>
                        <Route exact path='/Projects' element={<Projects />}></Route>
                    </Routes>
                </div>                
            </Router>
        );
    }
}
