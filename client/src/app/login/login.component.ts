import { Component, signal } from '@angular/core';
import { FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

const name = 'login'

@Component({
  standalone: true,
  selector: `app-${name}`,
  templateUrl: `./${name}.component.html`,
  styleUrl: `./${name}.component.scss`,
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule
  ],
})
export class LoginComponent {
  hide = signal(true);

  form = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email,
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.pattern(/^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$/),
    ]),
  });

  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }
}
