import { createSlice } from "@reduxjs/toolkit";
import ScreenEnum from "../../enums/ScreenEnum";

const initialState = {screen: ScreenEnum.welcome}


const screenSlice = createSlice({
    name: "currentScreen",
    initialState: initialState,
    reducers:{
        changeScreen(state, action){
            state.screen = action.payload
        }
    }
})

export const screenActions = screenSlice.actions;
export  default screenSlice;