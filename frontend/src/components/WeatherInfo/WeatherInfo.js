import React, {Fragment} from 'react';
import {Card, CardContent, Grid, Typography} from "@mui/material";
import {faTemperatureHigh, faTemperatureLow, faThermometerHalf, faSun, faCloudRain, faCompass} from "@fortawesome/free-solid-svg-icons";
import {useSelector} from "react-redux";
import WeatherCard from "./WeatherCard";

const WeatherInfo = () => {

    const selectedStation = useSelector((state) => state.weather.selectedStation);

    if (selectedStation == null) {
        return (
            <Fragment>

            </Fragment>
        );
    }


  return (
      <Fragment>
          <Grid container spacing={2}>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Actuele Temperatuur" value={selectedStation.temperature ? selectedStation.temperature : '?'} icon={faThermometerHalf} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Gevoelstemperatuur" value={selectedStation.feeltemperature ? selectedStation.feeltemperature : '?'} icon={faTemperatureHigh} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Ground Temperatuur" value={selectedStation.groundtemperature ? selectedStation.groundtemperature : '?'} icon={faTemperatureLow} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Zonnekracht" value={selectedStation.winddirectiondegrees ? selectedStation.winddirectiondegrees : '?'} icon={faSun} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Regen laatste uur" value={selectedStation.humidity ? `${selectedStation.humidity}mm` : '?'} icon={faCloudRain} />
              </Grid>
              <Grid item md={4} xs={6}>
                  <WeatherCard title="Windrichting" value={selectedStation.winddirection ? selectedStation.winddirection : '?'} icon={faCompass} />
              </Grid>
          </Grid>
      </Fragment>
  )
};

export default WeatherInfo;