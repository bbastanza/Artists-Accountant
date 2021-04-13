import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { deleteUser, patchUserImg } from "./../helpers/userRequests";
import { ResponseType } from "../helpers/interfaces";
import { pauseForAnimation } from "./../helpers/pauseForAnimation";
import { getLocalStorageData } from "./../helpers/getLocalStorageData";
import ArtistNavbar from "./../FixedComponents/ArtistNavbar";
import ImageUploader from "./../IndividualComponents/ImageUploader";
import Confirm from "./../IndividualComponents/Modals/Confirm";
import defaultProfileImage from "./../Images/defaultUserImage.png";
import BoxAnimation from "../Animations/BoxAnimation";
import "./css/MyProfile.css";

const MyProfile: React.FC = () => {
    const history = useHistory();
    const [showConfirmDelete, setShowConfirmDelete] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [unauthorized, setUnauthorized] = useState<boolean>(false);
    const [apiError, setApiError] = useState<boolean>(false);
    const [profileImg, setProfileImg] = useState<string>(null);

    useEffect(() => {
        (async () => {
            setIsLoading(true);
            const localStorageData = getLocalStorageData();
            if (!!localStorageData?.profileImgUrl) {
                console.log(localStorageData?.profileImgUrl);
                setProfileImg(localStorageData.profileImgUrl);
                return await finishLoading();
            }
            setProfileImg(defaultProfileImage);
            await finishLoading();
        })();
    }, []);

    const finishLoading = async (): Promise<void> => {
        await pauseForAnimation();
        setIsLoading(false);
    };

    const logout = () => {
        localStorage.clear();
        history.push("/login");
    };

    const patchUserImgUrl = async (imgUrl: any): Promise<void> => {
        const imgResponse: any = await patchUserImg(imgUrl);
        if (imgResponse === 401) return history.push("/login");
        if (imgResponse === null) return setProfileImg(defaultProfileImage);
        setProfileImg(imgResponse);
    };

    const confirmDelete = async (): Promise<void> => {
        setShowConfirmDelete(false);
        setIsLoading(true);
        const responseType: ResponseType = await deleteUser();
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

    return (
        <>
            {isLoading ? (
                <BoxAnimation />
            ) : (
                <>
                    <ArtistNavbar />
                    <div className="App">
                        <h1 className="art-title">
                            My <span className="accent">Profile</span>
                        </h1>
                        {!!getLocalStorageData() ? (
                            <div className="username">
                                <h1>{getLocalStorageData()?.username}</h1>
                            </div>
                        ) : null}
                        {!!profileImg && <img src={profileImg} alt="" className="profile-img" />}
                        {apiError && (
                            <h3 className="form-error">
                                Oops! There was an unexpected error. Try refrshing the browser.
                            </h3>
                        )}
                        {unauthorized && (
                            <h3 className="form-error" style={{ padding: 20 }}>
                                Oops! Authentication failure. Redirecting to Login.
                            </h3>
                        )}
                        <div className="row btn-container-profile">
                            <ImageUploader saveImgUrl={url => patchUserImgUrl(url)} />
                            <button onClick={logout} className="col-12 btn btn-purple shadow-sm text-nowrap">
                                Logout
                            </button>
                            <button
                                onClick={() => setShowConfirmDelete(true)}
                                className="col-12 btn btn-red shadow-sm text-nowrap">
                                Delete Account
                            </button>
                        </div>
                    </div>
                    {showConfirmDelete && (
                        <Confirm confirmDelete={confirmDelete} cancelDelete={() => setShowConfirmDelete(false)} />
                    )}
                </>
            )}
        </>
    );
};

export default MyProfile;
