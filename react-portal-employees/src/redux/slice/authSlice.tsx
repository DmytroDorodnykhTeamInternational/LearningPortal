import { createSlice } from "@reduxjs/toolkit";
import type { RootState } from "../store";

interface authState {
  value: boolean;
}

const initialState: authState = {
  value: false,
};

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    isValid: (state) => {
      state.value = true;
    },
    isInvalid: (state) => {
      state.value = false;
    },
  },
});

export const { isValid, isInvalid } = authSlice.actions;

export const isAuth = (state: RootState) => state;

export default authSlice.reducer;
