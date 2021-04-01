import axios, { AxiosInstance } from "axios";

const localStorageData = JSON.parse(localStorage.getItem("UserData"));
let bearerToken;
if (!!localStorageData) bearerToken = localStorageData.jwtToken;

export const authAxios: AxiosInstance = !!bearerToken
    ? axios.create({
          headers: {
              Authorization: `Bearer ${bearerToken}`,
          },
      })
    : axios;
