import React from 'react';
import {Route, Routes} from "react-router-dom";
import routes from "./routes";
import Home from "../views/Home";

const Router = () => {
    return(
        <Routes>
            <Route
                path={routes.home}
                exact
                elements={<Home />}
            />
            <Route index element={<Home />} />
        </Routes>
    )
};

export default Router;