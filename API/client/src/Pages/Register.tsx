import React, { useState, useEffect } from "react";
import { useHistory } from "react-router";
import { addUser } from "./../helpers/authRequests";
import "./css/Login.css";

interface registerState {
    username: string;
    password: string;
    confirmPassword: string;
}

const Register: React.FC = () => {
    const [state, setState] = useState<registerState>({ username: "", password: "", confirmPassword: "" });
    const [matchingPassword, setMatchingPassword] = useState<boolean>(true);
    const [validSubmission, setValidSubmission] = useState<boolean>(true);
    const history = useHistory();

    useEffect(() => {
        const matchingInput: boolean = state.password === state.confirmPassword;
        const invalidLength: boolean =
            state.password.length !== state.confirmPassword.length || state.password.length < 1;

        if (!matchingInput || invalidLength) return setMatchingPassword(false);

        setMatchingPassword(true);
    }, [state.password, state.confirmPassword]);

    const handleChange = e => {
        setValidSubmission(true);
        const { name, value } = e.target;
        setState({ ...state, [name]: value });
    };

    const handleSubmit = async () => {
        const validInput: boolean = matchingPassword && state.username.length > 0;
        if (!validInput) return setValidSubmission(false);

        // TODO error handling
        const data = await addUser(state);
        localStorage.setItem("UserData", JSON.stringify(data));
    };

    return (
        <div className="login-page">
            <img className="login-img" src="https://clipartart.com/images/purple-book-clipart-2.png" alt="book" />
            <h1 className="title">
                Join <span className="accent">ArtistAccountant</span>
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
                <div className="form-group">
                    <label htmlFor="confirmPassword">Confirm Password</label>
                    <input
                        type="password"
                        name="confirmPassword"
                        value={state.confirmPassword}
                        onChange={e => handleChange(e)}
                        className="form-control"
                        id="confirmPassword"
                    />
                </div>
                {!!!validSubmission ? <p className="form-error">Passwords do not match.</p> : null}
                <button type="submit" className="btn btn-purple" onClick={() => handleSubmit()}>
                    Create Account
                </button>
            </div>
            <div className="switch-login-box">
                <p>Already have an account?</p>
                <p className="artist-link" onClick={() => history.push("/login")}>
                    Sign in.
                </p>
            </div>
        </div>
    );
};

export default Register;
