import axios from "axios";

export const authAxios = axios.create({
    headers: {
        Authorization: `Bearer ${JSON.parse(localStorage.getItem("UserData")).jwtToken}`,
    },
});
