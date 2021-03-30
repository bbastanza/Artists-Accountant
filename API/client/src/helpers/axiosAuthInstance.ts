import axios, { AxiosInstance } from "axios";

export const authAxios: AxiosInstance = axios.create({
    headers: {
        Authorization: `Bearer ${JSON.parse(localStorage.getItem("UserData")).jwtToken}`,
    },
});
