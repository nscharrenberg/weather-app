import React from 'react';
import {BrowserRouter} from "react-router-dom";
import Router from "./router/router";
import {createTheme, ThemeProvider} from "@mui/material";

const theme = createTheme({
    palette: {
        primary: {
            main: '#4ad7ed',
        },
        secondary: {
            main: '#ffed00',
        },
    },
})

function App() {
  return (
      <BrowserRouter>
        <ThemeProvider theme={theme}>
          <Router/>
        </ThemeProvider>
      </BrowserRouter>
  );
}

export default App;
