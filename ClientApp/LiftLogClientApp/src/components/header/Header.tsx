import classes from "./Header.module.css";

interface Props {
  text: string;
}

function Header({ text }: Props) {
  return (
    <div className={classes.container}>
      <h1 className={classes.header}>{text}</h1>
    </div>
  );
}

export default Header;
