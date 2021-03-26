import React, { useState, useEffect } from "react";
import ArtistNavbar from "../FixedComponents/ArtistNavbar";
import ArtworkForm from "../Forms/ArtworkForm";
import Artwork from "./../IndividualComponents/Artwork";

const MyArt: React.FC = () => {
    const [showAddPiece, setShowAddPiece] = useState<boolean>(false);

    const artwork = {
        id: 1,
        userId: 1,
        pieceName: null,
        customerName: null,
        customerContact: null,
        shippingCost: null,
        materialCost: null,
        salePrice: null,
        height: null,
        width: null,
        timeSpent: null,
        shape: null,
        paymentType: null,
        isCommission: null,
        isPaymentCollected: false,
        dateStarted: null,
        dateFinished: null,
        margin: null,
    };
    const artwork2 = {
        id: 1,
        userId: 1,
        imgUrl: "https://hdqwalls.com/wallpapers/best-nature-image.jpg",
        pieceName: "Mandala",
        customerName: "Brian",
        customerContact: "b@g.com",
        shippingCost: 15.82,
        materialCost: 10.32,
        salePrice: 1250.43,
        height: 11,
        width: 30,
        timeSpent: 60,
        shape: "rectangle",
        paymentType: "credit",
        isCommission: true,
        isPaymentCollected: true,
        dateStarted: new Date(1, 2, 3),
        dateFinished: new Date(1, 4, 3),
        margin: 1130.64,
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
                    <Artwork artwork={artwork} />
                    <Artwork artwork={artwork2} />
                    <Artwork artwork={artwork} />
                    <Artwork artwork={artwork2} />
                    <Artwork artwork={artwork} />
                    <Artwork artwork={artwork2} />
                    <Artwork artwork={artwork} />
                    <Artwork artwork={artwork2} />
                </div>
            </div>
            {showAddPiece ? <ArtworkForm setShowAddPiece={setShowAddPiece} userId={1} /> : null}
        </>
    );
};

export default MyArt;
