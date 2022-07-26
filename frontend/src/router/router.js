import React from 'react';
import {Route, Routes} from "react-router-dom";
import routes from "./routes";
import Home from "../views/Home";
import Weather from "../views/Weather";

const Router = () => {
    return(
        <Routes>
            <Route
                path={routes.home}
                exact
                elements={<Home />}
            />
            <Route index element={<Home />} />
            <Route
                path={routes.weather}
                elements={<Weather />}
            />
        </Routes>
    )
};

export default Router;