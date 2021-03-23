import React from "react";
import Modal from "./Modal";
import { artwork } from "./Artwork";
import "./CSS/ShowMore.css";

interface showMoreProps {
    artwork: artwork;
    setShowMore: Function;
}

const ArtworkShowMore: React.FC<showMoreProps> = ({ artwork, setShowMore }: showMoreProps) => {
    const defaultImageUrl = "https://webstockreview.net/images/easel-clipart-color-pallet-18.png";
    const imageUrl = !!artwork.imgUrl ? artwork.imgUrl : defaultImageUrl;

    return (
        <Modal>
            <div className="modal-container">
                <div className="row inner-modal-container">
                    <img className="col-12 modal-img" src={imageUrl} alt="" />
                    <div className="x-btn" onClick={() => setShowMore(false)}>
                        &times;
                    </div>
                    <div className="col-sm-10 col-md-4 row">
                        <div className="col-5 keys">
                            <h6>Height:</h6>
                            <h6>Width: </h6>
                            <h6 style={{ whiteSpace: "nowrap" }}>Payment Type: </h6>
                            <h6>Commission? </h6>
                            <h6>Paid? </h6>
                            <h6 style={{ whiteSpace: "nowrap" }}>Time Spent: </h6>
                            <h6>Started: </h6>
                            <h6>Finished: </h6>
                        </div>
                        <div className="col-4 values">
                            <h6>{artwork.height}"</h6>
                            <h6>{artwork.width}"</h6>
                            <h6>{artwork.paymentType}</h6>
                            <h6>{artwork.isCommission ? "Yes" : "No"}</h6>
                            <h6>{artwork.isPaymentCollected ? "Yes" : "No"}</h6>
                            <h6>{artwork.timeSpent}</h6>
                            <h6>{artwork.dateStarted.toLocaleDateString()}</h6>
                            <h6>{artwork.dateFinished.toLocaleDateString()}</h6>
                        </div>
                    </div>
                    <div className="col-sm-10 col-md-4 row">
                        <div className="col-5 keys">
                            <h6>Name: </h6>
                            <h6>Customer: </h6>
                            <h6>Contact: </h6>
                            <h6>Shipping: </h6>
                            <h6>Material: </h6>
                            <h6 style={{ whiteSpace: "nowrap" }}>Sale Price: </h6>
                            <h6>Margin: </h6>
                            <h6>Shape: </h6>
                        </div>
                        <div className="col-4 values">
                            <h6>{artwork.pieceName}</h6>
                            <h6>{artwork.customerName}</h6>
                            <h6>{artwork.customerContact}</h6>
                            <h6>{artwork.shippingCost}</h6>
                            <h6>{artwork.materialCost}</h6>
                            <h6>{artwork.salePrice}</h6>
                            <h6>{artwork.margin}</h6>
                            <h6>{artwork.shape}</h6>
                        </div>
                    </div>
                </div>
            </div>
        </Modal>
    );
};

export default ArtworkShowMore;
