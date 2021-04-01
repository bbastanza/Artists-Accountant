import React, { useState } from "react";
import Modal from "../IndividualComponents/Modal";
import "./css/Form.css";
import { FormProps, Artwork } from "./../helpers/interfaces";
import { addArtwork, patchArtwork, deleteArtwork } from "./../helpers/artworkRequests";

const ArtworkForm: React.FC<FormProps> = ({ setShowEdit, setShowAddPiece, artwork, updateComponent }: FormProps) => {
    const isAddNewArtwork: boolean = !!!artwork;
    const [apiError, setApiError] = useState<boolean>(false);
    const [canSubmit, setCanSubmit] = useState<boolean>(false);

    const [state, setState] = useState<Artwork>(
        isAddNewArtwork
            ? {
                  id: null,
                  pieceName: null,
                  customerName: null,
                  customerContact: null,
                  shippingCost: null,
                  materialCost: null,
                  salePrice: null,
                  heightInches: null,
                  widthInches: null,
                  timeSpentMinutes: null,
                  shape: "round",
                  paymentType: "cash",
                  isCommission: false,
                  isPaymentCollected: false,
                  dateStarted: null,
                  dateFinished: null,
              }
            : artwork
    );

    const handleChange = e => {
        if (!canSubmit) setCanSubmit(true);
        const { name, value, type, checked } = e.target;
        console.log(name, value, type);

        if (type === "number") return setState({ ...state, [name]: parseFloat(value) });
        if (type === "checkbox") return setState({ ...state, [name]: checked });
        setState({ ...state, [name]: value });
    };

    const addNewArtwork = async (e): Promise<void> => {
        e.preventDefault();

        const successfulAdd = await addArtwork(state);
        if (successfulAdd) return setShowAddPiece(false);

        setApiError(true);
    };

    const patchExistingArtwork = async (e): Promise<void> => {
        e.preventDefault();

        const successfulPatch = await patchArtwork(state);
        if (successfulPatch) return updateComponent();

        setApiError(true);
    };

    const deletePiece = async (e): Promise<void> => {
        e.preventDefault();
        const successfulDelete = await deleteArtwork(artwork.id);

        if (successfulDelete) return updateComponent();

        setApiError(true);
    };

    const cancelSubmission = (): void => {
        if (isAddNewArtwork) return setShowAddPiece(false);
        setShowEdit(false);
    };

    console.log(state);
    return (
        <Modal>
            <form
                onSubmit={e => (isAddNewArtwork ? addNewArtwork(e) : patchExistingArtwork(e))}
                className="modal-container">
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
                        <label htmlFor="heightInches">Height (inches)</label>
                        <input
                            type="number"
                            name="heightInches"
                            value={!!state.heightInches ? state.heightInches : ""}
                            onChange={e => handleChange(e)}
                            className="form-control"
                            id="height"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="widthInches">Width (inches)</label>
                        <input
                            type="number"
                            name="widthInches"
                            value={!!state.widthInches ? state.widthInches : ""}
                            onChange={e => handleChange(e)}
                            className="form-control"
                            id="width"
                        />
                    </div>
                    <div className="form-group col-sm-12 col-md-4">
                        <label htmlFor="timeSpentMinutes">Time Spent (minutes)</label>
                        <input
                            type="number"
                            name="timeSpentMinutes"
                            value={!!state.timeSpentMinutes ? state.timeSpentMinutes : ""}
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
                            defaultValue={new Date(state.dateStarted).toString() || ""}
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
                    <div className="btn-container">
                        {!isAddNewArtwork ? (
                            <button type="button" onClick={deletePiece} className="btn btn-red col-12">
                                Delete
                            </button>
                        ) : null}
                        <button type="button" onClick={cancelSubmission} className="btn btn-purple col-12">
                            Cancel
                        </button>
                        {canSubmit ? (
                            <button type="submit" className="btn btn-purple col-12">
                                {isAddNewArtwork ? "Add My Art!" : "Apply Changes"}
                            </button>
                        ) : null}
                    </div>
                    {apiError ? (
                        <p className="col-12 form-error" style={{ paddingTop: 20 }}>
                            Oops! Something unexpected happeded. Please try again.
                        </p>
                    ) : null}
                </div>
            </form>
        </Modal>
    );
};

export default ArtworkForm;
