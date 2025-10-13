import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-title-bar',
  templateUrl: './title-bar.component.html',
})
export class TitleBarComponent {
  @Input() title: string = '';
}
