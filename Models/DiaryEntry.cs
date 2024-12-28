using System.ComponentModel.DataAnnotations;

namespace diary_webapp.Models
{
    public class DiaryEntry
    {
        //[Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter a Title")]
        //[StringLength(100,MinimumLength = 3, ErrorMessage = "Title Must be between 3 to 100 Characters!")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
