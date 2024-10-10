using API.DTO;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class InitativeController : BaseController<Initiative, InitativeDto>
    {
        public InitativeController(ILogger<BaseController<Initiative, InitativeDto>> logger,
            IBaseService<Initiative> service, IMapper mapper) : base(logger, service, mapper)
        {
        }
    }
}