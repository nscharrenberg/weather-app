import {createSlice} from "@reduxjs/toolkit";

export const weatherSlice = createSlice({
    name: 'weather',
    initialState: {
        city: 'Maastricht',
        data: null,
        loading: false
    },
    reducers: {
        setCity: (state, payload) => {
            state.city = payload;
        },
        setData: (state, payload) => {
            state.data = payload;
        },
        setLoading: (state, payload) => {
            state.loading = payload;
        }
    }
});

export const { setCity, setData, setLoading } = weatherSlice.actions;

export default weatherSlice.reducer;