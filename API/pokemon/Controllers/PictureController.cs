﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PictureController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PictureController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PictureDto>>> GetAllPictures()
        {
            var pictures = await _context.Pictures
                .ProjectTo<PictureDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(pictures);
        }
    }
}
