import Input from "../../controls/input/Input";
import classes from "./LogInScreen.module.css";
import icons from "../../helpers/iconManager/enums/IconTypeEnum";
import Checkbox from "../../controls/checkbox/Checkbox";
import Button from "../../controls/button/Button";

function LogInScreen() {
  return (
    <div className={classes.container}>
      <Input placeholder="Email" icon={icons.Mail} />
      <Input placeholder="Password" icon={icons.Key} />
      <Checkbox text="Remember me" isChecked={false} />
      <Button text="Next" onCLick={() => {}} />
    </div>
  );
}

export default LogInScreen;
