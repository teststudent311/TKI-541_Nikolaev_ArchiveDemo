// <copyright file="Program.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ArchiveDemo
{
    using System;
    using Domain;
    using Microsoft.EntityFrameworkCore;
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
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=;Database=testbd1;");
            using var context = new AppDbContext(optionsBuilder.Options);

            var documentRepository = new DocumentRepository(context);
            var inventoryRepository = new InventoryRepository(context);
            var readingRoomRepository = new ReadingRoomRepository(context);

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1: Создать документ");
                Console.WriteLine("2: Показать все документы");
                Console.WriteLine("3: Обновить документ");
                Console.WriteLine("4: Удалить документ");
                Console.WriteLine("0: Выход");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateDocument(documentRepository, inventoryRepository, readingRoomRepository);
                        break;
                    case "2":
                        ReadDocuments(documentRepository);
                        break;
                    case "3":
                        UpdateDocument(documentRepository);
                        break;
                    case "4":
                        DeleteDocument(documentRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                        break;
                }
            }
        }

        /// <summary>
        /// Создает новый документ.
        /// </summary>
        /// <param name="documentRepository">Репозиторий документов.</param>
        /// <param name="inventoryRepository">Репозиторий описей.</param>
        /// <param name="readingRoomRepository">Репозиторий читальных залов.</param>
        private static void CreateDocument(DocumentRepository documentRepository, InventoryRepository inventoryRepository, ReadingRoomRepository readingRoomRepository)
        {
            Console.WriteLine("Введите название документа:");
            var title = Console.ReadLine();

            var inventory = CreateOrGetInventory(inventoryRepository);
            var readingRoom = CreateOrGetReadingRoom(readingRoomRepository);

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            var document = new Document(0, title, inventory, readingRoom);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

            documentRepository.Save(document);
            Console.WriteLine("Документ успешно создан.");
        }

        /// <summary>
        /// Создает или получает опись.
        /// </summary>
        /// <param name="inventoryRepository">Репозиторий описей.</param>
        /// <returns>Опись.</returns>
        private static Domain.Inventory CreateOrGetInventory(InventoryRepository inventoryRepository)
        {
            Console.WriteLine("Введите название описи:");
            var title = Console.ReadLine();

            var inventory = inventoryRepository.Find(i => i.Title == title);
            if (inventory == null)
            {
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                inventory = new Inventory(0, title);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                inventoryRepository.Save(inventory);
            }

            return inventory;
        }

        /// <summary>
        /// Создает или получает читальный зал.
        /// </summary>
        /// <param name="readingRoomRepository">Репозиторий читальных залов.</param>
        /// <returns>Читальный зал.</returns>
        private static Domain.ReadingRoom CreateOrGetReadingRoom(ReadingRoomRepository readingRoomRepository)
        {
            Console.WriteLine("Введите название читального зала:");
            var name = Console.ReadLine();

            var readingRoom = readingRoomRepository.Find(r => r.Name == name);
            if (readingRoom == null)
            {
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                readingRoom = new ReadingRoom(0, name);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                readingRoomRepository.Save(readingRoom);
            }

            return readingRoom;
        }

        /// <summary>
        /// Выводит все документы.
        /// </summary>
        /// <param name="documentRepository">Репозиторий документов.</param>
        private static void ReadDocuments(DocumentRepository documentRepository)
        {
            var documents = documentRepository.GetAll();
            foreach (var document in documents)
            {
                Console.WriteLine(document);
            }
        }

        /// <summary>
        /// Обновляет документ.
        /// </summary>
        /// <param name="documentRepository">Репозиторий документов.</param>
        private static void UpdateDocument(DocumentRepository documentRepository)
        {
            Console.WriteLine("Введите ID документа, который вы хотите обновить:");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var document = documentRepository.Get(id);
                if (document != null)
                {
                    Console.WriteLine("Введите новое название документа:");
                    var newTitle = Console.ReadLine();
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                    document.SetName(newTitle);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

                    documentRepository.Save(document);
                    Console.WriteLine("Документ успешно обновлен.");
                }
                else
                {
                    Console.WriteLine("Документ с таким ID не найден.");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
            }
        }

        /// <summary>
        /// Удаляет документ.
        /// </summary>
        /// <param name="documentRepository">Репозиторий документов.</param>
        private static void DeleteDocument(DocumentRepository documentRepository)
        {
            Console.WriteLine("Введите ID документа, который вы хотите удалить:");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var document = documentRepository.Get(id);
                if (document != null)
                {
                    documentRepository.Delete(document);
                    Console.WriteLine("Документ успешно удален.");
                }
                else
                {
                    Console.WriteLine("Документ с таким ID не найден.");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
            }
        }
    }
}