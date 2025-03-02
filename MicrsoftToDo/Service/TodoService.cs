﻿using Microsoft.EntityFrameworkCore;
using MicrsoftToDo.Models;
using System.ComponentModel;
using System.Reflection;

namespace MicrsoftToDo.Service
{
    public class TodoService
    {
        private readonly TodoDbContext _context;

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetTodosAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task AddTodoAsync(TodoItem todo)
        {
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(TodoItem todo)
        {
            _context.TodoItems.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<TodoItem>> SearchBoxAsync(string name)
        {
            var todo = await _context.TodoItems.Where(a => a.Title == name).ToListAsync();   
            return todo;
            //if (todo != null)
            //{
            //    _context.TodoItems.Remove(todo);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}

