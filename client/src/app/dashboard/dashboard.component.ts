import { Component, ViewChild, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
// 
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    RouterLink,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
  shouldRun = true

  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  toggleSidenav() {
    this.sidenav.toggle();
  }
}
