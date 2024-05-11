using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorageApi.Models
{
    public class UserFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserFileId { get; set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
        public string Filesize { get; set; }
        public byte[] Filebytes { get; set; }

        [ForeignKey("UserDataId")]
        public int UserDataId { get; set; }
    }
}