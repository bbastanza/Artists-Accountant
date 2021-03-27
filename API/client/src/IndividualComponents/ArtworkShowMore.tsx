import React from "react";
import Modal from "./Modal";
import { showMoreProps } from "./../helpers/interfaces";
import { checkBool, checkDate, formatForNull, formatMoney, formatSize, formatTime } from "./../helpers/beautifyNumber";
import "./css/ShowMore.css";

const ArtworkShowMore: React.FC<showMoreProps> = ({ artwork, setShowMore, defaultImgUrl }: showMoreProps) => {
    const imageUrl = !!artwork.imgUrl ? artwork.imgUrl : defaultImgUrl;

    return (
        <Modal>
            <div className="modal-container">
                <div className="inner-modal-container row">
                    <img className="modal-img" src={imageUrl} alt="" />
                    <div className="x-btn" onClick={() => setShowMore(false)}>
                        &times;
                    </div>
                    <div className="col-12 row">
                        <div className="col-sm-12 col-md-6">
                            <div className="prop-div">
                                <h6 className="key">Customer:</h6>
                                <h6 className="value">{formatForNull(artwork.customerName)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Contact:</h6>
                                <h6 className="value">{formatForNull(artwork.customerContact)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Name:</h6>
                                <h6 className="value">{formatForNull(artwork.pieceName)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Sale Price:</h6>
                                <h6 className="value">{formatMoney(artwork.salePrice)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Margin:</h6>
                                <h6 className="value">{formatMoney(artwork.margin)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Material Cost:</h6>
                                <h6 className="value">{formatMoney(artwork.materialCost)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Shipping Cost:</h6>
                                <h6 className="value">{formatMoney(artwork.shippingCost)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Payment Type:</h6>
                                <h6 className="value caps">{formatForNull(artwork.paymentType)}</h6>
                            </div>
                        </div>
                        <div className="col-sm-12 col-md-6">
                            <div className="prop-div">
                                <h6 className="key">Sold?</h6>
                                <h6 className="value">{checkBool(artwork.isPaymentCollected)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Commission?</h6>
                                <h6 className="value">{checkBool(artwork.isCommission)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Height:</h6>
                                <h6 className="value">{formatSize(artwork.height)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Width:</h6>
                                <h6 className="value">{formatSize(artwork.width)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Time Spent:</h6>
                                <h6 className="value">{formatTime(artwork.timeSpent)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Date Started:</h6>
                                <h6 className="value">{checkDate(artwork.dateStarted)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Date Finished:</h6>
                                <h6 className="value">{checkDate(artwork.dateFinished)}</h6>
                            </div>
                            <div className="prop-div">
                                <h6 className="key">Shape:</h6>
                                <h6 className="value caps">{formatForNull(artwork.shape)}</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </Modal>
    );
};

export default ArtworkShowMore;
