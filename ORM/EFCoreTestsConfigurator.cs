// <copyright file="EFCoreTestsConfigurator.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Конфигуратор для создания контекста базы данных для тестов с использованием EF Core.
/// </summary>
public class EFCoreTestsConfigurator
{
    /// <summary>
    /// Создает и конфигурирует контекст базы данных для тестов.
    /// </summary>
    /// <returns>Контекст базы данных для тестов.</returns>
    public static AppDbContext BuildContextForTest()
    {
        // Создание опций для контекста базы данных
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql("Host=localhost;Username=postgres;Password=;Database=testbd1;")
            .Options;

        // Создание и конфигурация контекста базы данных
        var context = new AppDbContext(options);
        context.Database.EnsureCreated();

        return context;
    }
}