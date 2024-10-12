import classes from "./Button.module.css";
import ButtonTypesEnum from "./enums/ButtonTypesEnum";

interface Props {
  text: string;
  onCLick?: () => void;
  type?: ButtonTypesEnum;
}

function Button({ text, onCLick, type }: Props) {
  return (
    <button className={classes.button} type={type} onClick={onCLick}>
      {text}
    </button>
  );
}
export default Button;
