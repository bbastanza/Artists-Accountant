import React from "react";
import ArtistNavbar from "./../FixedComponents/ArtistNavbar";
import { useHistory } from "react-router-dom";
import "./css/MyProfile.css";
import defaultProfileImage from "./../Images/defaultUserImage.png";

const MyProfile: React.FC = () => {
    const history = useHistory();
    if (!!!JSON.parse(localStorage.getItem("UserData"))) history.push("/login");

    const deleteUser = () => {
        console.log("deleting User");
    };

    const changePassword = () => {
        console.log("updating password");
    };

    const changeUsername = () => {
        console.log("updating username");
    };

    return (
        <>
            <ArtistNavbar />
            <div className="App">
                <h1 className="art-title">
                    My <span className="accent">Profile</span>
                </h1>
                <div className="username">
                    <h1>jazzyjeff</h1>
                </div>
                <img src={defaultProfileImage} alt="" className="profile-img" />
                <div className="row btn-container-profile">
                    <button onClick={changeUsername} className="btn btn-purple shadow text-nowrap">
                        Change Username
                    </button>
                    <button onClick={changePassword} className="btn btn-purple shadow text-nowrap">
                        Change Password
                    </button>
                    <button onClick={deleteUser} className="btn btn-red shadow text-nowrap">
                        Delete Account
                    </button>
                </div>
            </div>
        </>
    );
};

export default MyProfile;
