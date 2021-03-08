using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TD.Core.Todo.Models
{
    public class TodoItemModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
