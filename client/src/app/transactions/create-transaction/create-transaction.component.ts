import { Component, input, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-transaction',
  imports: [],
  templateUrl: './create-transaction.component.html',
  styleUrl: './create-transaction.component.scss'
})
export class TransactionDetailsComponent {
  private router = inject(Router);

  id = input.required<string>();

  goBack() {
    this.router.navigate(['/transactions']);

  }
}
