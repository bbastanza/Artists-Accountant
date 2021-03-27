import axios from "axios";
import { userAuthData } from "./interfaces";

// TODO => try catch
export const addUser = async register => {
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
};

// TODO => try catch
export const authenticateLogin = async login => {
    const response = await axios.post("/authentication", {
        username: login.username,
        password: login.password,
    });
    console.log(response);

    const userData: userAuthData = {
        userId: response.data.id,
        username: response.data.username,
        jwtToken: response.data.jwtToken,
    };

    return userData;
};
