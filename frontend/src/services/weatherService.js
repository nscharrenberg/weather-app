import getApiService from "./apiService";

const getWeatherService = () => {
    const apiService = getApiService();
    const baseUrl = apiService.baseUrl;

    const getData = () => {
        const options = {
            method: 'GET',
            headers: {
                'Content-type': 'application/json'
            }
        };

        return apiService.request(baseUrl, options).then((response) => {
            return response.json();
        });
    }

    const getAvailableCities = (data) => {
        if (data === undefined || data == null) {
            return [];
        }

        if (data.actual == null) {
            return [];
        }

        const meassurements = data.actual.stationmeasurements;

        if (meassurements === undefined || meassurements === null) {
            return [];
        }

        return meassurements.map((item) => {
            return {
                label: item.regio,
                id: item.$id
            }
        });
    }

    return {
        getData,
        getAvailableCities
    }
};

export default getWeatherService;