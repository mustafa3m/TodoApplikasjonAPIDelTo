using TodoApplikasjonAPIDelTo;

namespace TodoApplikasjonAPIDelTo.Services
{
    public class TodoService : ITodoService
    {
        private static List<Todo> _todos = new List<Todo>();
        private static int _nextId = 1;

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            return await Task.FromResult(_todos);
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await Task.FromResult(_todos.FirstOrDefault(t => t.Id == id));
        }

        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            todo.Id = _nextId++;
            _todos.Add(todo);
            return await Task.FromResult(todo);
        }

        public async Task<bool> UpdateTodoAsync(int id, Todo todo)
        {
            var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
            {
                return await Task.FromResult(false);
            }

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.IsCompleted = todo.IsCompleted;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return await Task.FromResult(false);
            }

            _todos.Remove(todo);
            return await Task.FromResult(true);
        }
    }
}
