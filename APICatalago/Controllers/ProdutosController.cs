﻿using APICatalago.Context;
using APICatalago.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalago.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound();
            }
            return produtos;
        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            return produto;
        }
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }
        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Produto produto)
        {
            if( id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(produto);
        }
        [HttpDelete]
            public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if(produto is null)
            {
                return NotFound("Produto não localizado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(produto); 
        }

    }
}
