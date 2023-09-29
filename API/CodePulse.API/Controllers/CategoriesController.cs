using AutoMapper;
using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(
        IMapper mapper,
        ICategoryRepository categoryRepository
    )
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }


    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
    {
        var category = _mapper.Map<Category>(request);

        _categoryRepository.CreateAsync(category);

        var dto = _mapper.Map<CategoryDto>(category);
        return Ok(dto);
    }
}
