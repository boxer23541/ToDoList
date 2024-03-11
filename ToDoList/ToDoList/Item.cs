using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToDoList
{
    internal class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
