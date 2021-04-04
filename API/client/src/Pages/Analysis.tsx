import React, { useState, useEffect } from "react";
import { useHistory } from "react-router";
import { UserData } from "./../helpers/interfaces";
import { getUserData } from "./../helpers/userRequests";
import { pauseForAnimation } from "./../helpers/pauseForAnimation";
import { getLocalStorageData } from "./../helpers/getLocalStorageData";
import ArtistNavbar from "./../FixedComponents/ArtistNavbar";
import Table from "./../IndividualComponents/Table";
import BarChart from "./../IndividualComponents/BarChart";
import BoxAnimation from "./../Animations/BoxAnimation";
import "./css/MyProfile.css";

const Analysis: React.FC = () => {
    const history = useHistory();
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [userData, setUserData] = useState<UserData>(null);
    const [apiError, setApiError] = useState<boolean>(false);

    useEffect((): void => {
        (async (): Promise<void> => {
            setIsLoading(true);
            setApiError(false);
            if (!!!getLocalStorageData()) return history.push("/login");

            const userData: UserData = await getUserData();
            const unAuthorized = userData === 401;
            if (unAuthorized) return history.push("/login");

            if (!!!userData) {
                setApiError(true);
                return await finishLoading();
            }
            setUserData(userData);
            await finishLoading();
        })();
        // eslint-disable-next-line
    }, []);

    const finishLoading = async (): Promise<void> => {
        await pauseForAnimation();
        setIsLoading(false);
    };

    return (
        <>
            {!isLoading ? (
                <>
                    <ArtistNavbar />
                    <div className="App">
                        <h1 className="art-title">
                            <span className="accent">Analysis</span>
                        </h1>
                        {!!userData ? (
                            <>
                                <div className="username">
                                    <h2>{userData?.username}</h2>
                                </div>
                                {userData?.artWorks.length > 0 ? <BarChart artworks={userData.artWorks} /> : null}
                                <Table userData={userData} />
                            </>
                        ) : null}
                        {apiError ? <h3>Oops! There was an unexpected error. Try refrshing the browser.</h3> : null}
                    </div>
                </>
            ) : (
                <BoxAnimation />
            )}
        </>
    );
};

export default Analysis;
