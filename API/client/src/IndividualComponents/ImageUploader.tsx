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
        <div className="col-8">
            {file && <ProgressBar file={file} setFile={setFile} saveImgUrl={saveImgUrl} />}
            <div>
                <input
                    // className="custom-file-input"
                    id="customInput"
                    type="file"
                    // style={{ opacity: 0 }}
                    multiple={false}
                    accept=".jpeg, .png, .jpg"
                    onChange={handleChange}
                />
                {/* <label className="custom-file-label btn-purple" style={{ textAlign: "left" }} htmlFor="customInput">
                    Upload Image...
                </label> */}
            </div>
            {error && <div className="form-error">{error}</div>}
        </div>
    );
};
export default ImageUploader;
