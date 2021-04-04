/*  */ import React from "react";
import Modal from "./../IndividualComponents/Modal";
import "./css/BoxAnimation.css";

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
