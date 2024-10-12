import classes from "./Input.module.css";
import IconManager from "../../helpers/iconManager/IconManager";
import { useState } from "react";
import IconTypeEnum from "../../helpers/iconManager/enums/IconTypeEnum";

interface Props {
  onInputChange: (value: string) => void;
  isValid?: boolean;
  validationMessage?: string;
  placeholder: string;
  icon?: IconTypeEnum;
  type?: string;
}
function Input({
  onInputChange,
  icon,
  placeholder,
  type,
  isValid,
  validationMessage,
}: Props) {
  const [isActive, setIsActive] = useState(false);

  function onFocusEventHandler(): void {
    setIsActive(true);
  }
  function onBlurEventHandler(): void {
    setIsActive(false);
  }
  function handleHange(event: React.ChangeEvent<HTMLInputElement>) {
    onInputChange(event.target.value);
  }

  return (
    <div
      className={`${classes.container} ${isActive ? classes.active : ""} ${
        isValid ? classes.valid : ""
      }`}
    >
      <input
        onChange={handleHange}
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
