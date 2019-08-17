using System;
using Microsoft.AspNetCore.Http;

namespace akaratak_app.Dtos
{
    public class PhotoToInsertDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}