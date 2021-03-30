import { authAxios } from "./axiosAuthInstance";
import { userInput } from "./../helpers/interfaces";

export const getUserData = async (): Promise<object> => {
    try {
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        const result = await authAxios.get(`/users/${localStorageData.userId}`);
        return result.data.artWorks;
    } catch (err) {
        return err;
    }
};

export const deleteUser = async (): Promise<boolean> => {
    try {
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        await authAxios.delete(`/users/${localStorageData.userId}`);
        return true;
    } catch (err) {
        console.log(err);
        return false;
    }
};

export const patchUser = async (userData: userInput): Promise<boolean> => {
    try {
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        await authAxios.patch(`/users`, {
            id: localStorageData.userId,
            username: userData.username,
            password: userData.password,
        });
        return true;
    } catch (err) {
        console.log(err);
        return false;
    }
};
