import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { AuthRequest, AuthResponse } from '../api/Contracts';
import ApiClientAcces from '../api/ApiClientAcces';

export const fetchData = createAsyncThunk('data/fetchLoginData', async (authData: AuthRequest) => {
     const api = ApiClientAcces.getInstance();
     const data: AuthResponse = await api.login(authData);
    return data;
  });

  export interface DataState {
    data: AuthResponse | null;
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
            if(action.payload){
              state.loading = false;
              state.data = action.payload;
            }
          })
          .addCase(fetchData.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error.message || 'Failed to fetch data';
        });
    },
  });

  export default loginSlice.reducer;