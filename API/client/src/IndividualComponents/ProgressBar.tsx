import "./css/ProgressBar.css";
import React, { useEffect } from "react";
import { useFirebase } from "./../firebase/useFirebase";
import { ProgressBarProps } from "./../helpers/interfaces";

// TODO error handling
const ProgressBar: React.FC<ProgressBarProps> = ({ setFile, file, saveImgUrl }: ProgressBarProps) => {
    const { progress, url, error } = useFirebase(file);

    useEffect(() => {
        if (!!url) {
            setFile(null);
            saveImgUrl(url);
        }
    }, [url, setFile, saveImgUrl]);

    return (
        <>
            {/* <h3>Loading...</h3> */}
            <div className="progress-bar" style={{ width: `${progress}%` }}></div>
        </>
    );
};

export default ProgressBar;
