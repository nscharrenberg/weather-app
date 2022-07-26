import React, {Fragment, useEffect} from 'react';
import {Autocomplete, TextField} from "@mui/material";
import {useDispatch, useSelector} from "react-redux";
import {getWeatherService} from "../../services";
import {setAvailableCities, setLoading} from "../../store/weather";

const SearchBar = () => {
    const dispatch = useDispatch();
    const availableCities = useSelector((state) => state.weather.availableCities);
    const weatherData = useSelector((state) => state.weather.data);

    useEffect(() => {
        dispatch(setLoading(true));
        const result = getWeatherService().getAvailableCities(weatherData);
        dispatch(setAvailableCities(result));
        dispatch(setLoading(false));
    }, [weatherData, dispatch])

    return (
        <Fragment>
            <Autocomplete
                options={availableCities}
                renderInput={(params) => <TextField {...params} label="Weather Station" />}/>
        </Fragment>
    )
};

export default SearchBar;