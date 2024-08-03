import "./Style.css";
import Button from "./controls/button/Button";
import Checkbox from "./controls/checkbox/Checkbox";
import Input from "./controls/input/Input";
import Tile from "./controls/tile/Tile";
import IconTypeEnum from "./helpers/iconManager/enums/IconTypeEnum";

function App() {
  return (
    <>
      <Input icon={IconTypeEnum.User} text="" placeholder="Email" />
       {/* <Button text="Log in" /> */}
      <Checkbox text="Email" isChecked={true} />
      <Tile onClick={()=>{}} text="Bench press" iconKey={IconTypeEnum.Key}></Tile>
    </>
  );
}

export default App;
