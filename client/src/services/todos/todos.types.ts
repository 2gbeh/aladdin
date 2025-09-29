export interface ITodo {
  id: number;
  title: string;
  completed: boolean;
  userId: number;
}

export type GetAllTodosRequest = {
  userId?: number;
};

export type GetTodoByIdRequest = {
  id: number;
};
