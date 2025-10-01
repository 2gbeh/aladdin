import { inject, Injectable } from "@angular/core";
import { Title } from "@angular/platform-browser";
import { RouterStateSnapshot, TitleStrategy } from "@angular/router";
// 
import { APP } from "@/constants/APP";

@Injectable({ providedIn: 'root' })
export class CustomTitleStrategy extends TitleStrategy {
  private readonly title = inject(Title);

  override updateTitle(routerState: RouterStateSnapshot) {
    const title = this.buildTitle(routerState);

    if (title !== undefined) {
      this.title.setTitle(`${title} | ${APP.name}`);
    }
  }
}

