export interface formProps {
    setShowAddPiece?: Function;
    setShowEdit?: Function;
    userId?: number;
    artwork?: artwork;
}

export interface artworkProps {
    artwork: artwork;
}

export interface showMoreProps {
    artwork: artwork;
    setShowMore: Function;
    defaultImgUrl: string;
}

export interface artwork {
    id?: number;
    userId?: number;
    imgUrl?: string;
    pieceName?: string;
    customerName?: string;
    customerContact?: string;
    shippingCost?: number;
    materialCost?: number;
    salePrice?: number;
    height?: number;
    width?: number;
    timeSpent?: number;
    shape?: string;
    paymentType?: string;
    isCommission?: boolean;
    isPaymentCollected?: boolean;
    dateStarted?: Date;
    dateFinished?: Date;
    margin?: number;
}

export interface userAuthData {
    userId: number;
    username: string;
    jwtToken: string;
}
