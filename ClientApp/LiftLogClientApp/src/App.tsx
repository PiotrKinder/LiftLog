import "./Style.css";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import LogInScreen from "./screens/loginScreen/LogInScreen";
import SignUpScreen from "./screens/signupScreen/SignUpScreen";
import WelcomeScreen from "./screens/welcomeScreen/WelcomeScreen";
import ScreenEnum from "./enums/ScreenEnum";
import { useSelector } from "react-redux";
import ScreenState from "./slices/screenSlice/IScreenState";
import { Children } from "react";
import ErrorScreen from "./screens/errorScreen/ErrorScreen";
const router = createBrowserRouter([
  {
    path: "/",
    element: <WelcomeScreen />,
    errorElement: <ErrorScreen />,
  },
  {
    path: "signup",
    element: <SignUpScreen />,
  },
  {
    path: "login",
    element: <LogInScreen />,
  },
]);
function App() {
  const currentScreen = useSelector((state: ScreenState) => state.screen);
  return <RouterProvider router={router} />;
}

export default App;
