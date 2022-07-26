import React from 'react';
import { Box, Grommet } from 'grommet';
import {BrowserRouter} from "react-router-dom";
import Router from "./router/router";

const theme = {
  global: {
    colors: {
      brand: '#4AD6ED',
      secondary: '#ffed00'
    },
    font: {
      family: 'Roboto',
      size: '18px',
      height: '20px',
    },
  },
};

function App(props) {
  return (
      <BrowserRouter>
        <Grommet theme={theme}>
          <Router/>
        </Grommet>
      </BrowserRouter>
  );
}

export default App;
