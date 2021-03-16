import React from "react";
import ReactDOM from "react-dom";

const modalStyle: React.CSSProperties = {
    position: "fixed",
    top: "50%",
    left: "50%",
    maxHeight: "100vh",
    overflowY: "auto",
    transform: "translate(-50%, -50%)",
    zIndex: 1000,
    color: "#ffc107",
    width: "80vw",
    textAlign: "center",
};

const overlayStyle: React.CSSProperties = {
    position: "fixed",
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: "rgba(0,0,0,.7)",
    zIndex: 1000,
};

const Modal: React.FC = ({ children }) => {
    return ReactDOM.createPortal(
        <>
            <div style={modalStyle}>{children}</div>
            <div style={overlayStyle} />
        </>,
        document.getElementById("portal")
    );
};

export default Modal;
