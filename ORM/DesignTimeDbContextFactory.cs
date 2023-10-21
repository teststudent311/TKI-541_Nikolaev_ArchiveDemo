// <copyright file="DesignTimeDbContextFactory.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ORM;

/// <summary>
/// Фабрика для создания контекста данных во время дизайна.
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    /// <summary>
    /// Создает экземпляр контекста данных.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    /// <returns>Возвращает экземпляр контекста данных.</returns>
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = "Host=localhost;Username=postgres;Password=;Database=testbd1;";
        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}