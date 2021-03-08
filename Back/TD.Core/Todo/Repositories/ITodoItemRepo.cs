using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TD.Core.Todo.Models;

namespace TD.Core.Todo.Repositories
{
    public interface ITodoItemRepo
    {
        Task<IEnumerable<TodoItemModel>> GetAll();
        Task<TodoItemModel> GetBy(int todoitemId);
        Task Add(TodoItemModel todoItem);
        Task Update(TodoItemModel todoItem);

        Task Remove(TodoItemModel todoItem);
    }
}
