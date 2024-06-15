using DotNet8.NLayerSample.DbService.Entities;
using DotNet8.NLayerSample.Models.Setup.Blog;

namespace DotNet8.NLayerSample.Mapper;

public static class ChangeModel
{
    public static BlogModel Change(this Tbl_Blog dataModel)
    {
        return new BlogModel
        {
            BlogId = dataModel.BlogId,
            BlogTitle = dataModel.BlogTitle,
            BlogAuthor = dataModel.BlogAuthor,
            BlogContent = dataModel.BlogContent
        };
    }

    public static Tbl_Blog Change(this BlogRequestModel requestModel)
    {
        return new Tbl_Blog
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent
        };
    }
}