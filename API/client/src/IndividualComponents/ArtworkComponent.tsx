import React, { useState } from "react";
import ArtworkShowMore from "./ArtworkShowMore";
import ArtworkForm from "../Forms/ArtworkForm";
import "./css/Artwork.css";
import { formatMoney, formatForNull } from "./../helpers/beautifyNumber";
import { ArtworkProps } from "./../helpers/interfaces";

const ArtworkComponent: React.FC<ArtworkProps> = ({ artwork, updateComponent }: ArtworkProps) => {
    const [showMore, setShowMore] = useState<boolean>(false);
    const [showEdit, setShowEdit] = useState<boolean>(false);

    const defaultImgUrl = "https://clipground.com/images/art-palette-clipart-transparent-5.png";
    const imageUrl = !!artwork.imgUrl ? artwork.imgUrl : defaultImgUrl;

    // TODO move each key/value into thier own div
    return (
        <>
            {showMore ? <ArtworkShowMore setShowMore={setShowMore} artwork={artwork} imageUrl={imageUrl} /> : null}

            {showEdit ? (
                <ArtworkForm setShowEdit={setShowEdit} artwork={artwork} updateComponent={updateComponent} />
            ) : null}

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

export default ArtworkComponent;
