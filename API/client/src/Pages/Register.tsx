import "./css/Login.css";
import React, { useState, useEffect } from "react";
import { useHistory } from "react-router";
import { addUser } from "./../helpers/authRequests";
import { RegisterState, AuthResponseType } from "./../helpers/interfaces";
import purpleBook from "./../Images/purplebook.png";

const Register: React.FC = () => {
    const [state, setState] = useState<RegisterState>({ username: "", password: "", confirmPassword: "" });
    const [matchingPassword, setMatchingPassword] = useState<boolean>(true);
    const [validSubmission, setValidSubmission] = useState<boolean>(true);
    const [registrationError, setRegistrationError] = useState<string>("");
    const history = useHistory();

    useEffect(() => {
        const matchingInput: boolean = state.password === state.confirmPassword;
        const invalidLength: boolean =
            state.password.length !== state.confirmPassword.length || state.password.length < 1;

        if (!matchingInput || invalidLength) return setMatchingPassword(false);
        setMatchingPassword(true);
    }, [state.password, state.confirmPassword]);

    const handleChange = (e): void => {
        setRegistrationError("");
        setValidSubmission(true);
        const { name, value } = e.target;
        setState({ ...state, [name]: value });
    };

    const handleSubmit = async (): Promise<void> => {
        const validInput: boolean = matchingPassword && state.username.length > 0;
        if (!validInput) return setValidSubmission(false);

        const responseType: AuthResponseType = await addUser(state);
        if (responseType === 1) return history.push("/myart");
        if (responseType === 2) return setRegistrationError("Oops! There was an unexpected error. Please try again.");
        setRegistrationError("Oops! A user with that name already exists. Pick another name and try again.");
    };

    return (
        <div className="login-page">
            <img className="login-img" src={purpleBook} alt="purple-book" />
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
                {!validSubmission && <p className="form-error">Passwords do not match.</p>}
                {registrationError.length > 0 && <p className="form-error">{registrationError}</p>}
                <button type="submit" className="btn btn-purple" onClick={handleSubmit}>
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
