import React from 'react';
import { Box, Grommet } from 'grommet';

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
    <Grommet theme={theme}>
      <Box
        tag='header'
        direction='row'
        align='center'
        justify='between'
        background='brand'
        pad={{ left: 'medium', right: 'small', vertical: 'small'}}
        elevation='medium'
        style={{ zIndex: '1' }}
        {...props}
      />
    </Grommet>
  );
}

export default App;
