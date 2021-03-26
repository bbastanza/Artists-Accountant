import React from "react";
import ReactDOM from "react-dom";
import "./css/Modal.css";

const modalStyle: React.CSSProperties = {
    position: "fixed",
    top: "50%",
    left: "50%",
    maxHeight: "100vh",
    overflowY: "auto",
    transform: "translate(-50%, -50%)",
    zIndex: 1000,
    width: "90vw",
    textAlign: "center",
};

const Modal: React.FC = ({ children }) => {
    return ReactDOM.createPortal(
        <>
            <div className="overlay" />
            <div style={modalStyle}>{children}</div>
        </>,
        document.getElementById("portal")
    );
};

export default Modal;
