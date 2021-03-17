import React from "react";
import ArtistNavbar from "../FixedComponents/ArtistNavbar";
import Artwork from "./../IndividualComponents/Artwork";

const MyArt: React.FC = () => {
    const artwork = {
        id: 1,
        userId: 1,
        pieceName: "Mandala",
        customerName: "Brian",
        customerContact: "b@g.com",
        shippingCost: 15.82,
        materialCost: 10.32,
        salePrice: 1250.43,
        height: 30,
        width: 30,
        timeSpent: 60,
        shape: "round",
        paymentType: "credit",
        isCommission: true,
        isPaymentCollected: false,
        dateStarted: new Date(1, 2, 3),
        dateFinished: new Date(1, 4, 3),
        margin: 1130.64,
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
        height: 30,
        width: 30,
        timeSpent: 60,
        shape: "round",
        paymentType: "credit",
        isCommission: true,
        isPaymentCollected: false,
        dateStarted: new Date(1, 2, 3),
        dateFinished: new Date(1, 4, 3),
        margin: 1130.64,
    };
    const addPiece = () => {
        console.log("Adding Piece");
    };
    return (
        <>
            <ArtistNavbar />
            <div className="App">
                <h1 className="art-title">
                    My <span className="accent">Art</span>
                </h1>
                <button className="btn btn-purple" onClick={addPiece}>
                    Add Piece
                </button>
                <div className="row justify-content-start">
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
            ;
        </>
    );
};

export default MyArt;
