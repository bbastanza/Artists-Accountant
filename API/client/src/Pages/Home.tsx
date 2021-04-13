import "./css/Home.css";
import React from "react";
import { useHistory } from "react-router-dom";
import woodburn from "./../Images/woodburn.png";

const Home: React.FC = () => {
    const history = useHistory();

    return (
        <div className="home-container">
            <div className="splash-text-container">
                <h1 className="art-title">
                    Focus on your <span className="accent">Art</span>
                </h1>
                <h1 className="art-title2">
                    We'll do the <span className="accent">Books</span>
                </h1>
                <br />
                <br />
                <div onClick={() => history.push("/myart")} className="spin-btn shadow">
                    enter
                </div>
            </div>
            <img className="splash-img" src={woodburn} alt="woodburn" />
        </div>
    );
};

export default Home;
