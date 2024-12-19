using Microsoft.EntityFrameworkCore;
//using SuperOferta.Migrations;
using SuperOferta.Models;
using System;

namespace SuperOferta.Data
{
    public class ProductoService
    {
        private readonly SupermercadoContext _context;

        public ProductoService(SupermercadoContext context)
        {
            _context = context;
        }

        public async Task<bool> deleteProductooById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            //solo porque estoy devolviendo tipo bool mayor a 0
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Producto>> GetAllProductos()
        {
            return await _context.Productos.ToListAsync();


        }



        public async Task<bool> insertProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> SaveProducto(Producto producto)
        {
            if (producto.Id > 0)
            {
                return await updateProducto(producto);
            }
            else
            {
                return await insertProducto(producto);
            }
        }

        public async Task<bool> updateProducto(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _context.Productos.FindAsync(id);
        }
        public async Task EliminarProductosVencidos()
        {
            var actual = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"La fecha actual es: {actual}");
            var productosVencidos = await _context.Productos
            .Where(p => p.FechaCaducidad.HasValue && p.FechaCaducidad <= actual)
        .ToListAsync();

            if (productosVencidos.Count > 0)
            {
                foreach(var pvencido in productosVencidos)
                {
                  //  deleteProductooById(pvencido.Id);
                }

            }
              await _context.SaveChangesAsync() ;
         }
        }
    }


    