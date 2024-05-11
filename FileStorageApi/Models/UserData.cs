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
        #nullable enable
        public List<UserFile>? Files { get; set; }
        #nullable disable

        [ForeignKey("Id")]
        public string UserId { get; set; }
    }
}