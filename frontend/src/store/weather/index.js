import {createSlice} from "@reduxjs/toolkit";

export const weatherSlice = createSlice({
    name: 'weather',
    initialState: {
        selectedStation: null,
        loading: false,
        stations: []
    },
    reducers: {
        setSelectedStation: (state, action) => {
            state.selectedStation = action.payload;
        },
        setLoading: (state, action) => {
            state.loading = action.payload;
        },
        setStations: (state, action) => {
            state.stations = action.payload;
        }
    }
});

export const { setLoading, setSelectedStation, setStations } = weatherSlice.actions;

export default weatherSlice.reducer;