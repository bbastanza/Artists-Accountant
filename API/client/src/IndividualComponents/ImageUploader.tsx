import React, { useState } from "react";
import ProgressBar from "./ProgressBar";

interface ImageUploaderProps {
    saveImgUrl: Function;
}

const ImageUploader: React.FC<ImageUploaderProps> = ({ saveImgUrl }) => {
    const [file, setFile] = useState<File>(null);
    const [error, setError] = useState<string>(null);

    const allowedImageTypes = ["image/png", "image/jpg", "image/jpeg"];
    const handleChange = e => {
        const selectedFile = e.target.files[0];

        if (!allowedImageTypes.includes(selectedFile?.type)) return console.log("not allowed");

        if (!!selectedFile) {
            return setFile(selectedFile);
        }
        setFile(null);
        console.log();
    };

    return (
        <div className="col-8">
            {file && <ProgressBar file={file} setFile={setFile} saveImgUrl={saveImgUrl} />}
            <div className="custom-file" style={{ margin: "auto", width: "100%", padding: 20, position: "relative" }}>
                <input
                    className="custom-file-input"
                    id="customInput"
                    type="file"
                    style={{ opacity: 0 }}
                    multiple={false}
                    accept=".jpeg, .png, .jpg"
                    onChange={handleChange}
                />
                <label className="custom-file-label btn-purple" style={{ textAlign: "left" }} htmlFor="customInput">
                    Upload Image...
                </label>
            </div>

            {error && <div className="form-error">{error}</div>}
        </div>
    );
};
export default ImageUploader;
