using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcApuestasPrimerExamenAPE.Models;
using MvcApuestasPrimerExamenAPE.Repositories;
using MVCDoctoresCasa.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasPrimerExamenAPE.Controllers
{
    public class ApuestasController : Controller
    {
        private RepositoryApuestas repo;
        private ServiceS3 service;

        public ApuestasController(RepositoryApuestas repo, ServiceS3 service)
        {
            this.repo = repo;
            this.service = service;
        }

        public IActionResult IndexEquipos()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }

        public IActionResult Jugadores(int id)
        {
            List<Jugador> jugadores = this.repo.GetJugadores(id);
            return View(jugadores);
        }
        public IActionResult Apuestas()
        {
            List<Apuesta> apuestas = this.repo.GetApuestas();
            return View(apuestas);
        }

        public IActionResult CreateApuesta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateApuesta(Apuesta apuesta)
        {
            this.repo.InsetApuesta(apuesta);
            return RedirectToAction("Apuestas");
        }

        public IActionResult CreateJugador(int idEquipo)
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJugador(int IdJugador, string Nombre, string Posicion, IFormFile Imagen, int IdEquipo)
        {
            string extension = Imagen.FileName.Split(".")[1];
            string fileName = Nombre.Trim() + "." + extension;
            using (Stream stream = Imagen.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, fileName);
            }
            Jugador jugador = new Jugador()
            {
                IdJugador = IdJugador,
                Nombre = Nombre,
                Posicion = Posicion,
                Imagen = fileName,
                IdEquipo = IdEquipo
            };
            this.repo.InsertJugador(jugador);
            return RedirectToAction("IndexEquipos");
        }
    }
}
