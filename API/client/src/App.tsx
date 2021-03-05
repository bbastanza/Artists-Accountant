import React from "react";
import "./App.css";
import ArtistNavbar from "./FixedComponents/ArtistNavbar";
import ImageUploader from "./IndividualComponents/ImageUploader";

const App: React.FC = () => {
    const box = {
        height: "6rem",
        width: "6rem",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
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
                <ImageUploader returnImage={returnImage} />
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
