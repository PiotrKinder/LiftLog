import "./Style.css";
import LogInScreen from "./screens/loginScreen/LogInScreen";
import SignUpScreen from "./screens/signupScreen/SignUpScreen";
import WelcomeScreen from "./screens/welcomeScreen/WelcomeScreen";
import ScreenEnum from "./enums/ScreenEnum";
import { useSelector } from "react-redux";
import ScreenState from "./slices/screenSlice/IScreenState";

function App() {
  const currentScreen = useSelector((state: ScreenState) => state.screen);
  return (
    <>
      {(() => {
        switch (currentScreen) {
          case ScreenEnum.welcome:
            return <WelcomeScreen />;
          case ScreenEnum.signup:
            return <SignUpScreen />;
          case ScreenEnum.login:
            return <LogInScreen />;
          default:
            return null;
        }
      })()}
    </>
  );
}

export default App;
