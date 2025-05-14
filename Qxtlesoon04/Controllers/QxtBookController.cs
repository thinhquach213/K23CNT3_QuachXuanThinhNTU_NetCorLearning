using Microsoft.AspNetCore.Mvc;
using Qxtlesoon04.Models;
using System;
using System.Collections.Generic;

namespace Qxtlesoon04.Controllers
{
    public class QxtBookController : Controller
    {
        private List<QxtBook> qxtBooks;

        public QxtBookController()
        {
            Random rand = new Random();
            qxtBooks = new List<QxtBook>
            {
                new QxtBook
                {
                    QxtId = "B001",
                    QxtTitle = "C# Fundamentals",
                    QxtDescription = "Learn the basics of C# programming language.",
                    QxtImage = $"B001.jpg",
                    QxtPrice = 19.99f,
                    QxtPage = 320
                },
                new QxtBook
                {
                    QxtId = "B002",
                    QxtTitle = "ASP.NET Core Guide",
                    QxtDescription = "A complete guide to building web apps using ASP.NET Core.",
                    QxtImage = $"image/book-{rand.Next(1, 56)}.jpg",
                    QxtPrice = 25.50f,
                    QxtPage = 450
                },
                new QxtBook
                {
                    QxtId = "B003",
                    QxtTitle = "Entity Framework Deep Dive",
                    QxtDescription = "Explore Entity Framework in depth for data access.",
                    QxtImage = $"image/book-{rand.Next(1, 56)}.jpg",
                    QxtPrice = 22.00f,
                    QxtPage = 380
                },
                new QxtBook
                {
                    QxtId = "B004",
                    QxtTitle = "LINQ in Action",
                    QxtDescription = "Master Language Integrated Query with real-world examples.",
                    QxtImage = $"image/book-{rand.Next(1, 56)}.jpg",
                    QxtPrice = 17.75f,
                    QxtPage = 290
                },
                new QxtBook
                {
                    QxtId = "B005",
                    QxtTitle = "Blazor for Beginners",
                    QxtDescription = "Get started with Blazor and build interactive web UIs.",
                    QxtImage = $"image/book-{rand.Next(1, 56)}.jpg",
                    QxtPrice = 21.90f,
                    QxtPage = 310
                }
            };
        }

        // GET: /QxtBook/QxtIndex
        public IActionResult QxtIndex()
        {
            return View(qxtBooks);
        }
        public IActionResult QxtCreate()
        {
           QxtBook qxtBook = new QxtBook();
            return View(qxtBook);
        }
    }
}
