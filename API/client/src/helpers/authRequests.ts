import axios from "axios";
import { userAuthData, userInput } from "./interfaces";

export const addUser = async (register: userInput): Promise<object> => {
    try {
        const response = await axios.post("/users", {
            username: register.username,
            password: register.password,
        });
        const userData: userAuthData = {
            username: response.data.username,
            jwtToken: response.data.jwtToken,
            userId: response.data.id,
        };
        return userData;
    } catch (err) {
        return err;
    }
};

export const authenticateLogin = async (login: userInput): Promise<object> => {
    try {
        const response = await axios.post("/authentication", {
            username: login.username,
            password: login.password,
        });
        const userData: userAuthData = {
            userId: response.data.id,
            username: response.data.username,
            jwtToken: response.data.jwtToken,
        };
        return userData;
    } catch (err) {
        return err;
    }
};
