import { Icon } from "semantic-ui-react";
import Tile from "../../components/tile/Tile";
import IconTypeEnum from "../../helpers/iconManager/enums/IconTypeEnum";

function MenuPage() {
  return (
    <div>
      <Tile text={"Test"} iconKey={IconTypeEnum.User} onClick={() => {}} />
    </div>
  );
}

export default MenuPage;
