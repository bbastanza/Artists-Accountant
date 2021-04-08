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
        <div className="col-12">
            {file && <ProgressBar file={file} setFile={setFile} saveImgUrl={saveImgUrl} />}
            <div className="custom-file" style={{ margin: "10px auto", width: "100%", padding: 20 }}>
                <input
                    className="custom-file-input"
                    id="customInput"
                    type="file"
                    style={{ visibility: "hidden" }}
                    multiple={false}
                    accept=".jpeg, .png"
                    onChange={handleChange}
                />
                <label className="custom-file-label btn-purple" htmlFor="customInput">
                    Choose Profile Image...
                </label>
            </div>

            {error && <div className="form-error">{error}</div>}
        </div>
    );
};
export default ImageUploader;
