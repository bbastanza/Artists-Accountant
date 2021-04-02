import React from "react";
import woodburn from "./../Images/woodburn.png";
import { useHistory } from "react-router-dom";

const Home: React.FC = () => {
    const history = useHistory();
    const box = {
        height: "6rem",
        width: "6rem",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        margin: "auto",
    };

    return (
        <div
            style={{
                display: "flex",
                justifyContent: "space-evenly",
                alignItems: "center",
                height: "80vh",
                position: "relative",
                minWidth: 300,
                textAlign: "center",
            }}>
            <div className="splash-text-container">
                <h1 className="art-title">
                    Focus on your <span className="accent">Art</span>
                </h1>
                <h1 className="art-title2">
                    We'll do the <span className="accent">Books</span>
                </h1>
                <br />
                <br />
                <div onClick={() => history.push("/myart")} className="spin-btn" style={box}>
                    enter
                </div>
            </div>
            <img className="splash-img" src={woodburn} alt="" />
        </div>
    );
};

export default Home;
