using System.ComponentModel.DataAnnotations;

namespace my_new_app.Models
{
    public class TodoUser
    {
        [Key]
        public int id { get; set; }

        public string username  { get; set; }

        public string password { get; set; }
    }
}