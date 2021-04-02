import axios, { AxiosInstance } from "axios";

// const localStorageData = JSON.parse(localStorage.getItem("UserData"));
// const bearerToken = localStorageData?.jwtToken;

// export const authAxios: AxiosInstance = !!bearerToken
//     ? axios.create({
//           headers: {
//               Authorization: `Bearer ${bearerToken}`,
//           },
//       })
//     : axios;

export const authAxios = (localStorageData): AxiosInstance => {
    return axios.create({
        headers: {
            Authorization: `Bearer ${localStorageData?.jwtToken}`,
        },
    });
};
