using DotNet8.NLayerSample.DataAccess.Services;
using DotNet8.NLayerSample.Models.Setup.Blog;

namespace DotNet8.NLayerSample.BusinessLogic.Services
{
    public class BL_Blog
    {
        private readonly DA_Blog _dA_Blog;

        public BL_Blog(DA_Blog dA_Blog)
        {
            _dA_Blog = dA_Blog;
        }

        public async Task<BlogListResponseModel> GetBlogs()
        {
            try
            {
                return await _dA_Blog.GetBlogs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateBlog(BlogRequestModel requestModel)
        {
            try
            {
                if (string.IsNullOrEmpty(requestModel.BlogTitle))
                    throw new Exception("Blog Title cannot be empty.");

                if (string.IsNullOrEmpty(requestModel.BlogAuthor))
                    throw new Exception("Blog Author cannot be empty.");

                if (string.IsNullOrEmpty(requestModel.BlogContent))
                    throw new Exception("Blog Content cannot be empty.");

                return await _dA_Blog.CreateBlog(requestModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> PatchBlog(BlogRequestModel requestModel, int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Id is invalid.");

                return await _dA_Blog.PatchBlog(requestModel, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteBlog(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Id is invalid.");

                return await _dA_Blog.DeleteBlog(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
