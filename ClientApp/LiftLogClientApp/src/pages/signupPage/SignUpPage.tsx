import classes from "./SignUpPage.module.css";
import Button from "../../components/button/Button";
import Checkbox from "../../components/checkbox/Checkbox";
import Input from "../../components/input/Input";
import icons from "../../helpers/iconManager/enums/IconTypeEnum";
import Header from "../../components/header/Header";
import { useNavigate } from "react-router-dom";

function SignUpPage() {
  const navigate = useNavigate();

  function buttonBackHandler() {
    navigate("/");
  }

  return (
    <div className={classes.container}>
      <form>
        <Header text="Sign up" />
        <Input onInputChange={() => {}} placeholder="Login" icon={icons.User} />
        <Input
          onInputChange={() => {}}
          placeholder="Email"
          type="email"
          icon={icons.Mail}
          isValid={false}
          validationMessage="Validation info!"
        />
        <Input
          onInputChange={() => {}}
          placeholder="Password"
          type="password"
          icon={icons.Key}
        />
        <Input
          onInputChange={() => {}}
          placeholder="Confirm password"
          type="password"
          icon={icons.Confirm}
        />
        <Checkbox text="Remember me" isChecked={false} />
        <Button text="Next" onCLick={() => {}} />
        <Button text="Back" onCLick={buttonBackHandler} />
      </form>
    </div>
  );
}

export default SignUpPage;
