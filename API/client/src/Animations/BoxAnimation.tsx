import "./css/BoxAnimation.css";
import React from "react";
import Modal from "./../IndividualComponents/Modal";

const BoxAnimation: React.FC = () => {
    return (
        <Modal>
            <div className="box-container">
                <div className="box"></div>
                <div className="box box-2"></div>
                <div className="box box-3"></div>
                <div className="box box-4"></div>
            </div>
        </Modal>
    );
};

export default BoxAnimation;
