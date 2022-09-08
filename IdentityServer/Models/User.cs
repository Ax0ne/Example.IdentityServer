using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Models
{
    public class User
    {
        public User()
        {
            CreateTime = DateTime.Now;
        }

        public int Id { get; set; }

        [NotMapped]
        public string SubjectId => Id.ToString();

        [MaxLength(12)] public string Name { get; set; }
        [MaxLength(11)] public string PhoneNumber { get; set; }
        [MaxLength(12)] public string Nick { get; set; }
        [MaxLength(12)] public string Password { get; set; }
        public DateTime CreateTime { get; set; }
    }
}