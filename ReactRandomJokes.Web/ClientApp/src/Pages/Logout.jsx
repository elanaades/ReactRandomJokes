﻿import React, { useEffect } from 'react';
import axios from 'axios';
import { useAuthDataContext } from '../AuthContext';
import { useNavigate } from 'react-router-dom';

const Logout = () => {
    const { setUser } = useAuthDataContext();
    const navigate = useNavigate();
    useEffect(() => {
        const doLogout = async () => {
            await axios.post('/api/account/logout');
            setUser(null);
            navigate('/');
        }
        doLogout();
    }, []);

    return (<></>);
}

export default Logout;