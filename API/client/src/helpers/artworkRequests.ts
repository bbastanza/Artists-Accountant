import { Artwork, ResponseType } from "./interfaces";
import { authAxios } from "./axiosAuthInstance";
import { getLocalStorageData } from "./getLocalStorageData";

export const addArtwork = async (artwork: Artwork): Promise<ResponseType> => {
    try {
        const localStorageData = getLocalStorageData();
        if (!!localStorageData) {
            await authAxios(localStorageData).post("/artworks", { ...artwork, userId: localStorageData.userId });
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
        const localStorageData = getLocalStorageData();
        if (!!localStorageData) {
            await authAxios(localStorageData).patch("/artworks", artwork);
            return 1;
        }
        return 2;
    } catch (err) {
        if (err.response.status === 401) return 3;
        return 2;
    }
};

export const deleteArtwork = async (artworkId: number): Promise<ResponseType> => {
    try {
        const localStorageData = getLocalStorageData();
        if (!!localStorageData) {
            await authAxios(localStorageData).delete(`/artworks/${artworkId}`);
            return 1;
        }
        return 2;
    } catch (err) {
        if (err.response.status === 401) return 3;
        return 2;
    }
};
