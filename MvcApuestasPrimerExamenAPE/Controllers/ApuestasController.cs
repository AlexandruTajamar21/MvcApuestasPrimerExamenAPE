using Microsoft.AspNetCore.Mvc;
using MvcApuestasPrimerExamenAPE.Models;
using MvcApuestasPrimerExamenAPE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasPrimerExamenAPE.Controllers
{
    public class ApuestasController : Controller
    {
        private RepositoryApuestas repo;

        public ApuestasController(RepositoryApuestas repo)
        {
            this.repo = repo;
        }

        public IActionResult IndexEquipos()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }

        public IActionResult Jugadores(int idEquipo)
        {
            List<Jugador> jugadores = this.repo.GetJugadores(idEquipo);
            return View(jugadores);
        }
    }
}
