export const getLocalStorageData = () => {
    return JSON.parse(localStorage.getItem("UserData"));
};
