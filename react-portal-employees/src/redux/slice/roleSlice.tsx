import { createSlice } from "@reduxjs/toolkit";
import type { RootState } from "../store";

interface roleState {
  value: string;
}

const initialState: roleState = {
  value: "",
};

export const roleSlice = createSlice({
  name: "role",
  initialState,
  reducers: {
    visitor: (state) => {
      state.value = "visitor";
    },
    user: (state) => {
      state.value = "user";
    },
    admin: (state) => {
      state.value = "Admin";
    },
  },
});

export const { visitor, user, admin } = roleSlice.actions;

export const selectRole = (state: RootState) => state;

export default roleSlice.reducer;
