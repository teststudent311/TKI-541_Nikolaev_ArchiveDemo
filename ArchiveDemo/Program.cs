// <copyright file="Program.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ArchiveDemo
{
    using System;
    using System.Linq;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using ORM;

    /// <summary>
    /// Главный класс программы.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        private static void Main()
        {
            // Создаем объекты Inventory и ReadingRoom
            var inventory = new Inventory(1, "Опись 1");
            var readingRoom = new ReadingRoom(1, "Читальный зал 1");

            // Создаем объект Document, передавая объекты Inventory и ReadingRoom
            var document = new Document(1, "Название 1", inventory, readingRoom);

            Console.WriteLine($"{document} --> {inventory}");

            // Используем DbContext для сохранения объектов в базе данных
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=;Database=testbd1;");
            using var context = new AppDbContext(optionsBuilder.Options);

            // Сначала сохраняем объекты, на которые ссылаются внешние ключи
            context.Inventories.Add(inventory);
            context.ReadingRooms.Add(readingRoom);

            context.Documents.Add(document);
            context.SaveChanges();

            var foundDocument = context.Documents
                .Include(d => d.Inventory)
                .Include(d => d.ReadingRoom)
                .FirstOrDefault(d => d.Title == "Название 1");

            Console.WriteLine(foundDocument);
        }
    }
}