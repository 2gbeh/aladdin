import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { TodoDto, initialState } from './todos.util';

export const TodosStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store) => ({
    // Add a new todo
    addTodo(title: string): void {
      const newTodo: TodoDto = {
        id: Date.now(),
        title,
        completed: false,
      };

      patchState(store, (state) => ({
        todos: [...state.todos, newTodo],
      }));
    },

    // Toggle the completed status of a todo
    toggleTodo(id: number): void {
      patchState(store, (state) => ({
        todos: state.todos.map((todo) =>
          todo.id === id ? { ...todo, completed: !todo.completed } : todo
        ),
      }));
    },

    // Remove a todo from the list
    removeTodo(id: number): void {
      patchState(store, (state) => ({
        todos: state.todos.filter((todo) => todo.id !== id),
      }));
    },
  }))
);
