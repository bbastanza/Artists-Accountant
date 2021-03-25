export const formatMoney = (amount: number): string => {
    if (!!!amount) return "N/A";

    return (
        "$" +
        amount
            .toFixed(2)
            .toString()
            .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    );
};

export const formatSize = (inches: number): string => {
    if (!!!inches) return "N/A";

    if (inches < 12) return `${inches}"`;

    const inchesPerFoot = Math.floor(inches / 12);
    const inchesModFoot = Math.floor(inches % 12);
    return `${inchesPerFoot}' ${inchesModFoot === 0 ? "" : `${inchesModFoot}"`} ( ${inches}" )`;
};

export const formatTime = (minutes: number): string => {
    if (!!!minutes) return "N/A";

    if (minutes < 60) return `${minutes} m`;

    const minPerHour = Math.floor(minutes / 60);
    const minModHour = Math.floor(minutes % 60);
    return `${minPerHour}h ${minModHour === 0 ? "" : `${minModHour}m`}`;
};

export const formatForNull = (input: any): string => {
    if (!!!input) return "N/A";
    return input.toString();
};

export const checkDate = (date: Date): string => {
    return !!date ? date.toLocaleDateString() : "N/A";
};

export const checkBool = (bool: boolean): string => {
    return bool ? "Yes" : "No";
};
