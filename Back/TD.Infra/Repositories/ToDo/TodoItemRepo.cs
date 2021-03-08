using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TD.Core.Todo.Models;
using TD.Core.Todo.Repositories;
using TD.Infra.Context;

namespace TD.Infra.Repositories.ToDo
{
    public class TodoItemRepo : ITodoItemRepo
    {
        private readonly TodoContext _db;
        public TodoItemRepo(TodoContext context)
        {
            _db = context;
        }
        public async Task Add(TodoItemModel todoItem)
        {
             await _db.ToDoTable.AddAsync(todoItem);
             await _db.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<TodoItemModel>> GetAll()
        {
            return await _db.ToDoTable.ToListAsync();
        }

        public async Task<TodoItemModel> GetBy(int todoitemId)
        {
            return await _db.ToDoTable.FindAsync(todoitemId);
        }

        public async Task Update(TodoItemModel todoItem)
        {
            _db.Attach(todoItem);
            _db.Entry(todoItem).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task Remove(TodoItemModel todoItemModel)
        {
            _db.ToDoTable.Remove(todoItemModel);
            await _db.SaveChangesAsync();
        }
    }
}
