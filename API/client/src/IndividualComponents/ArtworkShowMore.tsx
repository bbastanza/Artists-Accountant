import React from "react";
import Modal from "./Modal";
import { artwork } from "./Artwork";
import DateTime from "luxon";

interface showMoreProps {
    artwork: artwork;
    setShowMore: Function;
}

const modalContainer: React.CSSProperties = {
    width: "80vw",
    height: "90vh",
    minWidth: 300,
    background: "white",
    border: "2px solid purple",
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    color: "#313131",
    overflow: "hidden",
    textAlign: "left",
    margin: "auto",
};
const ArtworkShowMore: React.FC<showMoreProps> = ({ artwork, setShowMore }: showMoreProps) => {
    const defaultImageUrl =
        "https://rlv.zcache.com/svc/view?realview=113070396694079804&design=0e2557d4-ca0f-4d5d-ab28-5a3543e6d157&rlvnet=1&style=standard_apron&max_dim=180&hide=bleed%2Csafe%2Cvisible%2CvisibleMask";
    const imageUrl = !!artwork.imgUrl ? artwork.imgUrl : defaultImageUrl;

    return (
        <Modal>
            <div style={modalContainer}>
                <div className="row" style={{ justifyContent: "center" }}>
                    <img
                        className="offset-1 col-10"
                        style={{ borderRadius: "3%", padding: 30 }}
                        src={imageUrl}
                        alt=""
                    />
                    <div className="offset-1 col-sm-12 col-md-4">
                        <h4>Name: {artwork.pieceName}</h4>
                        <h4>Customer Name: {artwork.customerName}</h4>
                        <h4>Contact: {artwork.customerContact}</h4>
                        <h4>Shipping Cost: {artwork.shippingCost}</h4>
                        <h4>Material Cost: {artwork.materialCost}</h4>
                        <h4>Sale Price: {artwork.salePrice}</h4>
                        <h4>Margin: {artwork.margin}</h4>
                        <h4>Shape: {artwork.shape}</h4>
                    </div>
                    <div className="offset-1 col-sm-12 col-md-4">
                        <h4>Height: {artwork.height}"</h4>
                        <h4>Width: {artwork.width}"</h4>
                        <h4>Payment Type: {artwork.paymentType}</h4>
                        <h4>Commission? {artwork.isCommission ? "Yes" : "No"}</h4>
                        <h4>Payment Collected? {artwork.isPaymentCollected ? "Yes" : "No"}</h4>
                        <h4>Time Spent: {artwork.timeSpent}</h4>
                        <h4>Date Started: {artwork.dateStarted.toLocaleDateString()}</h4>
                        <h4>Date Finished: {artwork.dateFinished.toLocaleDateString()}</h4>
                    </div>
                </div>
            </div>
        </Modal>
    );
};

export default ArtworkShowMore;
