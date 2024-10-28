import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { GetExerciseListItemQuery, GetExerciseQuery } from '../api/Contracts';
import ApiClientAcces from '../api/ApiClientAcces';

export const fetchUserExercisesData = createAsyncThunk('data/fetchUserExerciseData', async (token: string | undefined | null) => {
    const api = ApiClientAcces.getInstance();
    const data: GetExerciseListItemQuery[] = await api.getAllExercises();
   return data;
 });

export const fetchExerciseData = createAsyncThunk('data/fetchUserExerciseData', async (exerciseId : string) => {
    const api = ApiClientAcces.getInstance();
    const data: GetExerciseQuery = await api.getExercise(exerciseId);
   return data;
 });

 export interface ExerciseState {
    exercisesList: GetExerciseListItemQuery[] | null,
    loading: boolean,
    error: string | null,
 }

 const initialState: ExerciseState = {
    exercisesList: null,
    loading: false,
    error: null  
 }

 const exerciseSlice = createSlice({
    name: 'exercise',
    initialState,
    reducers:{},
    extraReducers: (builder) => {
        builder
        .addCase(fetchUserExercisesData.pending, (state) => {
            state.loading = true;
            state.error = null;
          })
          .addCase(fetchUserExercisesData.fulfilled, (state, action) => {
            if(action.payload){
              state.loading = false;
              state.exercisesList = action.payload;
            }
          })
          .addCase(fetchUserExercisesData.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error.message || 'Failed to fetch exercise list';
        });
    },
  });

  export default exerciseSlice.reducer;