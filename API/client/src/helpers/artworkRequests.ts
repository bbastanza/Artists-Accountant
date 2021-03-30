import { artwork } from "./interfaces";
import { authAxios } from "./axiosAuthInstance";

export const addArtwork = async (artwork: artwork): Promise<boolean> => {
    try {
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        await authAxios.post("/artworks", { ...artwork, userId: localStorageData.userId });
        return true;
    } catch (err) {
        console.log(err);
        return false;
    }
};

export const patchArtwork = async (artwork: artwork): Promise<boolean> => {
    try {
        await authAxios.patch("/artworks", artwork);
        return true;
    } catch (err) {
        console.log(err);
        return false;
    }
};

export const deleteArtwork = async (artworkId: number): Promise<boolean> => {
    try {
        await authAxios.delete(`/artworks/${artworkId}`);
        return true;
    } catch (err) {
        console.log(err);
        return false;
    }
};
