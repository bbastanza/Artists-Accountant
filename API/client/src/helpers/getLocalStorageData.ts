import { UserAuthData } from "./interfaces";

export const getLocalStorageData = (): UserAuthData => {
    return JSON.parse(localStorage.getItem("UserData"));
};
