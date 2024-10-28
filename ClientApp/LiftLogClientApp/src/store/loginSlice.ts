import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { AuthRequest, AuthResponse } from '../api/Contracts';
import ApiClientAcces from '../api/ApiClientAcces';

export const fetchLoginData = createAsyncThunk('data/fetchLoginData', async (authData: AuthRequest) => {
     const api = ApiClientAcces.getInstance();
     const data: AuthResponse = await api.login(authData);
    return data;
  });

  export interface LoginState {
    token: string | undefined | null;
    loading: boolean;
    error: string | null;
  }
  
  const initialState: LoginState = {
    token: null,
    loading: false,
    error: null,
  };

  const loginSlice = createSlice({
    name: 'login',
    initialState,
    reducers:{},
    extraReducers: (builder) => {
        builder
        .addCase(fetchLoginData.pending, (state) => {
            state.loading = true;
            state.error = null;
          })
          .addCase(fetchLoginData.fulfilled, (state, action) => {
            if(action.payload){
              state.loading = false;
              state.token = action.payload.token;
            }
          })
          .addCase(fetchLoginData.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error.message || 'Failed to login';
        });
    },
  });

  export default loginSlice.reducer;