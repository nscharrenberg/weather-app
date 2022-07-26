import React from 'react';
import {useSelector} from "react-redux";

const Home = () => {
  const city = useSelector((state) => state.weather.city);

  return (
      <div>City: { city }</div>
  );
};

export default Home;