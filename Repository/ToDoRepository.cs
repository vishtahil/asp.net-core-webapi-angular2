using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using  Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoRepository : ITodoRepository
    {
        public TodoRepository()
        {
        }

        public IEnumerable<TodoItem> GetAll()
        {
            using(var todoContext = new ToDoContext()){
                return todoContext.ToDoItems.ToList();
            }
        }

        public void Add(TodoItem item)
        {
            using (var todoContext = new ToDoContext())
            {
                item.Key = System.Guid.NewGuid().ToString();
                todoContext.ToDoItems.Add(item);
                todoContext.SaveChanges();
            }
        }

        public TodoItem Find(string key)
        {
            using (var todoContext = new ToDoContext())
            {
               return todoContext.ToDoItems.Where(x=>x.Key==key).FirstOrDefault();
            }
        }

        public TodoItem Remove(string key)
        {
           using (var todoContext = new ToDoContext())
            {
                var toDoItem= Find(key);
                todoContext.Remove(toDoItem);
                todoContext.SaveChanges();
                return toDoItem;
            }
        }

        public void Update(TodoItem item)
        {
            using (var todoContext = new ToDoContext())
            {
                todoContext.Entry(item).State = EntityState.Modified;
                todoContext.SaveChanges();
            }
        }
    }
}