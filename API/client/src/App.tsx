import React from "react";
import "./App.css";
import ArtistNavbar from "./FixedComponents/ArtistNavbar";
import ImageUploader from "./IndividualComponents/ImageUploader";
import woodburn from "./Images/woodburn.png";

const App: React.FC = () => {
    const box = {
        height: "6rem",
        width: "6rem",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        margin: "auto",
    };
    const returnImage = (file: any) => {
        const artWork = {
            customerName: "Brian",
        };
        artWork["imageUrl"] = file;
        console.log("artwork: ", artWork);
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
                        position: "relative",
                        minWidth: 300,
                    }}>
                    <div className="splash-text-container">
                        <h1 className="title">
                            Focus on your <span className="accent">Art</span>
                        </h1>
                        <h1 className="title2">
                            We'll do the <span className="accent">Books</span>
                        </h1>
                        <br />
                        <br />
                        <div className="spin-btn" style={box}>
                            enter
                        </div>
                    </div>
                    <img className="splash-img" src={woodburn} alt="" />
                </div>
            </div>
        </>
    );
};

export default App;
