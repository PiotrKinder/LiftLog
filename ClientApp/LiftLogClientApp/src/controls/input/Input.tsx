import classes from "./Input.module.css";
import IconManager from "../../helpers/iconManager/IconManager";
import { useState } from "react";
import IconTypeEnum from "../../helpers/iconManager/enums/IconTypeEnum";

interface Props {
  isValid?: boolean;
  validationMessage?: string;
  placeholder: string;
  icon?: IconTypeEnum;
  type?: string;
}
function Input({ icon, placeholder, type, isValid, validationMessage }: Props) {
  const [isActive, setIsActive] = useState(false);

  function onFocusEventHandler(): void {
    setIsActive(true);
  }
  function onBlurEventHandler(): void {
    setIsActive(false);
  }

  return (
    <div
      className={`${classes.container} ${isActive ? classes.active : ""} ${
        isValid ? classes.valid : ""
      }`}
    >
      <input
        placeholder={placeholder}
        className={classes.input}
        onFocus={onFocusEventHandler}
        onBlur={onBlurEventHandler}
        type={type}
      />
      {icon && (
        <span
          className={`${classes.icon} ${isActive ? classes.active : ""} ${
            isValid ? classes.valid : ""
          }`}
        >
          {IconManager.getIcon(icon)}
        </span>
      )}
      {isValid && (
        <div className={classes.validText}>
          <span>{validationMessage}</span>
        </div>
      )}
    </div>
  );
}
export default Input;
