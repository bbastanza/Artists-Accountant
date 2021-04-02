import axios from "axios";
import { UserAuthData, UserInput } from "./interfaces";

export const addUser = async (register: UserInput): Promise<boolean> => {
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
        return true;
    } catch (err) {
        return false;
    }
};

export const authenticateLogin = async (login: UserInput): Promise<boolean> => {
    try {
        const response = await axios.post("/authentication", {
            username: login.username,
            password: login.password,
        });
        const userData: UserAuthData = {
            userId: response.data.id,
            username: response.data.username,
            jwtToken: response.data.jwtToken,
        };
        localStorage.setItem("UserData", JSON.stringify(userData));
        await new Promise(() => {
            setTimeout(() => {}, 1000);
        });
        return true;
    } catch (err) {
        return false;
    }
};
