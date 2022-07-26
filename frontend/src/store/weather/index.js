import {createSlice} from "@reduxjs/toolkit";

export const weatherSlice = createSlice({
    name: 'weather',
    initialState: {
        city: null,
        weather: null,
        data: null,
        loading: false,
        availableCities: []
    },
    reducers: {
        setCity: (state, action) => {
            state.city = action.payload;
        },
        setData: (state, action) => {
            state.data = action.payload;
        },
        setWeather: (state, action) => {
            state.weather = action.payload;
        },
        setLoading: (state, action) => {
            state.loading = action.payload;
        },
        setAvailableCities: (state, action) => {
            state.availableCities = action.payload;
        }
    }
});

export const { setCity, setData, setLoading, setAvailableCities, setWeather } = weatherSlice.actions;

export default weatherSlice.reducer;