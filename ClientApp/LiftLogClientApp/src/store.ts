import { configureStore } from "@reduxjs/toolkit";
import screenSlice from "./slices/screenSlice/screenSlice";

const store = configureStore({
    reducer: screenSlice.reducer
})

export default store;