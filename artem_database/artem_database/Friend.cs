using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace artem_database
{
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public string Sex { get; set; }
        public int Age { get { return age; }
            set { HashSet(ref age, value); }
        }


    }
}
