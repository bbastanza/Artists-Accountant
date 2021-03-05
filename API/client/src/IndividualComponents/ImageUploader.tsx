import React, { useState } from "react";
import S3 from "react-aws-s3";

interface IAwsConfig {
    bucketName: string;
    dirName?: string;
    region: string;
    accessKeyId: string;
    secretAccessKey: string;
}

const config: IAwsConfig = {
    bucketName: process.env.REACT_APP_AWS_BUCKET,
    accessKeyId: process.env.REACT_APP_AWS_ACCESS_KEY,
    secretAccessKey: process.env.REACT_APP_AWS_SECRET_KEY,
    dirName: "Images/",
    region: "us-east-1",
};

interface ImageUploaderProps {
    returnImage: Function;
}

const ImageUploader: React.FC<ImageUploaderProps> = ({ returnImage }) => {
    const [event, setEvent] = useState<any>(null);

    console.log(config);
    const uploadImage = async () => {
        const file = event.target.files[0];
        if (file.size > 2000000) {
            console.log("too big");
            return "nope";
        }
        const awsClient = new S3(config);
        const response = await awsClient.uploadFile(file);
        console.log(response);
        returnImage(file);
        return "hi";
    };

    return (
        <>
            <input
                className=""
                type="file"
                multiple={false}
                accept=".jpeg, .png"
                onChange={ev => {
                    if (!!ev) setEvent(ev);
                }}
            />
            <button onClick={uploadImage}>Upload</button>
        </>
    );
};
export default ImageUploader;
