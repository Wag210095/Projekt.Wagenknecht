using Project1.Dtos;
using Project1.Exceptions;
using Project1.Interfaces;
using Project1.Models;
using System.Collections.Generic;

namespace Project1.Services
{
    public class CategoryService : IReadOnlyCategoryService
    {
        private readonly IReadOnlyRepositoryBase<CategoryModel> _readOnlyCategoryRepository;
        private readonly IDateTimeService _dateTimeService;

        public IQueryable<CategoryModel> Categories { get; set; }


        public CategoryService(
            IReadOnlyRepositoryBase<CategoryModel> readOnlycategoryRepository,
            IDateTimeService dateTimeService
            )
        {
            _readOnlyCategoryRepository = readOnlycategoryRepository;
            _dateTimeService = dateTimeService;
        }

        // * Filtering
        // * Sorting
        // * Paging
        public IReadOnlyCategoryService Load()
        {
            Categories = _readOnlyCategoryRepository.GetAll();
            return this;
        }

        public IEnumerable<CategoryDto> GetData()
        {
            IEnumerable<CategoryDto> result = Categories.Select(p => new CategoryDto(
                p.Id,
                p.Name));
            return result;
        }

        public CategoryDto GetById(int id)
        {
            CategoryDto dto = Load()
                .GetData()
                .First(p => p.Id == id);

            return dto;
        }



    }

}
