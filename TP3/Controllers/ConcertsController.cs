using Microsoft.AspNetCore.Mvc;
using TP3.Models;
using System.Collections.Generic;
using System.Linq;

namespace TP3.Controllers
{
    public class ConcertsController : Controller
    {
        // Liste statique pour simuler une base de données
        private static List<Concert> concerts = new List<Concert>
        {   new Concert { Id = 1, Title = "Concert Jazz", Artist = "John Doe", Date = new DateTime(2024, 12, 15), Location = "Amphithéâtre de Carthage" },
            new Concert { Id = 2, Title = "Soirée Rock", Artist = "The Rockers", Date = new DateTime(2024, 12, 20), Location = "Théâtre Municipal de Tunis" },
            new Concert { Id = 3, Title = "Concert Classique", Artist = "Orchestre Symphonique", Date = new DateTime(2024, 12, 25), Location = "Opéra de Tunis" },
            new Concert { Id = 4, Title = "Festival de Musique Électronique", Artist = "DJ Alpha", Date = new DateTime(2024, 12, 30), Location = "Palais des Congrès de Tunis" },
            new Concert { Id = 5, Title = "Soirée Hip-Hop", Artist = "MC Blaze", Date = new DateTime(2025, 1, 5), Location = "Parc des Expositions" },
            new Concert { Id = 6, Title = "Concert Pop", Artist = "Lina Stark", Date = new DateTime(2025, 1, 10), Location = "Bardo Theater" }
        };

        // Action pour lister tous les concerts
        public IActionResult Index()
        {
            return View(concerts);
        }

        // Afficher les détails d'un concert
        public IActionResult Details(int id)
        {
            var concert = concerts.FirstOrDefault(c => c.Id == id);
            if (concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }

        // Ajouter un concert (affiche le formulaire)
        public IActionResult Create()
        {
            return View();
        }

        // Ajouter un concert (soumission du formulaire)
        [HttpPost]
        public IActionResult Create(Concert concert)
        {
            concerts.Add(concert);
            return RedirectToAction(nameof(Index));
        }

        // Afficher le formulaire de modification d'un concert
        public IActionResult Edit(int id)
        {
            var concert = concerts.FirstOrDefault(c => c.Id == id);
            if (concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }

        // Soumettre les modifications d'un concert
        [HttpPost]
        public IActionResult Edit(Concert updatedConcert)
        {
            var concert = concerts.FirstOrDefault(c => c.Id == updatedConcert.Id);
            if (concert == null)
            {
                return NotFound();
            }
            concert.Title = updatedConcert.Title;
            concert.Artist = updatedConcert.Artist;
            concert.Date = updatedConcert.Date;
            concert.Location = updatedConcert.Location;

            return RedirectToAction(nameof(Index));
        }

        // Confirmer la suppression d'un concert
        public IActionResult Delete(int id)
        {
            var concert = concerts.FirstOrDefault(c => c.Id == id);
            if (concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }

        // Supprimer un concert (après confirmation)
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var concert = concerts.FirstOrDefault(c => c.Id == id);
            if (concert == null)
            {
                return NotFound();
            }

            concerts.Remove(concert);  // Supprimer le concert
            return RedirectToAction(nameof(Index));  // Rediriger vers la liste des concerts
        }



    }
}
