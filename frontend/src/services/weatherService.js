import getApiService from "./apiService";

const getWeatherService = () => {
    const apiService = getApiService();
    const baseUrl = apiService.baseUrl;

    const getMeasurements = () => {
        const options = {
            method: 'GET',
            headers: {
                'Content-type': 'application/json'
            }
        };

        return apiService.request(baseUrl, options).then((response) => {
            return response.json().then(res => {
                if (res == null || res.actual == null) {
                    return [];
                }

                const meassurements = res.actual.stationmeasurements;

                if (meassurements == null) {
                    return [];
                }

                return meassurements;
            });
        });
    }

    return {
        getMeasurements
    }
};

export default getWeatherService;