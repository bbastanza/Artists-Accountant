import React, { useState, useEffect } from "react";
import ArtistNavbar from "../FixedComponents/ArtistNavbar";
import ArtworkForm from "../Forms/ArtworkForm";
import ArtworkComponent from "./../IndividualComponents/ArtworkComponent";
import { getUserData } from "./../helpers/userRequests";
import { Artwork, UserData } from "./../helpers/interfaces";
import { useHistory } from "react-router";

const MyArt: React.FC = () => {
    const history = useHistory();
    const [showAddPiece, setShowAddPiece] = useState<boolean>(false);
    const [userArtworks, setUserArtworks] = useState<Artwork[]>([]);
    const [apiError, setApiError] = useState<boolean>(false);
    const userHasArtworks: boolean = userArtworks.length > 0;

    useEffect((): void => {
        (async (): Promise<void> => {
            const hasLocalStorage = !!JSON.parse(localStorage.getItem("UserData"));
            if (hasLocalStorage === false) return history.push("/login");
            if (!showAddPiece) {
                const userData: UserData = await getUserData();
                const unauthorized = userData === 401;
                if (unauthorized) return history.push("/login");
                if (!!!userData) return setApiError(true);
                setUserArtworks(userData.artWorks);
            }
        })();
        // eslint-disable-next-line
    }, []);

    const updateComponent = async (): Promise<void> => {
        const userData: UserData = await getUserData();
        if (!!!userData) return history.push("/login");
        setUserArtworks(userData.artWorks);
    };

    return (
        <>
            <ArtistNavbar />
            <div className="App">
                <h1 className="art-title">
                    My <span className="accent">Art</span>
                </h1>
                <button className="btn btn-purple shadow" onClick={() => setShowAddPiece(true)}>
                    Add Piece
                </button>
                <div className="row justify-content-start" style={{ overflow: "hidden" }}>
                    {userHasArtworks
                        ? userArtworks.map(artwork => {
                              return (
                                  <ArtworkComponent
                                      updateComponent={updateComponent}
                                      artwork={artwork}
                                      key={Math.random()}
                                  />
                              );
                          })
                        : null}
                </div>
            </div>
            {showAddPiece ? <ArtworkForm updateComponent={updateComponent} setShowAddPiece={setShowAddPiece} /> : null}
            {apiError ? <h3>Oops! There was an unexpected error. Try refrshing the browser.</h3> : null}
        </>
    );
};

export default MyArt;
