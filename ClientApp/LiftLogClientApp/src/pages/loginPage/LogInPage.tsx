import Input from "../../components/input/Input";
import classes from "./LogInPage.module.css";
import icons from "../../helpers/iconManager/enums/IconTypeEnum";
import Checkbox from "../../components/checkbox/Checkbox";
import Button from "../../components/button/Button";
import Header from "../../components/header/Header";
import { useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import ButtonTypesEnum from "../../components/button/enums/ButtonTypesEnum";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../store/index";
import { fetchLoginData } from "../../store/loginSlice";
import { AuthRequest } from "../../api/Contracts";

function LogInPage() {
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();
  const { token, loading } = useSelector((state: RootState) => state.login);

  function buttonBackHandler() {
    navigate("/");
  }

  function handleInputEmailChange(value: string) {
    setEmail(value);
  }

  function handleInputPasswordChange(value: string) {
    setPassword(value);
  }

  function logInHandler(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    const authData = new AuthRequest({ email, password });
    dispatch(fetchLoginData(authData));
  }

  useEffect(() => {
    if (token && !loading) {
      navigate("/menu");
    }
  });

  return (
    <div className={classes.container}>
      <form onSubmit={logInHandler}>
        <Header text="Log in" />
        <Input
          onInputChange={handleInputEmailChange}
          placeholder="Email"
          type="email"
          icon={icons.Mail}
        />
        <Input
          onInputChange={handleInputPasswordChange}
          placeholder="Password"
          type="password"
          icon={icons.Key}
        />
        <Checkbox text="Remember me" isChecked={false} />
        <Button type={ButtonTypesEnum.submit} text="Next" />
        <Button
          type={ButtonTypesEnum.button}
          text="Back"
          onCLick={buttonBackHandler}
        />
      </form>
    </div>
  );
}

export default LogInPage;
