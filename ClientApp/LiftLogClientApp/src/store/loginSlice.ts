import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchLoginData } from '../api/fetchData';

export const fetchData = createAsyncThunk('data/fetchLoginData', async ({ email, password }: { email: string; password: string }) => {
    const data = await fetchLoginData(email, password);
    return data;
  });

  export interface DataState {
    data: any;
    loading: boolean;
    error: string | null;
  }
  
  const initialState: DataState = {
    data: null,
    loading: false,
    error: null,
  };

  const loginSlice = createSlice({
    name: 'login',
    initialState,
    reducers:{},
    extraReducers: (builder) => {
        builder
        .addCase(fetchData.pending, (state) => {
            state.loading = true;
            state.error = null;
          })
          .addCase(fetchData.fulfilled, (state, action) => {
            state.loading = false;
            state.data = action.payload;
          })
          .addCase(fetchData.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error.message || 'Failed to fetch data';
        });
    },
  });

  export default loginSlice.reducer;