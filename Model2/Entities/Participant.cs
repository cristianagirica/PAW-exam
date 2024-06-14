using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public List<string> concerts { get; set; }

        public Participant()
        {

        }

        public Participant(int id, string name, string email, DateTime birthDate, List<string> concerts)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            this.concerts = concerts;
        }

        public static explicit operator int(Participant participant)
        {
            int count = 0;
            foreach(var concert in participant.concerts)
            {
                count++;
            }
            return count;
        }
    }
}
