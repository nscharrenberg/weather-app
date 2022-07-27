import React, {Fragment, useEffect, useState} from 'react';
import {
    Autocomplete,
    createFilterOptions,
    TextField
} from "@mui/material";
import {useDispatch, useSelector} from "react-redux";
import {getWeatherService} from "../../services";
import {setLoading, setMeasurements, setSelectedStation} from "../../store/weather";

const SearchBar = () => {
    const dispatch = useDispatch();
    const measurements = useSelector((state) => state.weather.measurements);

    // Autocomplete search based on regio and station name (excluding "Meetstation" from searching)
    const filterOptions = createFilterOptions({
        matchFrom: 'any',
        stringify: (option) => ` ${option.regio}-${option.stationname.replace('Meetstation ', '')}`
    });

    // Reload data on component load or raw weatherData change
    useEffect(() => {
        dispatch(setLoading(true));
        getWeatherService().getMeasurements().then((res) => {
            dispatch(setMeasurements(res));
            dispatch(setLoading(false));
        });
    }, [dispatch])

    return (
        <Fragment>
            <Autocomplete
                options={measurements}
                filterOptions={filterOptions}
                renderOption={(props, option) => {
                    return (
                        <li {...props} key={`station-${option.stationid}`}>{`${option.stationname} (${option.regio})`}</li>
                    )
                }}
                getOptionLabel={(option) => `${option.stationname} (${option.regio})`}
                renderInput={(params) => <TextField {...params} label="Weather Station or City" />}
                onChange={(event, newInputValue) => {
                    dispatch(setSelectedStation(newInputValue));
                }}
            />
        </Fragment>
    )
};

export default SearchBar;