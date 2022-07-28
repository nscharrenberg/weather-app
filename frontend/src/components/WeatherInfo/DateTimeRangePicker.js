import {Fragment, useEffect, useState} from "react";
import {DateTimePicker} from "@mui/x-date-pickers";
import {Button, Grid, TextField} from "@mui/material";
import {useDispatch, useSelector} from "react-redux";
import {setEndDate, setLoading, setOverview, setSelectedStation, setStartDate, setStations} from "../../store/weather";
import {getWeatherService} from "../../services";

const DateTimeRangePicker = () => {
    const [start, setLocalStart] = useState(new Date());
    const [end, setLocalEnd] = useState(null);

    const selectedStation = useSelector((state) => state.weather.selectedStation);
    const startDate = useSelector((state) => state.weather.filter.startDate);
    const endDate = useSelector((state) => state.weather.filter.endDate);
    const dispatch = useDispatch();

    useEffect(() => {
        setLocalStart(startDate);
        setLocalEnd(endDate);
    }, [])

    const filterData = () => {
        dispatch(setLoading(true));
        getWeatherService().getStationByStationId(selectedStation.stationId, startDate, endDate).then((res) => {
            dispatch(setOverview(res.measurements));
            dispatch(setLoading(false));
        });
    }

    return (
        <Fragment>
            <Grid container spacing={2}>
                <Grid item md={5}>
                    <DateTimePicker
                        renderInput={(props) => <TextField fullWidth {...props} />}
                        label="Start Date & Time"
                        value={start}
                        ampmInClock={false}
                        ampm={false}
                        onChange={(newValue) => {
                            setLocalStart(newValue);
                            dispatch(setStartDate(JSON.stringify(newValue).replaceAll("\"", '')));
                        }}
                    />
                </Grid>

                <Grid item md={5}>
                    <DateTimePicker
                        renderInput={(props) => <TextField fullWidth {...props} />}
                        label="End Date Time"
                        value={end}
                        ampmInClock={false}
                        ampm={false}
                        onChange={(newValue) => {
                            setLocalEnd(newValue);
                            dispatch(setEndDate(JSON.stringify(newValue).replaceAll("\"", '')));
                        }}
                        minDateTime={start}
                    />
                </Grid>
                <Grid item md={2}>
                    <Button onClick={() => filterData()} fullWidth variant="contained">Filter</Button>
                </Grid>
            </Grid>
        </Fragment>
    );
}

export default DateTimeRangePicker;