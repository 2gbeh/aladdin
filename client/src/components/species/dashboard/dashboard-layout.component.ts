import { Component, AfterViewInit, OnDestroy } from '@angular/core';
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
export class DashboardLayoutComponent implements AfterViewInit, OnDestroy {
 private scripts: HTMLScriptElement[] = [];

  ngAfterViewInit() {
    this.loadScript('lib/metismenu/metisMenu.min.js');
    this.loadScript('lib/simplebar/simplebar.min.js');
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
