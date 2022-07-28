import {createSlice} from "@reduxjs/toolkit";

export const weatherSlice = createSlice({
    name: 'weather',
    initialState: {
        selectedStation: null,
        loading: false,
        stations: [],
        filter: {
            startDate: null,
            endDate: null,
        },
        overview: []
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
        },
        setStartDate: (state, action) => {
            state.filter.startDate = action.payload;
        },
        setEndDate: (state, action) => {
            state.filter.endDate = action.payload;
        },
        setOverview: (state, action) => {
            state.overview = action.payload;
        }
    }
});

export const { setLoading, setSelectedStation, setStations, setStartDate, setEndDate, setOverview } = weatherSlice.actions;

export default weatherSlice.reducer;