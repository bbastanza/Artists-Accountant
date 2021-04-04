import axios from "axios";
import { UserAuthData, UserInput, AuthResponseType } from "./interfaces";

export const addUser = async (register: UserInput): Promise<AuthResponseType> => {
    try {
        const response = await axios.post("/users", {
            username: register.username,
            password: register.password,
        });
        const userData: UserAuthData = {
            username: response.data.username,
            jwtToken: response.data.jwtToken,
            userId: response.data.id,
        };
        localStorage.setItem("UserData", JSON.stringify(userData));
        return 1;
    } catch (err) {
        if (err.response.status === 461) return 4;
        return 2;
    }
};

export const authenticateLogin = async (login: UserInput): Promise<AuthResponseType> => {
    try {
        const response = await axios.post("/authentication", {
            username: login.username,
            password: login.password,
        });
        const userData: UserAuthData = {
            userId: response.data.id,
            username: response.data.username,
            jwtToken: response.data.jwtToken,
            profileImgUrl: response.data.profileImgUrl,
        };
        localStorage.setItem("UserData", JSON.stringify(userData));
        return 1;
    } catch (err) {
        if (err.response.status === 460) return 3;
        if (err.response.status === 462) return 5;
        return 2;
    }
};
