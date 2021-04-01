import React, { useState, useEffect } from "react";
import ArtistNavbar from "../FixedComponents/ArtistNavbar";
import ArtworkForm from "../Forms/ArtworkForm";
import ArtworkComponent from "./../IndividualComponents/ArtworkComponent";
import { getUserData } from "./../helpers/userRequests";
import { Artwork, UserData } from "./../helpers/interfaces";

const MyArt: React.FC = () => {
    const [showAddPiece, setShowAddPiece] = useState<boolean>(false);
    const [userArtworks, setUserArtworks] = useState<Artwork[]>([]);
    const userHasArtworks: boolean = userArtworks.length > 0;

    useEffect(() => {
        if (!!!showAddPiece) {
            (async (): Promise<void> => {
                await updateComponent();
            })();
        }
    }, [showAddPiece]);

    const updateComponent = async (): Promise<void> => {
        const userData: UserData = await getUserData();
        if (!!!userData) return;
        setUserArtworks(userData.artWorks);
    };

    return (
        <>
            <ArtistNavbar />
            <div className="App">
                <h1 className="art-title">
                    My <span className="accent">Art</span>
                </h1>
                <button className="btn btn-purple" onClick={() => setShowAddPiece(true)}>
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
            {showAddPiece ? <ArtworkForm setShowAddPiece={setShowAddPiece} /> : null}
        </>
    );
};

export default MyArt;
