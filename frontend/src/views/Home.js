import React, {Fragment, useEffect} from 'react';
import {useDispatch, useSelector} from "react-redux";
import {AppBar, Card, CardMedia, Container, Grid, Toolbar} from "@mui/material";
import SearchBar from "../components/SearchBar/SearchBar";
import {setData, setLoading} from "../store/weather";
import {getWeatherService} from "../services";

const Home = () => {
    const weatherData = useSelector((state) => state.weather.data);
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(setLoading(true));
        getWeatherService().getData().then((response) => {
            dispatch(setData(response));
            dispatch(setLoading(false));
        });
    }, []);

  return (
      <Fragment>
          <AppBar position='static'>
              <Toolbar
                variant='dense'
              />
          </AppBar>
          <Container sx={{ paddingTop: 5 }}>
              <Grid container spacing={2}>
                  <Grid item xs={4}>
                      <Card elevation={0}>
                          <CardMedia
                            component='img'
                            image='assets/images/logo.png'
                          />
                      </Card>
                  </Grid>
                  <Grid item xs={8}/>
                  <Grid item xs={12}>
                      <SearchBar/>
                  </Grid>
              </Grid>
          </Container>
      </Fragment>
  );
};

export default Home;