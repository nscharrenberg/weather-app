import { configureStore } from '@reduxjs/toolkit';
import {weatherReducer} from "./index";


export default configureStore({
    reducer: {
        weather: weatherReducer
    },
})