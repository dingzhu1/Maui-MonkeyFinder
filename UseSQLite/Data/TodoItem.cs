﻿using SQLite;

namespace UseSQLite.Data
{
    public class TodoItem
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string  Notes { get; set; }

        public bool Done { get; set; }


    }
}