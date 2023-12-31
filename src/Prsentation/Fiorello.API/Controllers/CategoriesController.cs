﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.CategoryDTOs;
using Fiorello.Persistance.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fiorello.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id)
    {
            CategoryGetDto result = await _categoryService.GetByIdAsync(id);
            return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult>Post(CategoryCreateDto categoryCreateDto)
    {
            await _categoryService.CreateAsync(categoryCreateDto);
            return StatusCode((int)HttpStatusCode.Created);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
            List <CategoryGetDto> result=await _categoryService.GetAllAsync();
            return Ok(result);
    }
}


