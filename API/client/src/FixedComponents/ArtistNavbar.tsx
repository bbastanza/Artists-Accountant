import React, { useState, useEffect } from "react";
import { NavLink as Link, BrowserRouter as Router } from "react-router-dom";
import chart from "../Images/chart.svg";
import books from "../Images/books.svg";
import home from "../Images/home.svg";
import settings from "../Images/settings.png";

export const ArtistNavbar = () => {
    const linkStyle = {
        textDecoration: "none",
    };
    return (
        <Router>
            <nav className="navbar">
                <ul className="navbar-nav">
                    <Link to="/" className="nav-item" style={linkStyle}>
                        <li className="nav-link">
                            <img className="nav-img" src={home} alt="home" />
                            <span className="link-text">Home</span>
                        </li>
                    </Link>
                    <Link to="/analysis" className="nav-item" style={linkStyle}>
                        <li className="nav-link">
                            <img className="nav-img" src={chart} alt="chart" />
                            <span className="link-text">Analysis</span>
                        </li>
                    </Link>
                    <Link to="/myart" className="nav-item" style={linkStyle}>
                        <li className="nav-link">
                            <img className="nav-img" src={books} alt="books" />
                            <span className="link-text">My Art</span>
                        </li>
                    </Link>
                    <Link
                        to="/settings"
                        className="nav-item"
                        style={linkStyle}>
                        <li className="nav-link">
                            <img
                                className="nav-img"
                                src={settings}
                                alt="settings"
                            />
                            <span className="link-text">Settings</span>
                        </li>
                    </Link>
                </ul>
            </nav>
        </Router>
    );
};
