import { Component, OnInit } from '@angular/core';
// 
import { TitleBarComponent } from '@/components/organisms/title-bar/title-bar.component';
import { ScriptLoaderService } from '@/store/services/script-loader.service';

@Component({
  selector: 'app-dashboard',
  imports: [
    TitleBarComponent,
  ],
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {
  constructor(private scriptLoader: ScriptLoaderService) { }

  async ngOnInit() {    
    await this.scriptLoader.loadScript('libs/waypoints/lib/jquery.waypoints.min.js');
    await this.scriptLoader.loadScript('libs/jquery.counterup/jquery.counterup.min.js');
    await this.scriptLoader.loadScript('libs/apexcharts/apexcharts.min.js');
    await this.scriptLoader.loadScript('scripts/dashboard.init.js');
    // MUST INSERT LAST 
    await this.scriptLoader.loadScript('scripts/app.js');
  }
}
