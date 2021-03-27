import axios from "axios";
import { authAxios } from "./axiosAuthInstance";

export const getUserData = async () => {
    const localStorageData = JSON.parse(localStorage.getItem("UserData"));
    const result = await authAxios.get(`/users/${localStorageData.userId}`);
    console.log(result);

    return result.data.artWorks;
};
