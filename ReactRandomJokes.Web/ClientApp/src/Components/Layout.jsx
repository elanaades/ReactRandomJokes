import React from 'react';
import { Link } from 'react-router-dom';
import { useAuthDataContext } from '../AuthContext';


const Layout = ({ children }) => {
    const { user } = useAuthDataContext();
    const isLoggedIn = !!user;

    return (
        <div>
            <header>
                <nav className="navbar navbar-expand-sm navbar-dark fixed-top bg-dark border-bottom box-shadow">
                    <div className="container">
                        <a className="navbar-brand" href="/">React Random Jokes</a>
                        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon" />
                        </button>
                        <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item">
                                    <a className="nav-link text-light" href="/viewall">View All</a>
                                </li>
                                {!isLoggedIn && <li className="nav-item"><Link className='nav-link text-light' to='/signup'>Signup</Link></li>}
                                {!isLoggedIn && <li className="nav-item"><Link className='nav-link text-light' to='/login'>Login</Link></li>}
                                {isLoggedIn && <li className="nav-item"><Link className='nav-link text-light' to='/logout'>Logout</Link></li>}
                            </ul>
                        </div>
                    </div>
                </nav>
            </header>

            <div className="container" style={{ marginTop: 80 }}>
                <main role="main" className="pb-3">
                    {children}
                </main>
            </div>
        </div>
    )
}

export default Layout;
