using System;

namespace ConsoleApplication1
{
    public class Item
    {
        public string name { get; set; }

        public ToDoList todolist { get; set; }

        public string content { get; set; }

        public DateTime dateTime { get; set; }
    }
}