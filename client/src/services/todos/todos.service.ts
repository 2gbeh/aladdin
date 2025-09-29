import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
//
import { GetAllTodosRequest, GetTodoByIdRequest, ITodo } from './todos.types';

const API_URL = 'https://jsonplaceholder.typicode.com';
const resource = 'todos';

@Injectable({
  providedIn: 'root',
})
export class TodosService {
  private http = inject(HttpClient);

  constructor() {}

  getAll(params?: GetAllTodosRequest): Observable<ITodo[]> {
    return this.http.get<ITodo[]>(`${API_URL}/${resource}`, { params });
  }

  getById(req: GetTodoByIdRequest): Observable<ITodo> {
    return this.http.get<ITodo>(`${API_URL}/${resource}/${req.id}`);
  }
}
