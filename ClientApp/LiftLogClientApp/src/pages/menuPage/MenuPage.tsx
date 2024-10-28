import { Icon } from "semantic-ui-react";
import Tile from "../../components/tile/Tile";
import IconTypeEnum from "../../helpers/iconManager/enums/IconTypeEnum";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../store/index";
import { useEffect } from "react";
import { fetchUserExercisesData } from "../../store/exerciseSlice";

function MenuPage() {
  const dispatch = useDispatch<AppDispatch>();
  useEffect(() => {
    dispatch(fetchUserExercisesData());
  });

  function renderTileList() {}

  return (
    <div>
      <Tile text={"Test"} iconKey={IconTypeEnum.User} onClick={() => {}} />
    </div>
  );
}

export default MenuPage;
