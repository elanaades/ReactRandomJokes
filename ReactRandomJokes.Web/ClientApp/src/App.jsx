import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Layout from './Components/Layout';
import Signup from './Pages/Signup';
import Login from './Pages/Login';
import AuthContextComponent from './AuthContext';
import PrivateRoute from './PrivateRoute';
import Logout from './Pages/Logout';
import Home from './Pages/Home';
import ViewAll from './Pages/ViewAll';

const App = () => {
    return (
        <AuthContextComponent>
                <Layout>
                    <Routes>
                        <Route exact path='/' element={<Home />} />
                        <Route exact path='/signup' element={<Signup />} />
                        <Route exact path='/login' element={<Login />} />
                        <Route exact path='/logout' element={<Logout />} />
                        <Route exact path='/viewall' element={<ViewAll />} />
                    </Routes>
                </Layout>
        </AuthContextComponent>
    );
}

export default App;