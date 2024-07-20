import classes from "./Button.module.css";

interface Props {
  text: string;
}

function Button({ text }: Props) {
  return <button className={classes.button}>{text} </button>;
}
export default Button;
