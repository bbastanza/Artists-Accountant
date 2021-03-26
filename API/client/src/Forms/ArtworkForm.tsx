import React, { useState } from "react";
import Modal from "../IndividualComponents/Modal";
import { artwork } from "../IndividualComponents/Artwork";
import "./css/Form.css";

interface props {
    setShowAddPiece?: Function;
    setShowEdit?: Function;
    userId?: number;
    artwork?: artwork;
}

const ArtworkForm: React.FC<props> = ({ setShowEdit, setShowAddPiece, userId, artwork }: props) => {
    const [state, setState] = useState<artwork>(
        !!!artwork
            ? {
                  id: userId,
                  pieceName: null,
                  customerName: null,
                  customerContact: null,
                  shippingCost: null,
                  materialCost: null,
                  salePrice: null,
                  height: null,
                  width: null,
                  timeSpent: null,
                  shape: "round",
                  paymentType: "cash",
                  isCommission: null,
                  isPaymentCollected: null,
                  dateStarted: null,
                  dateFinished: null,
              }
            : artwork
    );
    const handleChange = e => {
        const { name, value, type, checked } = e.target;
        type === "checkbox" ? setState({ ...state, [name]: checked }) : setState({ ...state, [name]: value });
    };

    return (
        <Modal>
            <div className="modal-container">
                <div className="inner-modal-container row">
                    <div
                        className="x-btn"
                        onClick={() => (!!setShowAddPiece ? setShowAddPiece(false) : setShowEdit(false))}>
                        &times;
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="pieceName">Piece Name</label>
                        <input
                            type="text"
                            name="pieceName"
                            value={!!state.pieceName ? state.pieceName : ""}
                            onChange={e => handleChange(e)}
                            className="form-control"
                            id="pieceName"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="customerName">Customer Name</label>
                        <input
                            type="text"
                            name="customerName"
                            value={!!state.customerName ? state.customerName : ""}
                            onChange={e => handleChange(e)}
                            className="form-control"
                            id="customerName"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="customerContact">Customer Contact</label>
                        <input
                            type="text"
                            name="customerContact"
                            value={!!state.customerContact ? state.customerContact : ""}
                            onChange={e => handleChange(e)}
                            className="form-control"
                            id="customerContact"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="salePrice">Sale Price</label>
                        <input
                            type="number"
                            name="salePrice"
                            value={!!state.salePrice ? state.salePrice : ""}
                            onChange={e => handleChange(e)}
                            step=".01"
                            className="form-control"
                            id="salePrice"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="shippingCost">Shipping Cost</label>
                        <input
                            type="number"
                            name="shippingCost"
                            value={!!state.shippingCost ? state.shippingCost : ""}
                            onChange={e => handleChange(e)}
                            step=".01"
                            className="form-control"
                            id="shippingCost"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="materialCost">Material Cost</label>
                        <input
                            type="number"
                            name="materialCost"
                            value={!!state.materialCost ? state.materialCost : ""}
                            onChange={e => handleChange(e)}
                            step=".01"
                            className="form-control"
                            id="materialCost"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="height">Height (inches)</label>
                        <input
                            type="number"
                            name="height"
                            value={!!state.height ? state.height : ""}
                            onChange={e => handleChange(e)}
                            className="form-control"
                            id="height"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="width">Width (inches)</label>
                        <input
                            type="number"
                            name="width"
                            value={!!state.width ? state.width : ""}
                            onChange={e => handleChange(e)}
                            className="form-control"
                            id="width"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="timeSpent">Time Spent (minutes)</label>
                        <input
                            type="number"
                            name="timeSpent"
                            value={!!state.timeSpent ? state.timeSpent : ""}
                            onChange={e => handleChange(e)}
                            className="form-control"
                            id="timeSpent"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-6">
                        <label htmlFor="shape">Shape</label>
                        <select
                            className="form-control"
                            name="shape"
                            value={!!state.shape ? state.shape : ""}
                            onChange={e => handleChange(e)}
                            id="shape">
                            <option value=""></option>
                            <option value="round">Round</option>
                            <option value="square">Square</option>
                            <option value="rectangle">Rectangle</option>
                            <option value="other">Other</option>
                        </select>
                    </div>
                    <div className="form-group col-sm-12 col-md-6">
                        <label htmlFor="paymentType">Payment Type</label>
                        <select
                            className="form-control"
                            name="paymentType"
                            value={!!state.paymentType ? state.paymentType : ""}
                            onChange={e => handleChange(e)}
                            id="paymentType">
                            <option value=""></option>
                            <option value="cash">Cash</option>
                            <option value="credit">Credit Card</option>
                            <option value="check">Check</option>
                            <option value="venmo">Venmo</option>
                        </select>
                    </div>
                    <div className="form-group form-check col-12">
                        <input
                            type="checkbox"
                            name="isPaymentCollected"
                            checked={state.isPaymentCollected}
                            onChange={e => handleChange(e)}
                            className="pad"
                            id="isPaymentCollected"
                        />
                        <label htmlFor="isPaymentCollected">Sold?</label>
                    </div>
                    <div className="form-group form-check col-12">
                        <input
                            type="checkbox"
                            name="isCommission"
                            checked={state.isCommission}
                            onChange={e => handleChange(e)}
                            className="pad"
                            id="isCommission"
                        />
                        <label htmlFor="isCommission">Commission?</label>
                    </div>
                    <div className="form-group date col-12">
                        <label htmlFor="dateStarted">Date Started</label>
                        <input
                            type="date"
                            name="dateStarted"
                            onChange={e => handleChange(e)}
                            className="date pad"
                            id="dateStarted"
                        />
                    </div>
                    <div className="form-group date col-12">
                        <label htmlFor="dateFinished">Date Finished</label>
                        <input
                            type="date"
                            name="dateFinished"
                            onChange={e => handleChange(e)}
                            className="date pad"
                            id="dateFinished"
                        />
                    </div>
                    <button type="submit" className="btn btn-purple">
                        {artwork ? "Apply Changes" : "Add My Art!"}
                    </button>
                </div>
            </div>
        </Modal>
    );
};

export default ArtworkForm;
