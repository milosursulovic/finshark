using System.ComponentModel.DataAnnotations;

namespace Finshark.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 chars")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 chars")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content must be 5 chars")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 chars")]
        public string Content { get; set; } = string.Empty;
    }
}
