import { configureStore } from "@reduxjs/toolkit";
import authSlice from "./slice/authSlice";
import roleSlice from "./slice/roleSlice";

export const store = configureStore({
  reducer: {
    isAuth: authSlice,
    role: roleSlice,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
