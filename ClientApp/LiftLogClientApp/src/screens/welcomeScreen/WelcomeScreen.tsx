import Button from "../../controls/button/Button";
import classes from "./WelcomeScreen.module.css";
import background from "../../../public/background.gif";
import logo from "../../../public/liftLogLogov2whiteClear.png";
import { screenActions } from "../../slices/screenSlice/screenSlice";
import { useDispatch } from "react-redux";
import ScreenEnum from "../../enums/ScreenEnum";
import { useNavigate } from "react-router-dom";

function WelcomeScreen() {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  function buttonLoginHandler() {
    navigate("/login");
  }

  function buttonSignupHandler() {
    navigate("/signup");
  }

  return (
    <div className={classes.container}>
      <div className={classes.background}>
        <img src={logo} className={classes.logo} />
        <div className={classes.filter} />
        <img src={background} className={classes.img} />

        <div className={classes.buttonMenu}>
          <Button text="Log in" onCLick={buttonLoginHandler} />
          <Button text="Sign up" onCLick={buttonSignupHandler} />
        </div>
      </div>
    </div>
  );
}

export default WelcomeScreen;
