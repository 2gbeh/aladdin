import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { catchError } from 'rxjs';
//
import { TodosService } from '@/services/todos/todos.service';

@Component({
  selector: 'app-transactions',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './transactions.component.html',
  styleUrl: './transactions.component.scss',
})
export class TransactionsComponent {
  private router = inject(Router);
  private todosService = inject(TodosService);

  data = toSignal(
    this.todosService.getAll().pipe(
      catchError((err) => {
        console.log('🚀 ~ TransactionsComponent ~ err:', err);
        throw err;
      }),
    ),
    { initialValue: [] },
  );

  gotoDashboard() {
    this.router.navigateByUrl('/dashboard');
  }
}
