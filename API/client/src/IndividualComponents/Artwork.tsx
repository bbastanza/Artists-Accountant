import React, { useState } from "react";
import ArtworkShowMore from "./ArtworkShowMore";
import ArtworkForm from "../Forms/ArtworkForm";
import "./CSS/Artwork.css";
import { formatMoney, formatForNull } from "./../helpers/beautifyNumber";

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
    const [showEdit, setShowEdit] = useState<boolean>(false);

    const defaultImgUrl =
        "https://1.bp.blogspot.com/-Bxk8AKjiW6Y/TdTf86SJg1I/AAAAAAAAFnE/nn9X5nNhvgQ/s1600/4+Horizontal+%2526+Vertical+lines+%25286%2529.JPG";
    const imageUrl = !!artwork.imgUrl ? artwork.imgUrl : defaultImgUrl;

    // TODO move each key/value into thier own div
    return (
        <>
            {showMore ? (
                <ArtworkShowMore setShowMore={setShowMore} artwork={artwork} defaultImgUrl={defaultImgUrl} />
            ) : null}

            {showEdit ? <ArtworkForm setShowEdit={setShowEdit} artwork={artwork} userId={1} /> : null}

            <div className="row flex-start artwork-container">
                <div className="col-4 img-btn-container">
                    <img className="artwork-img" src={imageUrl} alt="" />
                    <div className="btn-container">
                        <button onClick={() => setShowMore(true)} className="btn btn-purple">
                            More
                        </button>
                        <button onClick={() => setShowEdit(true)} className="btn btn-purple">
                            Edit
                        </button>
                    </div>
                </div>
                <div className="col-3">
                    <p>
                        Name: <b>{formatForNull(artwork.pieceName)}</b>
                    </p>
                    <p>
                        Customer: <b>{formatForNull(artwork.customerName)}</b>{" "}
                    </p>
                    <p className="d-none d-md-block">
                        Contact: <b>{formatForNull(artwork.customerContact)}</b>
                    </p>
                </div>
                <div className="col-3 d-none d-sm-block row">
                    <p>
                        Sale Price: <b>{formatMoney(artwork.salePrice)}</b>
                    </p>
                    <p>
                        Margin: <b>{formatMoney(artwork.margin)}</b>
                    </p>
                    <p>
                        Sold: <b>{artwork.isPaymentCollected ? "Yes" : "No"}</b>
                    </p>
                </div>
            </div>
        </>
    );
};

export default Artwork;
