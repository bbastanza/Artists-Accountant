import axios from "axios";
import { artwork } from "./interfaces";
import { authAxios } from "./axiosAuthInstance";

export const addArtwork = async (artwork: artwork) => {
    const localStorageData = JSON.parse(localStorage.getItem("UserData"));
    const result = await axios.post("/artworks", { ...artwork, userId: localStorageData.userId });

    console.log(result);
};

export const patchArtwork = async (artwork: artwork) => {
    const localStorageData = JSON.parse(localStorage.getItem("UserData"));
    const result = await authAxios.patch("/artworks", artwork);

    console.log(result);
};
