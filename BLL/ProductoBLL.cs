using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Tarea6Lab.DAL;
using Tarea6Lab.Models;

namespace Tarea6Lab.BLL // BLL
{
    public class ProductoBLL
    {
        private Contexto _contexto;

        public ProductoBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Productos producto)
        {
            if (!Existe(producto.Descripcion))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        private bool Insertar(Productos producto)
        {
            bool paso = false;

            try
            {
                
                if (_contexto.Productos.Add(producto) != null)
                    paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Modificar(Productos producto)
        {
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM ProductosDetalle WHERE ProductoId={producto.ProductoId}");

                foreach (var Anterior in producto.Detalle)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }

                _contexto.Entry(producto).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Eliminar(int Id)
        {
            bool paso = false;

            try
            {
                var producto = _contexto.Productos.Find(Id);

                if (producto != null)
                {
                    _contexto.Productos.Remove(producto);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public Productos Buscar(int Id)
        {
            Productos producto;

            try
            {
                producto = _contexto.Productos
                .Include(x => x.Detalle)
                .Where(p => p.ProductoId == Id)
                .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return producto;
        }

        public bool Existe(string descripcion)
        {
            bool paso = false;

            try
            {
                paso = _contexto.Productos.
                Any(p => p.Descripcion == descripcion);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public bool Existe(int Id)
        {
            bool paso = false;

            try
            {
                paso = _contexto.Productos.Any(p => p.ProductoId == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }  
        
        public List<Productos> GetList(Expression<Func<Productos, bool>> critero)
        {
            List<Productos> listaProductos = new List<Productos>();

            try
            {
                listaProductos = _contexto.Productos.Where(critero).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return listaProductos;
        }

    }
}