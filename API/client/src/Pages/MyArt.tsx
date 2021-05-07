import React, { useState, useEffect } from "react";
import { pauseForAnimation } from "./../helpers/pauseForAnimation";
import { getUserData } from "./../helpers/userRequests";
import { Artwork, UserData } from "./../helpers/interfaces";
import { useHistory } from "react-router";
import { getLocalStorageData } from "./../helpers/getLocalStorageData";
import ArtistNavbar from "../FixedComponents/ArtistNavbar";
import ArtworkForm from "../Forms/ArtworkForm";
import ArtworkComponent from "./../IndividualComponents/ArtworkComponent";
import BoxAnimation from "./../Animations/BoxAnimation";

const MyArt: React.FC = () => {
    const history = useHistory();
    const [isRedirecting, setIsRedirecting] = useState<boolean>(true);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [showAddPiece, setShowAddPiece] = useState<boolean>(false);
    const [userArtworks, setUserArtworks] = useState<Artwork[]>([]);
    const [apiError, setApiError] = useState<boolean>(false);
    const userHasArtworks: boolean = userArtworks.length > 0;

    useEffect((): void => {
        (async (): Promise<void> => {
            setIsLoading(true);
            if (!!!getLocalStorageData()) return history.push("/login");
            setIsRedirecting(false);
            if (!showAddPiece) {
                await updateArtworks();
            } else setIsLoading(false);
        })();
        // eslint-disable-next-line
    }, []);

    const updateArtworks = async (): Promise<void> => {
        setIsLoading(true);
        const userData: UserData = await getUserData();
        const unauthorized: boolean = userData === 401;
        if (unauthorized) return history.push("/login");
        if (!!!userData) {
            setApiError(true);
            return await finishLoading();
        }
        setUserArtworks(userData.artWorks);
        await finishLoading();
    };

    const finishLoading = async (): Promise<void> => {
        await pauseForAnimation();
        setIsLoading(false);
    };

    return (
        <>
            {isRedirecting ? null : (
                <>
                    {isLoading ? (
                        <BoxAnimation />
                    ) : (
                        <>
                            <ArtistNavbar />
                            <div className="App">
                                <h1 className="art-title" style={{ marginBottom: 10 }}>
                                    My <span className="accent">Art</span>
                                </h1>
                                <button
                                    style={{ marginBottom: 10 }}
                                    className="btn btn-purple shadow"
                                    onClick={() => setShowAddPiece(true)}>
                                    Add Piece
                                </button>
                                <div className="row justify-content-start" style={{ overflow: "hidden" }}>
                                    {userHasArtworks &&
                                        userArtworks.map(artwork => {
                                            return (
                                                <ArtworkComponent
                                                    updateComponent={updateArtworks}
                                                    artwork={artwork}
                                                    key={Math.random()}
                                                />
                                            );
                                        })}
                                </div>
                                {apiError && <h3>Oops! There was an unexpected error. Try refrshing the browser.</h3>}
                            </div>
                            {showAddPiece && (
                                <ArtworkForm updateComponent={updateArtworks} setShowAddPiece={setShowAddPiece} />
                            )}
                        </>
                    )}
                </>
            )}
        </>
    );
};

export default MyArt;
