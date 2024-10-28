import { configureStore } from '@reduxjs/toolkit';
import loginSlice from './loginSlice';
import exerciseSlice from './exerciseSlice'

export const store = configureStore({
    reducer: {
      login: loginSlice,
      exercise: exerciseSlice
    },
  });
  
  export type RootState = ReturnType<typeof store.getState>;
  export type AppDispatch = typeof store.dispatch;