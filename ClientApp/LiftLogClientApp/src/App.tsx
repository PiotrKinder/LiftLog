import "./Style.css";
import Button from "./controls/button/Button";
import Input from "./controls/input/Input";
import IconTypeEnum from "./helpers/iconManager/enums/IconTypeEnum";

function App() {
  return (
    <>
      <Input icon={IconTypeEnum.User} text="" placeholder="Email" />
      <Button text="Log in" />
    </>
  );
}

export default App;
