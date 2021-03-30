import React, { useState, useEffect } from "react";
import ArtistNavbar from "../FixedComponents/ArtistNavbar";
import ArtworkForm from "../Forms/ArtworkForm";
import Artwork from "./../IndividualComponents/Artwork";
import { getUserData } from "./../helpers/userRequests";
import { artwork } from "./../helpers/interfaces";

const MyArt: React.FC = () => {
    const [showAddPiece, setShowAddPiece] = useState<boolean>(false);
    const [userArtworks, setUserArtworks] = useState<artwork[]>([]);
    const userHasArtworks = userArtworks.length > 0;

    useEffect(() => {
        (async () => {
            const userArtworks = await getUserData();
            setUserArtworks(userArtworks);
        })();
    }, []);

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
                              return <Artwork artwork={artwork} key={Math.random()} />;
                          })
                        : null}
                </div>
            </div>
            {showAddPiece ? <ArtworkForm setShowAddPiece={setShowAddPiece} userId={1} /> : null}
        </>
    );
};

export default MyArt;

// const artwork = {
//     id: 1,
//     userId: 1,
//     pieceName: null,
//     customerName: null,
//     customerContact: null,
//     shippingCost: null,
//     materialCost: null,
//     salePrice: null,
//     height: null,
//     width: null,
//     timeSpent: null,
//     shape: null,
//     paymentType: null,
//     isCommission: null,
//     isPaymentCollected: false,
//     dateStarted: null,
//     dateFinished: null,
//     margin: null,
// };

// const artwork2 = {
//     id: 1,
//     userId: 1,
//     imgUrl: "https://hdqwalls.com/wallpapers/best-nature-image.jpg",
//     pieceName: "Mandala",
//     customerName: "Brian",
//     customerContact: "b@g.com",
//     shippingCost: 15.82,
//     materialCost: 10.32,
//     salePrice: 1250.43,
//     height: 11,
//     width: 30,
//     timeSpent: 60,
//     shape: "rectangle",
//     paymentType: "credit",
//     isCommission: true,
//     isPaymentCollected: true,
//     dateStarted: new Date(1, 2, 3),
//     dateFinished: new Date(1, 4, 3),
//     margin: 1130.64,
// };
