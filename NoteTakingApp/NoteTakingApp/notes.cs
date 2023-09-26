using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NoteTakingApp
{
    public class notes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public String title { get; set; }
        public string description { get; set; }
        
    }
}
