import React, {Fragment} from 'react';
import {Card, CardContent, Grid, Typography} from "@mui/material";
import {faTemperatureHigh, faTemperatureLow, faThermometerHalf, faSun, faCloudRain, faCompass} from "@fortawesome/free-solid-svg-icons";
import {useSelector} from "react-redux";
import WeatherCard from "./WeatherCard";
import DateTimeRangePicker from "./DateTimeRangePicker";

const WeatherInfo = () => {

    const selectedStation = useSelector((state) => state.weather.selectedStation);

    if (selectedStation == null || selectedStation.measurements.length === 0) {
        return (
            <Fragment>

            </Fragment>
        );
    }

    const measurements = selectedStation.measurements;

  return (
      <Fragment>
          <Grid container spacing={2}>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Actuele Temperatuur" value={measurements[measurements.length-1].temperature ? measurements[measurements.length-1].temperature : '?'} icon={faThermometerHalf} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Gevoelstemperatuur" value={measurements[measurements.length-1].feelTemperature ? measurements[measurements.length-1].feelTemperature : '?'} icon={faTemperatureHigh} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Ground Temperatuur" value={measurements[measurements.length-1].groundTemperature ? measurements[measurements.length-1].groundTemperature : '?'} icon={faTemperatureLow} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Zonnekracht" value={measurements[measurements.length-1].sunPower ? measurements[measurements.length-1].sunPower : '?'} icon={faSun} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Regen laatste uur" value={measurements[measurements.length-1].rainFallLastDay ? `${measurements[measurements.length-1].rainFallLastDay}mm` : '0'} icon={faCloudRain} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Windrichting" value={measurements[measurements.length-1].windDirection ? measurements[measurements.length-1].windDirection : '?'} icon={faCompass} />
              </Grid>
          </Grid>

          <DateTimeRangePicker/>
      </Fragment>
  )
};

export default WeatherInfo;