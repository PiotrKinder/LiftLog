import Input from "../../controls/input/Input";
import classes from "./LogInScreen.module.css";
import icons from "../../helpers/iconManager/enums/IconTypeEnum";
import Checkbox from "../../controls/checkbox/Checkbox";
import Button from "../../controls/button/Button";
import Header from "../../controls/header/Header";
import { useDispatch } from "react-redux";
import ScreenEnum from "../../enums/ScreenEnum";
import { screenActions } from "../../slices/screenSlice/screenSlice";

function LogInScreen() {
  const dispatch = useDispatch();

  function buttonBackHandler() {
    dispatch(screenActions.changeScreen(ScreenEnum.welcome));
  }
  return (
    <div className={classes.container}>
      <Header text="Log in" />
      <Input placeholder="Email" type="email" icon={icons.Mail} />
      <Input placeholder="Password" type="password" icon={icons.Key} />
      <Checkbox text="Remember me" isChecked={false} />
      <Button text="Next" onCLick={() => {}} />
      <Button text="Back" onCLick={buttonBackHandler} />
    </div>
  );
}

export default LogInScreen;
