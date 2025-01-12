using Finshark.Interfaces;
using Finshark.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Finshark.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }
    }
}
