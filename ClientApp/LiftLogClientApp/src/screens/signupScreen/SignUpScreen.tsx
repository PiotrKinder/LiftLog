import classes from "./SignUpScreen.module.css";
import Button from "../../controls/button/Button";
import Checkbox from "../../controls/checkbox/Checkbox";
import Input from "../../controls/input/Input";
import icons from "../../helpers/iconManager/enums/IconTypeEnum";
import Header from "../../controls/header/Header";
import { useDispatch } from "react-redux";
import { screenActions } from "../../slices/screenSlice/screenSlice";
import ScreenEnum from "../../enums/ScreenEnum";

function SignUpScreen() {
  const dispatch = useDispatch();

  function buttonBackHandler() {
    dispatch(screenActions.changeScreen(ScreenEnum.welcome));
  }

  return (
    <div className={classes.container}>
      <Header text="Sign up" />
      <Input placeholder="Login" icon={icons.User} />
      <Input
        placeholder="Email"
        type="email"
        icon={icons.Mail}
        isValid={false}
        validationMessage="Validation info!"
      />
      <Input placeholder="Password" type="password" icon={icons.Key} />
      <Input
        placeholder="Confirm password"
        type="password"
        icon={icons.Confirm}
      />
      <Checkbox text="Remember me" isChecked={false} />
      <Button text="Next" onCLick={() => {}} />
      <Button text="Back" onCLick={buttonBackHandler} />
    </div>
  );
}

export default SignUpScreen;
