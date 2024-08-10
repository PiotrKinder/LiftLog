import "./Style.css";
import Button from "./controls/button/Button";
import Checkbox from "./controls/checkbox/Checkbox";
import Input from "./controls/input/Input";
import Tile from "./controls/tile/Tile";
import IconTypeEnum from "./helpers/iconManager/enums/IconTypeEnum";
import LogInScreen from "./screens/loginScreen/LogInScreen";
import SignUpScreen from "./screens/signupScreen/SignUpScreen";
import WelcomeScreen from "./screens/welcomeScreen/WelcomeScreen";

function App() {
  return (
    <>
      {/* <WelcomeScreen /> */}
      {/* <LogInScreen /> */}
      <SignUpScreen />
    </>
  );
}

export default App;
