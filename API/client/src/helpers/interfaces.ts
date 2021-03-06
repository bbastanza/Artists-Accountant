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
    username?: string;
    password?: string;
    profileImgUrl?: string;
}

export interface UserAuthData {
    userId: number;
    username: string;
    jwtToken: string;
    profileImgUrl?: string;
}

export interface UserData {
    id?: number;
    username?: string;
    profileImgUrl?: string;
    artWorks?: Artwork[];
    totalMarginCollected?: number;
    totalMarginPotential?: number;
    totalUncollectedIncome?: number;
    totalCollectedIncome?: number;
    totalExpenses?: number;
}

export interface LoginState {
    username: string;
    password: string;
}

export interface RegisterState {
    username: string;
    password: string;
    confirmPassword: string;
}

export interface FormProps {
    setShowAddPiece?: Function;
    setShowEdit?: Function;
    updateComponent: Function;
    artwork?: Artwork;
}

export interface ArtworkProps {
    artwork: Artwork;
    updateComponent: Function;
}

export interface ShowMoreProps {
    artwork: Artwork;
    setShowMore: Function;
    imageUrl: string;
}

export interface ChartProps {
    artworks: Artwork[];
}

export interface TableProps {
    userData: UserData;
}

export interface ModalProps {
    children: React.ReactNode;
}

export interface ImageUploaderProps {
    saveImgUrl: Function;
}

export interface ConfirmProps {
    cancelDelete: Function;
    confirmDelete: Function;
}

export interface ProgressBarProps {
    saveImgUrl: Function;
    setFile: Function;
    file: File;
}

export enum ResponseType {
    Ok,
    ApplicationError,
    Unauthorized,
}

export enum AuthResponseType {
    Ok,
    ApplicationError,
    InvalidPassword,
    ExistingUser,
    NonExistingUser,
}

export interface ChartDataSets {
    label: string;
    data: any[];
    backgroundColor: string[];
}

export interface ChartData {
    labels: string[];
    datasets: object[];
}

export interface ChartScales {
    yAxes: object[];
}

export interface ChartOptions {
    responsive: boolean;
    maintainAspectRatio: boolean;
    scales: ChartScales;
}

export interface FirebaseConfig {
    apiKey: string;
    authDomain: string;
    projectId: string;
    storageBucket: string;
    messagingSenderId: string;
    appId: string;
}
