using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TD.Core.Todo.Models;

namespace TD.Infra.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
                
        }

        public DbSet<TodoItemModel> ToDoTable { get; set; }
    }
}
