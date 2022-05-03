using MvcApuestasPrimerExamenAPE.Data;
using MvcApuestasPrimerExamenAPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasPrimerExamenAPE.Repositories
{
    public class RepositoryApuestas
    {
        private ApuestasContext context;
        public RepositoryApuestas(ApuestasContext context)
        {
            this.context = context;
        }

        public List<Jugador> GetJugadores(int idEquipo)
        {
            return this.context.Jugadores.Where(x => x.IdEquipo == idEquipo).ToList(); 
        }
        public List<Equipo> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }
        public List<Apuesta> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }
    }
}
