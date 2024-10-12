import "./Style.css";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import LogInPage from "./pages/loginPage/LogInPage";
import SignUpPage from "./pages/signupPage/SignUpPage";
import WelcomePage from "./pages/welcomePage/WelcomePage";
import ErrorPage from "./pages/errorPage/ErrorScreen";
const router = createBrowserRouter([
  {
    path: "/",
    element: <WelcomePage />,
    errorElement: <ErrorPage />,
  },
  {
    path: "signup",
    element: <SignUpPage />,
  },
  {
    path: "login",
    element: <LogInPage />,
  },
]);
function App() {
  return <RouterProvider router={router} />;
}

export default App;
