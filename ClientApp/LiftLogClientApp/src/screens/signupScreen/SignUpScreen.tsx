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
      <Input
        placeholder="Email"
        type="email"
        icon={icons.Mail}
        isValid={true}
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
    </div>
  );
}

export default SignUpScreen;
