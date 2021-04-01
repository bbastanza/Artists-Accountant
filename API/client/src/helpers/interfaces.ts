export interface FormProps {
    setShowAddPiece?: Function;
    setShowEdit?: Function;
    updateComponent?: Function;
    artwork?: Artwork;
}

export interface ArtworkProps {
    artwork: Artwork;
    updateComponent?: Function;
}

export interface ShowMoreProps {
    artwork: Artwork;
    setShowMore: Function;
    imageUrl: string;
}

export interface Artwork {
    id?: number;
    userId?: number;
    imgUrl?: string;
    pieceName?: string;
    customerName?: string;
    customerContact?: string;
    shippingCost?: number;
    materialCost?: number;
    salePrice?: number;
    heightInches?: number;
    widthInches?: number;
    timeSpentMinutes?: number;
    shape?: string;
    paymentType?: string;
    isCommission?: boolean;
    isPaymentCollected?: boolean;
    dateStarted?: Date;
    dateFinished?: Date;
    margin?: number;
}

export interface UserInput {
    username: string;
    password: string;
}

export interface UserAuthData {
    userId: number;
    username: string;
    jwtToken: string;
}

export interface UserData {
    id: number;
    username: string;
    profileImgUrl: string;
    artWorks: Artwork[];
    totalMarginCollected: number;
    totalMarginPotential: number;
    totalUncollectedIncome: number;
    totalCollectedIncome: number;
    totalExpences: number;
}

export enum ResponseType {
    Ok,
    ApplicationError,
    Unauthorized,
}
