import { Component, OnInit  } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
// 
import { ScriptLoaderService } from '@/store/services/script-loader.service';

@Component({
  selector: 'app-auth-layout',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './auth-layout.component.html',
})
export class AuthLayoutComponent implements OnInit {
  constructor(private scriptLoader: ScriptLoaderService) { }

  async ngOnInit() {
    // MUST INSERT LAST 
    await this.scriptLoader.loadScript('scripts/app.js');
  }
}
