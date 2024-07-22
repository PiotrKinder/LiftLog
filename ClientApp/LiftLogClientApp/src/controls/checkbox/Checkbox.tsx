import { useState } from "react";
import classes from "./Checkbox.module.css";

interface Props {
  isValid?: boolean;
  text: string;
  isChecked: boolean;
}

function Checkbox({ text, isChecked }: Props) {
  const [checked, setChecked] = useState(false);

  const handleChange = () => {
    setChecked(!checked);
    isChecked = !checked;
  };

  return (
    <div className={classes.checkbox_wrapper}>
      <label className={classes.checkbox}>
        <input
          className={`${classes.checkbox__trigger} ${classes.visuallyhidden}`}
          type="checkbox"
          onClick={handleChange}
          checked={checked}
        />
        <span className={classes.checkbox__symbol}>
          <svg
            aria-hidden="true"
            className={classes.icon_checkbox}
            width="28px"
            height="28px"
            viewBox="0 0 28 28"
            version="1"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path d="M4 14l8 7L24 7"></path>
          </svg>
        </span>
        <p className={classes.checkbox__textwrapper}>{text}</p>
      </label>
    </div>
  );
}
export default Checkbox;
