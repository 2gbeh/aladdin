import { Component, ViewChild, inject } from '@angular/core';
// 
import { MatSidenav } from '@angular/material/sidenav';
import { TitleBarComponent } from '@/components/organisms/title-bar/title-bar.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
   TitleBarComponent
  ],
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent {
  shouldRun = true

  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  toggleSidenav() {
    this.sidenav.toggle();
  }
}
