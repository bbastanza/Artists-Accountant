import React from "react";
import { NavLink as Link } from "react-router-dom";
import analysisImage from "../Images/chart.svg";
import myArtImage from "../Images/books.svg";
import homeImage from "../Images/home.svg";
import settingsImage from "../Images/settings.png";

const ArtistNavbar: React.FC = () => {
    const linkStyle: object = {
        textDecoration: "none",
    };

    return (
        <nav className="art-navbar">
            <ul className="art-navbar-nav">
                <Link to="/" className="art-nav-item" style={linkStyle}>
                    <li className="art-nav-link">
                        <img style={{ filter: "greyscale(40%)" }} className="art-nav-img" src={homeImage} alt="home" />
                        <span className="art-link-text">Home</span>
                    </li>
                </Link>
                <Link to="/myart" className="art-nav-item" style={linkStyle}>
                    <li className="art-nav-link">
                        <img className="art-nav-img" src={myArtImage} alt="books" />
                        <span className="art-link-text">My Art</span>
                    </li>
                </Link>
                <Link to="/analysis" className="art-nav-item" style={linkStyle}>
                    <li className="art-nav-link">
                        <img className="art-nav-img" src={analysisImage} alt="chart" />
                        <span className="art-link-text">Analysis</span>
                    </li>
                </Link>
                <Link to="/settingsImage" className="art-nav-item" style={linkStyle}>
                    <li className="art-nav-link">
                        <img className="art-nav-img" src={settingsImage} alt="settings" />
                        <span className="art-link-text">Settings</span>
                    </li>
                </Link>
            </ul>
        </nav>
    );
};

export default ArtistNavbar;
