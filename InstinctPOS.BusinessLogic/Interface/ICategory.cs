using InstinctPOS.Domain.Dtos.Category;
using InstinctPOS.Domain.Models;


namespace InstinctPOS.BusinessLogic.Interface
{
    public interface ICategory
    {
        Task<APIListResponse3<Category>> GetCategory(int pageNumber, int pageSize);
        Task<APIResponse<Category>> GetSingleCategory(int Id);
        Task<APIResponse<CreateCategoryDto>> CreateCategory(CreateCategoryDto request);
        Task<APIResponse<UpdateCategoryDto>> UpdateCategory(UpdateCategoryDto request);
    }
}
