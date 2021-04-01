import { authAxios } from "./axiosAuthInstance";
import { UserInput } from "./../helpers/interfaces";
import { UserData, ResponseType } from "./interfaces";

export const getUserData = async (): Promise<UserData> => {
    try {
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        if (!!localStorageData) {
            const result = await authAxios.get(`/users/${localStorageData.userId}`);
            return result.data;
        }
    } catch (err) {
        // TODO what to return if unauthorized
        console.log({ error: err.response.status });
        return null;
    }
};

export const deleteUser = async (): Promise<ResponseType> => {
    try {
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        if (!!localStorageData) {
            await authAxios.delete(`/users/${localStorageData.userId}`);
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
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        if (localStorageData) {
            await authAxios.patch(`/users`, {
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
