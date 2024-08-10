import Button from "../../controls/button/Button";
import classes from "./WelcomeScreen.module.css";
import background from "../../../public/background.gif";
import logo from "../../../public/liftLogLogov2whiteClear.png";

function WelcomeScreen() {
  return (
    <div className={classes.container}>
      <div className={classes.background}>
        <img src={logo} className={classes.logo} />
        <div className={classes.filter} />
        <img src={background} className={classes.img} />

        <div className={classes.buttonMenu}>
          <Button text="Log in" onCLick={() => {}} />
          <Button text="Sign up" onCLick={() => {}} />
        </div>
      </div>
    </div>
  );
}

export default WelcomeScreen;
