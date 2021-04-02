import { authAxios } from "./axiosAuthInstance";
import { UserInput } from "./../helpers/interfaces";
import { ResponseType } from "./interfaces";
import { getLocalStorageData } from "./getLocalStorageData";

export const getUserData = async (): Promise<any> => {
    try {
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        if (!!localStorageData) {
            const result = await authAxios(localStorageData).get(`/users/${localStorageData.userId}`);
            return result.data;
        }
        return null;
    } catch (err) {
        if (err.response.status === 401) return 401;
        return null;
    }
};

export const deleteUser = async (): Promise<ResponseType> => {
    try {
        const localStorageData = getLocalStorageData();
        if (!!localStorageData) {
            await authAxios(localStorageData).delete(`/users/${localStorageData.userId}`);
            return 1;
        }
        return 2;
    } catch (err) {
        if (err.response.status === 401) return 3;
        return 2;
    }
};

export const patchUser = async (userData: UserInput): Promise<ResponseType> => {
    try {
        const localStorageData = getLocalStorageData();
        if (!!localStorageData) {
            await authAxios(localStorageData).patch(`/users`, {
                id: localStorageData.userId,
                username: userData.username,
                password: userData.password,
            });
            return 1;
        }
        return 2;
    } catch (err) {
        if (err.response.status === 401) return 3;
        return 2;
    }
};
