import getApiService from "./apiService";

const getWeatherService = () => {
    const apiService = getApiService();
    const baseUrl = apiService.baseUrl;

    const getStations = () => {
        const options = {
            method: 'GET',
            headers: {
                'Content-type': 'application/json'
            }
        };

        return apiService.request(`${baseUrl}Station`, options).then((response) => {
            return response.json().then(res => {
                if (res == null) {
                    return [];
                }

                return res;
            });
        });
    }

    const getStationByStationId =(stationId, startDate = null, endDate = null) => {
        const options = {
            method: 'GET',
            headers: {
                'Content-type': 'application/json'
            }
        };

        let url = `${baseUrl}Station/${stationId}`;

        if (startDate != null) {
            url += `?Start=${startDate}`;

            if (endDate != null) {
                url += `&End=${endDate}`;
            }
        }

        return apiService.request(url, options).then((response) => {
            return response.json().then((res) => {
                return res;
            })
        })
    }

    return {
        getStations,
        getStationByStationId,
    }
};

export default getWeatherService;