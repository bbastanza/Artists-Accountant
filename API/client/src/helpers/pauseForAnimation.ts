export const pauseForAnimation = async (): Promise<void> => {
    await new Promise((resolve: Function) => setTimeout(resolve, 1500));
};
