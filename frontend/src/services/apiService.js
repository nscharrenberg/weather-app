const getApiService = () => {
    const baseUrl = "https://data.buienradar.nl/2.0/feed/json";

    const request = async (url, options) => {
        const response = await fetch(url, options);

        return response;
    };

    return {
        baseUrl,
        request
    };
};

export default getApiService;