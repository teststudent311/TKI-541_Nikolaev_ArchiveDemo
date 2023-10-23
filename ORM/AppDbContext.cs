// <copyright file="AppDbContext.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

using Domain;
using Microsoft.EntityFrameworkCore;
using ORM.Mappings;

/// <summary>
/// Контекст базы данных для работы с Entity Framework Core.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Получает или задает набор документов в базе данных.
    /// </summary>
    public DbSet<Document> Documents { get; set; }

    /// <summary>
    /// Получает или задает набор описей в базе данных.
    /// </summary>
    public DbSet<Inventory> Inventories { get; set; }

    /// <summary>
    /// Получает или задает набор читальных залов в базе данных.
    /// </summary>
    public DbSet<ReadingRoom> ReadingRooms { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="AppDbContext"/>.
    /// </summary>
    /// <param name="options">Параметры конфигурации контекста.</param>
#pragma warning disable SA1201 // Elements should appear in the correct order
    public AppDbContext(DbContextOptions<AppDbContext> options)
#pragma warning restore SA1201 // Elements should appear in the correct order
        : base(options)
    {
    }

    /// <summary>
    /// Настроить модель данных, которая будет использоваться для создания базы данных.
    /// </summary>
    /// <param name="modelBuilder">Строитель модели для конфигурации сущностей.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Применить конфигурации маппинга для каждой сущности
        modelBuilder.ApplyConfiguration(new DocumentMap());
        modelBuilder.ApplyConfiguration(new InventoryMap());
        modelBuilder.ApplyConfiguration(new ReadingRoomMap());
    }
}