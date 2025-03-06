using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Models;
using Pokemon.Services.Interfaces;


namespace Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridCommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public GridCommonController(ICommonService pokemonService)
        {
            _commonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult<GridCommonDto>> GetAllData()
        {
            return Ok(await _commonService.GetAllData());
        }
    }
}
