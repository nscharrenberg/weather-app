import React, {Fragment} from 'react';
import {AppBar, Card, CardMedia, Container, Grid, Toolbar} from "@mui/material";
import SearchBar from "../components/SearchBar/SearchBar";
import WeatherInfo from "../components/WeatherInfo/WeatherInfo";

const Home = () => {
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
                  <Grid item xs={12}>
                        <WeatherInfo/>
                  </Grid>
              </Grid>
          </Container>
      </Fragment>
  );
};

export default Home;