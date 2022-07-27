import React, {Fragment} from 'react';
import {Card, CardContent, Grid, Typography} from "@mui/material";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";

const WeatherCard = ({title, value, icon}) => {
    return (
        <Fragment>
            <Card elevation={0}>
                <CardContent>
                    <Grid container spacing={2}>
                        <Grid item xs={4}>
                            <Typography fontSize={80} paddingRight={3}>
                                <FontAwesomeIcon icon={icon} />
                            </Typography>
                        </Grid>
                        <Grid item xs={8}>
                            <Typography fontSize={50} fontWeight="bold" component="div" color="primary">
                                { value }
                            </Typography>
                            <Typography variant="body1" fontWeight="bold" component="div" mt={0}>
                                { title }
                            </Typography>
                        </Grid>
                    </Grid>
                </CardContent>
            </Card>
        </Fragment>
    );
};

export default WeatherCard;