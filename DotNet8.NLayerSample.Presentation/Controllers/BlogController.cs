using DotNet8.NLayerSample.BusinessLogic.Services;
using DotNet8.NLayerSample.Models.Setup.Blog;
using DotNet8.NLayerSample.Presentation.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.NLayerSample.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                return Content(await _bL_Blog.GetBlogs());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
        {
            try
            {
                int result = await _bL_Blog.CreateBlog(requestModel);

                return result > 0 ? Created() : BadRequest(MessageResource.SaveFail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel, int id)
        {
            try
            {
                int result = await _bL_Blog.PatchBlog(requestModel, id);

                return result > 0 ? Updated() : BadRequest(MessageResource.SaveFail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                int result = await _bL_Blog.DeleteBlog(id);

                return result > 0 ? Deleted() : BadRequest("Deleting Fail.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
