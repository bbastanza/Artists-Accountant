import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { deleteUser } from "./../helpers/userRequests";
import { ResponseType } from "../helpers/interfaces";
import { pauseForAnimation } from "./../helpers/pauseForAnimation";
import ArtistNavbar from "./../FixedComponents/ArtistNavbar";
import Confirm from "./../IndividualComponents/Modals/Confirm";
import defaultProfileImage from "./../Images/defaultUserImage.png";
import "./css/MyProfile.css";
import BoxAnimation from "../Animations/BoxAnimation";

const MyProfile: React.FC = () => {
    const history = useHistory();
    const [showConfirmDelete, setShowConfirmDelete] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [unauthorized, setUnauthorized] = useState<boolean>(false);
    const [apiError, setApiError] = useState<boolean>(false);

    const changePassword = () => {
        console.log("updating password");
    };

    const changeUsername = () => {
        console.log("updating username");
    };

    const logout = () => {
        localStorage.clear();
        history.push("/login");
    };

    const confirmDelete = async (): Promise<void> => {
        setShowConfirmDelete(false);
        setIsLoading(true);
        const responseType: ResponseType = await deleteUser();
        console.log(responseType);
        if (responseType === 1) return history.push("login");
        if (responseType === 2) {
            setUnauthorized(true);
            await finishLoading();
            return await unauthorizedAction();
        }
        setApiError(true);
        setIsLoading(false);
        await finishLoading();
    };
    const unauthorizedAction = async (): Promise<void> => {
        await pauseForAnimation();
        history.push("login");
    };

    const finishLoading = async (): Promise<void> => {
        await pauseForAnimation();
        setIsLoading(false);
    };

    return (
        <>
            {showConfirmDelete ? (
                <Confirm confirmDelete={confirmDelete} cancelDelete={() => setShowConfirmDelete(false)} />
            ) : null}
            {isLoading ? (
                <BoxAnimation />
            ) : (
                <>
                    <ArtistNavbar />
                    <div className="App">
                        <h1 className="art-title">
                            My <span className="accent">Profile</span>
                        </h1>
                        <div className="username">
                            <h1>{JSON.parse(localStorage.getItem("UserData"))?.username}</h1>
                        </div>
                        <img src={defaultProfileImage} alt="" className="profile-img" />
                        {apiError ? (
                            <h3 className="form-error">
                                Oops! There was an unexpected error. Try refrshing the browser.
                            </h3>
                        ) : null}
                        {unauthorized ? (
                            <h3 className="form-error" style={{ padding: 20 }}>
                                Oops! Authentication failure. Redirecting to Login.
                            </h3>
                        ) : null}
                        <div className="row btn-container-profile">
                            <button onClick={logout} className="col-12 btn btn-purple shadow-sm text-nowrap">
                                Logout
                            </button>
                            <button onClick={changeUsername} className="col-12 btn btn-purple shadow-sm text-nowrap">
                                Change Username
                            </button>
                            <button onClick={changePassword} className="col-12 btn btn-purple shadow-sm text-nowrap">
                                Change Password
                            </button>
                            <button
                                onClick={() => setShowConfirmDelete(true)}
                                className="col-12 btn btn-red shadow-sm text-nowrap">
                                Delete Account
                            </button>
                        </div>
                    </div>
                </>
            )}
        </>
    );
};

export default MyProfile;
