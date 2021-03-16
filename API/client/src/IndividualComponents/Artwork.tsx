import React from "react";

interface artworkProps {
    artwork: artwork;
}
interface artwork {
    id: number;
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

const Artwork: React.FC<artworkProps> = ({ artwork }: artworkProps) => {
    const defaultImageUrl =
        "https://rlv.zcache.com/svc/view?realview=113070396694079804&design=0e2557d4-ca0f-4d5d-ab28-5a3543e6d157&rlvnet=1&style=standard_apron&max_dim=180&hide=bleed%2Csafe%2Cvisible%2CvisibleMask";
    const imageUrl = !!artwork.imgUrl ? artwork.imgUrl : defaultImageUrl;
    return (
        <div className="container" style={{ border: "1px solid #505050", borderRadius: 5, padding: 20, marginTop: 10 }}>
            <div className="row" style={{ justifyContent: "center", alignItems: "center" }}>
                <img style={{ width: 150, height: 150, borderRadius: "50%", padding: 10 }} src={imageUrl} alt="" />
                <div className="col-4">
                    <p>
                        Name: <b>{artwork.pieceName}</b>
                    </p>
                    <p>
                        Customer:<b>{artwork.customerName}</b>{" "}
                    </p>
                    <p>
                        Contact: <b>{artwork.customerContact}</b>
                    </p>
                    <p>
                        Shape: <b>{artwork.shape}</b>
                    </p>
                </div>
                <div className="col-4 col-sm-hidden">
                    <p>
                        Sale Price: <b>${artwork.salePrice}</b>
                    </p>
                    <p>
                        Margin: <b>${artwork.margin}</b>
                    </p>
                    <button className="btn btn-purple">More</button>
                    <button className="btn btn-purple">Edit</button>
                </div>
            </div>
        </div>
    );
};

export default Artwork;
