import React, { useState } from "react";
import ArtworkShowMore from "./ArtworkShowMore";
import "./CSS/Artwork.css";

export interface artworkProps {
    artwork: artwork;
}
export interface artwork {
    id: number;
    userId?: number;
    imgUrl?: string;
    pieceName?: string;
    customerName?: string;
    customerContact?: string;
    shippingCost?: number;
    materialCost?: number;
    salePrice?: number;
    height?: number;
    width?: number;
    timeSpent?: number;
    shape?: string;
    paymentType?: string;
    isCommission?: boolean;
    isPaymentCollected?: boolean;
    dateStarted?: Date;
    dateFinished?: Date;
    margin?: number;
}

const Artwork: React.FC<artworkProps> = ({ artwork }: artworkProps) => {
    const [showMore, setShowMore] = useState<boolean>(false);

    const defaultImageUrl = "https://webstockreview.net/images/easel-clipart-color-pallet-18.png";
    const imageUrl = !!artwork.imgUrl ? artwork.imgUrl : defaultImageUrl;

    return (
        <>
            {showMore ? (
                <ArtworkShowMore setShowMore={setShowMore} artwork={artwork} />
            ) : (
                <div className="row flex-start artwork-container">
                    <div className="col-4 img-btn-container">
                        <img className="artwork-img" src={imageUrl} alt="" />
                        <div className="btn-container">
                            <button onClick={() => setShowMore(true)} className="btn btn-purple">
                                More
                            </button>
                            <button className="btn btn-purple">Edit</button>
                        </div>
                    </div>
                    <div className="col-3">
                        <p>
                            Name: <b>{artwork.pieceName}</b>
                        </p>
                        <p>
                            Customer: <b>{artwork.customerName}</b>{" "}
                        </p>
                        <p className="d-none d-sm-block">
                            Contact: <b>{artwork.customerContact}</b>
                        </p>
                    </div>
                    <div className="col-3 d-none d-sm-block">
                        <p>
                            Sale Price: <b>${artwork.salePrice}</b>
                        </p>
                        <p>
                            Margin: <b>${artwork.margin}</b>
                        </p>
                        <p>
                            Shape: <b>{artwork.shape}</b>
                        </p>
                    </div>
                </div>
            )}
        </>
    );
};

export default Artwork;
