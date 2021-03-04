import React from "react";
import "./App.css";
import {ArtistNavbar} from "./FixedComponents/ArtistNavbar"

const App: React.FC = () => {
    const box = {
        height: "6rem",
        width: "6rem",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
    };

    return (
        <>
            <ArtistNavbar />
        <div className="App">
            <div
                style={{
                    display: "flex",
                    justifyContent: "space-evenly",
                    alignItems: "center",
                    height: "80vh",
                }}>
                <div className="spin-btn" style={box}>
                    enter 
                </div>
            </div>
        </div>
        </>
    );
};

export default App;
