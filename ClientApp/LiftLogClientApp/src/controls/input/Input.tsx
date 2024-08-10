import classes from "./Input.module.css";
import IconManager from "../../helpers/iconManager/IconManager";
import { useState } from "react";
import IconTypeEnum from "../../helpers/iconManager/enums/IconTypeEnum";

interface Props {
  isValid?: boolean;
  placeholder: string;
  icon?: IconTypeEnum;
}
function Input({ icon, placeholder }: Props) {
  const [isActive, setIsActive] = useState(false);

  function onFocusEventHandler(): void {
    setIsActive(true);
  }
  function onBlurEventHandler(): void {
    setIsActive(false);
  }

  return (
    <div className={`${classes.container} ${isActive ? classes.active : ""}`}>
      <input
        placeholder={placeholder}
        className={classes.input}
        onFocus={onFocusEventHandler}
        onBlur={onBlurEventHandler}
      />
      {icon && (
        <span className={`${classes.icon} ${isActive ? classes.active : ""}`}>
          {IconManager.getIcon(icon)}
        </span>
      )}
    </div>
  );
}
export default Input;
