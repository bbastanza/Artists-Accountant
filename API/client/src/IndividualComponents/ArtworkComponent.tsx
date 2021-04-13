import "./css/Artwork.css";
import React, { useState } from "react";
import { formatMoney, formatForNull } from "./../helpers/beautifyNumber";
import { ArtworkProps } from "./../helpers/interfaces";
import ArtworkShowMore from "./ArtworkShowMore";
import ArtworkForm from "../Forms/ArtworkForm";
import defaultArtworkImage from "../Images/defaultArtworkImage.png";

const ArtworkComponent: React.FC<ArtworkProps> = ({ artwork, updateComponent }: ArtworkProps) => {
    const [showMore, setShowMore] = useState<boolean>(false);
    const [showEdit, setShowEdit] = useState<boolean>(false);

    const imageUrl = !!artwork.imgUrl && artwork.imgUrl !== "null" ? artwork.imgUrl : defaultArtworkImage;

    return (
        <>
            {showMore && <ArtworkShowMore setShowMore={setShowMore} artwork={artwork} imageUrl={imageUrl} />}

            {showEdit && <ArtworkForm setShowEdit={setShowEdit} artwork={artwork} updateComponent={updateComponent} />}

            <div className="row flex-start artwork-container shadow">
                <div className="col-3 img-btn-container">
                    <img className="artwork-img" src={imageUrl} alt="artwork" />
                    <div className="btn-container">
                        <button onClick={() => setShowMore(true)} className="btn btn-purple shadow-sm">
                            More
                        </button>
                        <button onClick={() => setShowEdit(true)} className="btn btn-purple shadow-sm">
                            Edit
                        </button>
                    </div>
                </div>
                <div className="col-6">
                    {!!artwork.pieceName && (
                        <div className="prop-div prop-div-long">
                            <h6 className="key d-none d-sm-block">Name:</h6>
                            <h6 className="value">{formatForNull(artwork.pieceName)}</h6>
                        </div>
                    )}
                    {!!artwork.customerName && (
                        <div className="prop-div prop-div-long">
                            <h6 className="key d-none d-sm-block">Customer:</h6>
                            <h6 className="value">{formatForNull(artwork.customerName)}</h6>
                        </div>
                    )}
                    {!!artwork.salePrice && (
                        <div className="prop-div prop-div-long">
                            <h6 className="key d-none d-sm-block">Sale Price:</h6>
                            <h6 className="value">{formatMoney(artwork.salePrice)}</h6>
                        </div>
                    )}
                    {!!artwork.margin && (
                        <div className="prop-div prop-div-long d-none d-sm-flex">
                            <h6 className="key">Margin:</h6>
                            <h6 className="value">{formatMoney(artwork.margin)}</h6>
                        </div>
                    )}
                </div>
            </div>
        </>
    );
};

export default ArtworkComponent;
