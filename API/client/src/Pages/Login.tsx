import React, { useState } from "react";
import { useHistory } from "react-router";
import "./css/Login.css";

interface loginState {
    username: string;
    password: string;
}

const Login: React.FC = () => {
    const [state, setState] = useState<loginState>({ username: "", password: "" });
    const history = useHistory();

    const handleChange = e => {
        const { name, value } = e.target;
        setState({ ...state, [name]: value });
    };

    return (
        <div className="login-page">
            <img className="login-img" src="https://clipartart.com/images/purple-book-clipart-2.png" alt="book" />
            <h1 className="title">
                Sign in to <p className="accent">ArtistAccountant</p>
            </h1>
            <div className="login-box">
                <div className="form-group">
                    <label htmlFor="username">Username</label>
                    <input
                        type="text"
                        name="username"
                        value={state.username}
                        onChange={e => handleChange(e)}
                        className="form-control"
                        id="username"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input
                        type="password"
                        name="password"
                        value={state.password}
                        onChange={e => handleChange(e)}
                        className="form-control"
                        id="password"
                    />
                </div>
                <button type="submit" className="btn btn-purple">
                    Sign In
                </button>
            </div>
            <div className="switch-login-box">
                <p>New to ArtistAccountant? </p>
                <p className="artist-link" onClick={() => history.push("/register")}>
                    Create an account.
                </p>
            </div>
        </div>
    );
};

export default Login;
