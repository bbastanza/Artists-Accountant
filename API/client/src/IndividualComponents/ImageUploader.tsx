import React, { useState } from "react";

interface IAwsConfig {
    bucketName: string;
    dirName?: string;
    region: string;
    accessKeyId: string;
    secretAccessKey: string;
}

interface ImageUploaderProps {
    returnImage: Function;
}

const ImageUploader: React.FC<ImageUploaderProps> = ({ returnImage }) => {
    const [event, setEvent] = useState<any>(null);

    const uploadImage = async () => {
        const file = event.target.files[0];
        if (file.size > 2000000) {
            console.log("too big");
            return "nope";
        }
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
