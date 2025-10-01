import {  Component, provideZoneChangeDetection } from '@angular/core';
import { provideHttpClient } from '@angular/common/http';
import { RouterOutlet, provideRouter, TitleStrategy, withComponentInputBinding } from '@angular/router';
import { bootstrapApplication } from '@angular/platform-browser';
// 
import { CustomTitleStrategy } from '@/utils/strategies/custom-title.strategy';
import { appRoutes } from './app/app.routes';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  template: `<router-outlet />`,
})
class AppComponent {
}

bootstrapApplication(AppComponent, {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(appRoutes, withComponentInputBinding()),
    { provide: TitleStrategy, useClass: CustomTitleStrategy },
    provideHttpClient(),
  ],
}).catch((err) => console.error(err));
