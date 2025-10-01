interface ITodosStore {
  todos: TodoDto[];
};

export type TodoDto = {
  id: number;
  title: string;
  completed: boolean;
}

export const initialState: ITodosStore = {
  todos: [],
};