using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro_Prioridad1.DAL;
using Registro_Prioridad1.Models;

namespace Registro_Prioridad1.BLL
{
    public class SistemasBLL
    {
        private readonly PrioridadContext _contexto;
        public SistemasBLL(PrioridadContext contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int SistemaId)
        {
            return _contexto.Sistemas.Any(s => s.SistemaId == SistemaId);
        }

        private bool Insertar(Sistemas Sistema)
        {
            _contexto.Sistemas.Add(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        public bool Modificar(Sistemas Sistema)
        {
            _contexto.Update(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        public bool Guardar(Sistemas Sistema)
        {
            if(!Existe(Sistema.SistemaId))
               return Insertar(Sistema);
            else
               return Modificar(Sistema);
        }

        public bool Eliminar(Sistemas Sistema)
        {
            _contexto.Sistemas.Remove(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        public Sistemas? Buscar(int SistemaId)
        {
            return _contexto.Sistemas 
                .AsNoTracking() 
                .FirstOrDefault(s => s.SistemaId == SistemaId);
        }

        public List<Sistemas> GetList(Expression<Func<Sistemas, bool>> Criterio)
        {
            return _contexto.Sistemas 
                .Where(Criterio) 
                .AsNoTracking() 
                .ToList();
        }
    }
}