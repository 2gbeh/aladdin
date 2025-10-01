import { Component, input, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-transaction',
  imports: [],
  templateUrl: './edit-transaction.component.html',
  styleUrl: './edit-transaction.component.scss'
})
export class EditTransactionComponent {
  private router = inject(Router);

  identifier = input.required<string>();

  goBack() {
    this.router.navigate(['/transactions']);

  }
}
