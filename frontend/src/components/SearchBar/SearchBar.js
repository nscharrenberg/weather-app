import React, {Fragment, useEffect} from 'react';
import {
    Autocomplete,
    createFilterOptions,
    TextField
} from "@mui/material";
import {useDispatch, useSelector} from "react-redux";
import {getWeatherService} from "../../services";
import {setLoading, setStations, setSelectedStation} from "../../store/weather";

const SearchBar = () => {
    const dispatch = useDispatch();
    const stations = useSelector((state) => state.weather.stations);

    // Autocomplete search based on regio and station name (excluding "Meetstation" from searching)
    const filterOptions = createFilterOptions({
        matchFrom: 'any',
        stringify: (option) => ` ${option.region}-${option.name.replace('Meetstation ', '')}`
    });

    // Reload data on component load or raw weatherData change
    useEffect(() => {
        dispatch(setLoading(true));
        getWeatherService().getStations().then((res) => {
            dispatch(setStations(res));
            dispatch(setLoading(false));
        });
    }, [dispatch])

    return (
        <Fragment>
            <Autocomplete
                options={stations}
                filterOptions={filterOptions}
                renderOption={(props, option) => {
                    return (
                        <li {...props} key={`station-${option.stationId}`}>{`${option.name} (${option.region})`}</li>
                    )
                }}
                getOptionLabel={(option) => `${option.name} (${option.region})`}
                renderInput={(params) => <TextField {...params} label="Weather Station or City" />}
                onChange={(event, newInputValue) => {
                    dispatch(setSelectedStation(newInputValue));
                }}
            />
        </Fragment>
    )
};

export default SearchBar;