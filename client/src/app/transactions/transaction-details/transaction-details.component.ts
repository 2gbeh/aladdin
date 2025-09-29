import { Component, inject, OnInit, signal, input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { catchError, switchMap } from 'rxjs';
//
import { TodosService } from '@/services/todos/todos.service';
import { ITodo } from '@/services/todos/todos.types';

@Component({
  selector: 'app-transaction-details',
  standalone: true,
  imports: [],
  templateUrl: './transaction-details.component.html',
  styleUrl: './transaction-details.component.scss',
})
export class TransactionDetailsComponent {
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private todosService = inject(TodosService);

  // grab id from the route as a signal
  data = toSignal(
    this.route.paramMap.pipe(
      // paramMap is an observable → extract the id
      switchMap((params) => {
        const userId = Number(params.get('id'));
        
        if (!userId) throw new Error('Invalid id in route');
        
        return this.todosService.getAll({ userId }).pipe(
          catchError((err) => {
            console.log("🚀 ~ TransactionDetailsComponent ~ err:", err)
            throw err;
          })
        );
      })
    ),
    { initialValue: [] as ITodo[] }
  );

  goBack() {
    this.router.navigate(['../'], { relativeTo: this.route });
  }
}
