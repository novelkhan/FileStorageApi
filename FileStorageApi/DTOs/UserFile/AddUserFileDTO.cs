using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FileStorageApi.DTOs.UserFile
{
    public class AddUserFileDTO
    {
        [Required]
        public IFormFile file { get; set; }
    }
}