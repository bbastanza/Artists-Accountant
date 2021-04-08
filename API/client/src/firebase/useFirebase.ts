import { useState, useEffect } from "react";
import { projectStorage } from "./config";

const useFirebase = file => {
    const [progress, setProgress] = useState<number>(0);
    const [error, setError] = useState<string>(null);
    const [url, setUrl] = useState<string>(null);

    useEffect(() => {
        const storageRef = projectStorage.ref(file.name);

        storageRef.put(file).on(
            "state_changed",
            snap => {
                let percentage = (snap.bytesTransferred / snap.totalBytes) * 100;
                setProgress(percentage);
            },
            err => {
                setError(err.message);
            },
            async () => {
                const url = await storageRef.getDownloadURL();
                setUrl(url);
            }
        );
    }, [file]);

    return { progress, url, error };
};

export { useFirebase };
