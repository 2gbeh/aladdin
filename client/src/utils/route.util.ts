import { APP } from "@/constants/APP";

export const RouteUtil = {
  title(title?: string) {
    return title ? `${title} | ${APP.name}` : APP.name;
  },
}