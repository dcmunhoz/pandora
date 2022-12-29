using AutoMapper;
using Pandora.Application.Business.Categories.Commands;
using Pandora.Application.Business.Categories.Results;
using Pandora.Application.Dto.Category.Requests;
using Pandora.Application.Dto.Category.Responses;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Mapper
{
    public class CategoryMap: Profile
    {
        public CategoryMap()
        {
            CreateMap<CreateCategoryRequest , CreateCategoryCommand>()
                .ConstructUsing(src => new CreateCategoryCommand(src.Description, src.ParentId, "7beb3385-e735-4f39-9ccf-b95ec9175ddf"));

            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<Category, CategoryResult>();
            CreateMap<CategoryResult, CreateCategoryResponse>();
        }
    }
}
