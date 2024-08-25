import classes from "./ErrorScreen.module.css";

function ErrorScreen() {
  return (
    <div className={classes.container}>
      <span>Page didn't exist</span>
    </div>
  );
}

export default ErrorScreen;
