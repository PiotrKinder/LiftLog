import IconManager from "../../helpers/iconManager/IconManager";
import IconTypeEnum from "../../helpers/iconManager/enums/IconTypeEnum";
import classes from "./Tile.module.css"
interface Props{
    text : string;
    iconKey: IconTypeEnum;
    onClick : () => void;
}

function Tile ({onClick, iconKey, text}:Props){
    return(<div className={classes.container} onClick={onClick}>
 <span className={classes.icon}>
          {IconManager.getIcon(iconKey)}
        </span>
        <span>{text}</span>
    </div>);
}

export default Tile;