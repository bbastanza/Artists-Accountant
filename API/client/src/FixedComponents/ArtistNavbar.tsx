import React, { useState, useEffect } from "react";
import { NavLink as Link, BrowserRouter as Router } from "react-router-dom";
import analysisImage from "../Images/chart.svg";
import myArtImage from "../Images/books.svg";
import homeImage from "../Images/home.svg";
import settingsImage from "../Images/settings.png";

const ArtistNavbar: React.FC = () => {
    const linkStyle: object = {
        textDecoration: "none",
    };

    return (
        <Router>
            <nav className="navbar">
                <ul className="navbar-nav">
                    <Link to="/" className="nav-item" style={linkStyle}>
                        <li className="nav-link">
                            <img style={{ filter: "greyscale(40%)" }} className="nav-img" src={homeImage} alt="home" />
                            <span className="link-text">Home</span>
                        </li>
                    </Link>
                    <Link to="/myart" className="nav-item" style={linkStyle}>
                        <li className="nav-link">
                            <img className="nav-img" src={myArtImage} alt="books" />
                            <span className="link-text">My Art</span>
                        </li>
                    </Link>
                    <Link to="/analysis" className="nav-item" style={linkStyle}>
                        <li className="nav-link">
                            <img className="nav-img" src={analysisImage} alt="chart" />
                            <span className="link-text">Analysis</span>
                        </li>
                    </Link>
                    <Link to="/settingsImage" className="nav-item" style={linkStyle}>
                        <li className="nav-link">
                            <img className="nav-img" src={settingsImage} alt="settings" />
                            <span className="link-text">Settings</span>
                        </li>
                    </Link>
                </ul>
            </nav>
        </Router>
    );
};

export default ArtistNavbar;
