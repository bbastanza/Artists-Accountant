import axios from "axios";

interface userData {
    userId: number;
    username: string;
    jwtToken: string;
}

// TODO => try catch
export const addUser = async register => {
    const response = await axios.post("/users", {
        username: register.username,
        password: register.password,
    });

    const userData: userData = {
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

    // const userData: userData = {
    //     userId: response.data.id,
    //     username: response.data.username,
    //     jwtToken: response.data.jwtToken,
    // };

    // return userData;
};
