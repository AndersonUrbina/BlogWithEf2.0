using Microsoft.AspNetCore.Mvc;
using BlogWithEf.Data;
using BlogWithEf.Models;

namespace BlogWithEf.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsApiController : ControllerBase
    {
        private readonly BlogDbContext _context;
        public PostsApiController(BlogDbContext context)
        {
            _context = context;
        }
        // GET: /api/Posts - Returns all post data in JSON format
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _context.Posts.ToList();
            return Ok(posts);
        }

        // Post: /api/Posts - Creates a new post from JSON data
        [HttpPost]
        public IActionResult CreatePost([FromBody] Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, post);
        }

    }
}
