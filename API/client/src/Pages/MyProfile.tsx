import React from "react";
import ArtistNavbar from "./../FixedComponents/ArtistNavbar";
import { useHistory } from "react-router-dom";

const MyProfile: React.FC = () => {
    const history = useHistory();
    if (!!!JSON.parse(localStorage.getItem("UserData"))) history.push("/login");
    return (
        <>
            <ArtistNavbar />
            <div className="App">
                <h1 className="art-title">
                    My <span className="accent">Profile</span>
                </h1>
            </div>
        </>
    );
};

export default MyProfile;
