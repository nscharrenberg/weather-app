import {createSlice} from "@reduxjs/toolkit";

export const weatherSlice = createSlice({
    name: 'weather',
    initialState: {
        selectedStation: null,
        loading: false,
        measurements: []
    },
    reducers: {
        setSelectedStation: (state, action) => {
            state.selectedStation = action.payload;
        },
        setLoading: (state, action) => {
            state.loading = action.payload;
        },
        setMeasurements: (state, action) => {
            state.measurements = action.payload;
        }
    }
});

export const { setLoading, setSelectedStation, setMeasurements } = weatherSlice.actions;

export default weatherSlice.reducer;