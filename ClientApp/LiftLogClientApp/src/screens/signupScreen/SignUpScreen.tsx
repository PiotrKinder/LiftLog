import classes from "./SignUpScreen.module.css";
import Button from "../../controls/button/Button";
import Checkbox from "../../controls/checkbox/Checkbox";
import Input from "../../controls/input/Input";
import icons from "../../helpers/iconManager/enums/IconTypeEnum";
import Header from "../../controls/header/Header";

function SignUpScreen() {
  return (
    <div className={classes.container}>
      <Header text="Sign up" />
      <Input placeholder="Login" icon={icons.User} />
      <Input placeholder="Email" icon={icons.Mail} />
      <Input placeholder="Password" icon={icons.Key} />
      <Input placeholder="Confirm password" icon={icons.Confirm} />
      <Checkbox text="Remember me" isChecked={false} />
      <Button text="Next" onCLick={() => {}} />
    </div>
  );
}

export default SignUpScreen;
