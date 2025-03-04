using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosApi.Data;
using ProductosApi.DTOs;
using ProductosApi.Models;

namespace ProductosApi.Controllers
{
    [Route("api/productos")] 
    [ApiController] 
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductosController(AppDbContext context, IMapper mapper)
        {
            _context = context; // Inyecta el contexto de la base de datos
            _mapper = mapper; // Inyecta AutoMapper 
        }

        [HttpGet] // Endpoint para obtener todos los productos
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")] // Endpoint para obtener un producto por ID
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound(); 
            return producto;
        }

        [HttpPost] // Endpoint para crear un nuevo producto
        public async Task<ActionResult<Producto>> PostProducto(ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO); 
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync(); // Guarda los cambios en la BD
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto); // Retorna 201 con la ubicación del nuevo recurso
        }

        [HttpPut("{id}")] // Endpoint para actualizar un producto existente
        public async Task<IActionResult> PutProducto(int id, ProductoDTO productoDTO)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound(); 

            _mapper.Map(productoDTO, producto); 
            await _context.SaveChangesAsync(); // Guarda los cambios en la BD
            return NoContent(); // Retorna 204 sin contenido
        }

        [HttpDelete("{id}")] // Endpoint para eliminar un producto
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound(); // Retorna 404 si no existe

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync(); // Guarda los cambios en la BD
            return NoContent(); // Retorna 204 sin contenido
        }
    }
}
