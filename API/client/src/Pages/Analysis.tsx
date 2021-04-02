import React, { useState, useEffect } from "react";
import { useHistory } from "react-router";
import { UserData } from "../helpers/interfaces";
import { getUserData } from "../helpers/userRequests";
import ArtistNavbar from "../FixedComponents/ArtistNavbar";
import Table from "../IndividualComponents/Table";
import BarChart from "../IndividualComponents/BarChart";
import "./css/MyProfile.css";

const Analysis: React.FC = () => {
    const history = useHistory();
    if (!!!JSON.parse(localStorage.getItem("UserData"))) history.push("/login");
    const [userData, setUserData] = useState<UserData>(null);
    const [apiError, setApiError] = useState<boolean>(false);

    useEffect((): void => {
        (async (): Promise<void> => {
            const userData: UserData = await getUserData();
            const unAuthorized = userData === 401;
            if (unAuthorized) return history.push("/login");
            if (!!!userData) return setApiError(true);
            setApiError(false);
            setUserData(userData);
        })();
        // eslint-disable-next-line
    }, []);

    return (
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
                        <BarChart artworks={userData?.artWorks} />
                        <Table userData={userData} />
                    </>
                ) : null}
                {apiError ? <h3>Oops! There was an unexpected error. Try refrshing the browser.</h3> : null}
            </div>
        </>
    );
};

export default Analysis;
