import "./css/ImageUploader.css";
import React, { useState } from "react";
import ProgressBar from "./ProgressBar";
import { ImageUploaderProps } from "./../helpers/interfaces";

const ImageUploader: React.FC<ImageUploaderProps> = ({ saveImgUrl }: ImageUploaderProps) => {
    const [file, setFile] = useState<File>(null);
    const [error, setError] = useState<string>(null);

    const handleChange = (e): void => {
        const selectedFile = e.target.files[0];
        const allowedImageTypes = ["image/png", "image/jpg", "image/jpeg"];

        if (!allowedImageTypes.includes(selectedFile?.type)) return setError("File type not allowed.");

        if (!!selectedFile) return setFile(selectedFile);

        setFile(null);
    };

    return (
        <>
            {!!file ? (
                <div>
                    <div>{file.name}</div>
                    <ProgressBar file={file} setFile={setFile} saveImgUrl={saveImgUrl} />
                </div>
            ) : (
                <label className="input-label">
                    <input type="file" multiple={false} accept=".jpeg, .png, .jpg" onChange={handleChange} />
                    <span className="upload-span btn">Upload Image...</span>
                </label>
            )}
            {error && <div className="form-error">{error}</div>}
        </>
    );
};
export default ImageUploader;
