import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// 
import { HeaderComponent } from '@/components/organisms/header/header.component';
import { SidebarComponent } from '@/components/organisms/sidebar/sidebar.component';
import { AsideComponent } from '@/components/organisms/aside/aside.component';
import { FooterComponent } from '@/components/organisms/footer/footer.component';
import { ScriptLoaderService } from '@/store/services/script-loader.service';

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
export class DashboardLayoutComponent implements OnInit {
  constructor(private scriptLoader: ScriptLoaderService) { }

  async ngOnInit() {
    await this.scriptLoader.loadScript('libs/metismenu/metisMenu.min.js');
    await this.scriptLoader.loadScript('libs/simplebar/simplebar.min.js');
  }
}
