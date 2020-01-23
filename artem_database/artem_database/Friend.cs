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
        private DateTime date { get; set; }
        public string Sex { get; set; }

        public DateTime Date 
        {
            get 
                { return date; }
            set {
                date = value;
                Age = (DateTime.Now.Year - value.Year);
                if (Age <= 7)
                {
                    Status = "Молодой";
                }
                else if(Age <= 18)
                {
                    Status = "Не совсем молодой";
                }
                else
                {
                    Status = "Взрослый";
                }

                DateTime next = new DateTime(DateTime.Today.Year, Date.Month, Date.Day);
                if (next < DateTime.Today)
                {
                    next = new DateTime(DateTime.Today.Year + 1, date.Month, date.Day);
                }
                DLeft = (next - DateTime.Today).Days;
                if (DLeft <= 3)
                {
                    Todo = "!";
                    
                }
                else
                {
                    Todo = "";
                }

                

            }
        }
        public bool sswitch { get; set; }
        public int DLeft { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public bool Close { get; set; }
        public string Todo { get; set; }




    }
}
