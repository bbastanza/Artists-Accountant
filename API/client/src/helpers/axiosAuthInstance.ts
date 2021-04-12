import axios, { AxiosInstance } from "axios";

export const authAxios = (localStorageData): AxiosInstance => {
    return axios.create({
        headers: {
            Authorization: `Bearer ${localStorageData?.jwtToken}`,
        },
    });
};
