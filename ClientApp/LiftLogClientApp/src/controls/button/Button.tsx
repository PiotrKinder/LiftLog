import classes from "./Button.module.css";

interface Props {
  text: string;
  onCLick: () => void;
}

function Button({ text, onCLick }: Props) {
  return (
    <button className={classes.button} onClick={onCLick}>
      {text}
    </button>
  );
}
export default Button;
