﻿using App.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

    public class ProductsController(IProductService productService) : CustomBaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await productService.GetAllAsync());

        [HttpGet("{pageNo:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedAll(int pageNo,int pageSize) => CreateActionResult(await productService.GetPagedAllAsync(pageNo,pageSize));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await productService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request) => CreateActionResult(await productService.CreateAsync(request));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,UpdateProductRequest request) => CreateActionResult(await productService.UpdateAsync(id,request));

        [HttpPatch("stock:int")]
        public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) => CreateActionResult(await productService.UpdateStockAsync(request));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteAsync(id));

}

    

