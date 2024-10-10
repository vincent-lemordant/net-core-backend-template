using API.DTO;
using AutoMapper;
using Domain.Base;
using Domain.Interfaces;
using Infrastructure.Data.Core.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T, TDto> : ControllerBase where T : BaseEntity where TDto : BaseDto
    {
        private readonly IBaseService<T> _service;
        private readonly IMapper _mapper;
        private readonly ILogger<BaseController<T, TDto>> _logger;

        public BaseController(ILogger<BaseController<T, TDto>> logger, IBaseService<T> service, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("search-by-instance-label")]
        public async Task<IPaginatedList<TDto>> SearchByInstanceLabel([FromQuery] string filter, [FromQuery] PaginationFilter paginationFilter)
        {
            var result = _mapper.Map<IPaginatedList<T>, IPaginatedList<TDto>>(await _service.SearchByInstanceLabelAsync(filter, paginationFilter));
            return result;
        }

        [HttpPost]
        public async Task<TDto> Add([FromBody] TDto model)
        {
            return _mapper.Map<TDto>(await _service.AddAsync(_mapper.Map<T>(model)));
        }

        [HttpPatch("{id}")]
        public async Task<TDto> Update([FromRoute] Guid id, [FromBody] JsonPatchDocument<T> patchModel)
        {
            var existingEntity = await _service.GetById(id);
            patchModel.ApplyTo(existingEntity, ModelState);
            return _mapper.Map<TDto>(await _service.UpdateAsync(existingEntity));
        }

        [HttpGet("{id}")]
        public async Task<TDto> GetById([FromRoute] Guid id)
        {
            return _mapper.Map<TDto>(await _service.GetById(id));
        }
    }
}