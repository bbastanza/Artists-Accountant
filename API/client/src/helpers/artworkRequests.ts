import { Artwork, ResponseType } from "./interfaces";
import { authAxios } from "./axiosAuthInstance";

export const addArtwork = async (artwork: Artwork): Promise<ResponseType> => {
    try {
        const localStorageData = JSON.parse(localStorage.getItem("UserData"));
        if (!!localStorageData) {
            await authAxios.post("/artworks", { ...artwork, userId: localStorageData.userId });
            return 1;
        }
        return 2;
    } catch (err) {
        if (err.response.status === 401) return 3;
        return 2;
    }
};

export const patchArtwork = async (artwork: Artwork): Promise<ResponseType> => {
    try {
        await authAxios.patch("/artworks", artwork);
        return 1;
    } catch (err) {
        if (err.response.status === 401) return 3;
        return 2;
    }
};

export const deleteArtwork = async (artworkId: number): Promise<ResponseType> => {
    try {
        await authAxios.delete(`/artworks/${artworkId}`);
        return 1;
    } catch (err) {
        if (err.response.status === 401) return 3;
        return 2;
    }
};
