const getApiService = () => {
    const baseUrl = "https://localhost:7192/api/";

    const request = async (url, options) => {
        return await fetch(url, options);
    };

    return {
        baseUrl,
        request
    };
};

export default getApiService;