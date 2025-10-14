import { Component, AfterViewInit, OnDestroy } from '@angular/core';
// 
import { TitleBarComponent } from '@/components/organisms/title-bar/title-bar.component';

@Component({
  selector: 'app-dashboard',
  imports: [
    TitleBarComponent
  ],
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements AfterViewInit, OnDestroy {
  private scripts: HTMLScriptElement[] = [];

  ngAfterViewInit() {
    this.loadScript('lib/waypoints/lib/jquery.waypoints.min.js');
    this.loadScript('lib/jquery.counterup/jquery.counterup.min.js');
    this.loadScript('lib/apexcharts/apexcharts.min.js');
    this.loadScript('scripts/dashboard.init.js');
    this.loadScript('scripts/app.js');

  }

  private loadScript(src: string) {
    const script = document.createElement('script');
    script.src = src;
    document.body.appendChild(script);
    this.scripts.push(script);
  }

  ngOnDestroy() {
    this.scripts.forEach(script => script.remove());
  }
}
