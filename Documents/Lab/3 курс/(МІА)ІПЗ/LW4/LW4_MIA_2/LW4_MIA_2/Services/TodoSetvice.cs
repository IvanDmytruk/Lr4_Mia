using LW4_MIA_2.Models;
using LW4_MIA_2.Repositories;
using System.Collections.Generic;

namespace LW4_MIA_2.Services
{

    public class TodoSetvice : ITodoServices
    {
        private readonly IRepositoriesTodo _todos;
        public TodoSetvice(IRepositoriesTodo todos)
        {
            _todos = todos;
        }

        public Task<List<Todo>> GetTodosAsync(Todo todo)
        { 
        if (todo.Validate())
            {
                return _todos.GetTodosAsync(todo);
            }
            throw new ArgumentException("Invalid Todo object");
        }
    }
}
