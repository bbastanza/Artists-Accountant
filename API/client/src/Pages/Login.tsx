import React, { useState } from "react";
import { useHistory } from "react-router";
import { AuthResponseType, LoginState } from "../helpers/interfaces";
import { authenticateLogin } from "./../helpers/authRequests";
import purpleBook from "./../Images/purplebook.png";
import "./css/Login.css";

const Login: React.FC = () => {
    const [state, setState] = useState<LoginState>({ username: "", password: "" });
    const [validSubmission, setValidSubmission] = useState<boolean>(true);
    const [loginError, setLoginError] = useState<string>("");
    const history = useHistory();

    const handleChange = e => {
        setLoginError("");
        setValidSubmission(true);
        const { name, value } = e.target;
        setState({ ...state, [name]: value });
    };

    const handleSubmit = async () => {
        const validInput: boolean = state.password.length > 0 && state.username.length > 0;
        if (!validInput) return setValidSubmission(false);

        const responseType: AuthResponseType = await authenticateLogin(state);
        if (responseType === 1) return history.push("/myart");
        if (responseType === 2) return setLoginError("Oops! There was an unexpected error. Please try again.");
        if (responseType === 3)
            return setLoginError("Oops! Your password is invalid. Check your credentials and try again.");
        setLoginError("Oops! A user with that name does not exist. Check your credentials and try again.");
    };

    return (
        <div className="login-page">
            <img className="login-img" src={purpleBook} alt="purple-book" />
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
                {!validSubmission && <p className="form-error">Please fill out all fields.</p>}
                {loginError.length > 0 && <p className="form-error">{loginError}</p>}
                <button onClick={handleSubmit} type="submit" className="btn btn-purple">
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
