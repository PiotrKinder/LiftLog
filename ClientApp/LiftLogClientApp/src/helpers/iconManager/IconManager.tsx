import IconTypeEnum from "./enums/IconTypeEnum";
import { MdOutlineVerifiedUser } from "react-icons/md";
import { PiUserCircleLight } from "react-icons/pi";
import { TfiKey } from "react-icons/tfi";
import { CiMail } from "react-icons/ci";

class IconManager {
  public static getIcon(iconType: IconTypeEnum) {
    switch (iconType) {
      case IconTypeEnum.Mail:
        return <CiMail />;
      case IconTypeEnum.Key:
        return <TfiKey />;
      case IconTypeEnum.User:
        return <PiUserCircleLight />;
      case IconTypeEnum.Confirm:
        return <MdOutlineVerifiedUser />;
      default:
        throw new Error(`Unsupported icon type: ${iconType}`);
    }
  }
}
export default IconManager;
