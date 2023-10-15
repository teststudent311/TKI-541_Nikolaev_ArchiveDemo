// <copyright file="Program.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ArchiveDemo
{
    using System;
    using Domain;
    using ORM;
    using ORM.Repositories;

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

            // Используем сессию NHibernate для сохранения объектов в базе данных
            using var sessionFactory = NHibernateConfigurator.GetSessionFactory(showSql: true);
            using var session = sessionFactory.OpenSession();
            var docRepo = new DocumentRepository(session);

            // Сначала сохраняем объекты, на которые ссылаются внешние ключи
            session.Save(inventory);
            session.Save(readingRoom);

            docRepo.Save(document);
            session.Save(document);
            session.Flush();

            var foundDocument = docRepo.Find(x => x.Title == "Название 1");
            Console.WriteLine(foundDocument);
        }
    }
}