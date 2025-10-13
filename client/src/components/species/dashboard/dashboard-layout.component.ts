import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// 
import { HeaderComponent } from '@/components/organisms/header/header.component';
import { SidebarComponent } from '@/components/organisms/sidebar/sidebar.component';
import { AsideComponent } from '@/components/organisms/aside/aside.component';
import { FooterComponent } from '@/components/organisms/footer/footer.component';

@Component({
  selector: 'app-dashboard-layout',
  imports: [
    RouterOutlet, 
    HeaderComponent, 
    SidebarComponent, 
    FooterComponent, 
    AsideComponent
  ],
  templateUrl: './dashboard-layout.component.html',
})
export class DashboardLayoutComponent {

}
