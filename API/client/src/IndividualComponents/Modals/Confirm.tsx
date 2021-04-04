import React from "react";
import Modal from "./../Modal";
import "./css/Confirm.css";

interface ConfirmProps {
    cancelDelete: Function;
    confirmDelete: Function;
}

const Confirm: React.FC<ConfirmProps> = ({ cancelDelete, confirmDelete }: ConfirmProps) => {
    return (
        <Modal>
            <div className="confirm-container offset-1">
                <h3>Are you sure?</h3>
                <button onClick={() => confirmDelete()} className="btn btn-red">
                    Yes
                </button>
                <button onClick={() => cancelDelete()} className="btn btn-purple">
                    No
                </button>
            </div>
        </Modal>
    );
};

export default Confirm;
