using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FileStorageApi.Models
{
    public class UserData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserDataId { get; set; }

        public List<UserFile> Files { get; set; } = new List<UserFile>();

        [Required]
        [ForeignKey("Id")]
        public string UserId { get; set; }
    }
}