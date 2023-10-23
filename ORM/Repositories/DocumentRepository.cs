// <copyright file="DocumentRepository.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;

    /// <summary>
    /// Репозиторий для управления сущностями <see cref="Document"/>.
    /// </summary>
    public class DocumentRepository : IRepository<Document>
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DocumentRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, когда контекст равен null.</exception>
        public DocumentRepository(AppDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Удаляет документ из базы данных.
        /// </summary>
        /// <param name="entity">Документ, который необходимо удалить.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если переданный документ равен null.</exception>
        public void Delete(Document entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.context.Documents.Remove(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Фильтрует документы на основе предиката.
        /// </summary>
        /// <param name="predicate">Предикат для фильтрации.</param>
        /// <returns>Отфильтрованные документы.</returns>
        public IQueryable<Document> Filter(Expression<Func<Document, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <summary>
        /// Находит документ на основе предиката.
        /// </summary>
        /// <param name="predicate">Предикат для поиска.</param>
        /// <returns>Найденный документ.</returns>
        public Document Find(Expression<Func<Document, bool>> predicate)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return this.GetAll().FirstOrDefault(predicate);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        /// <summary>
        /// Получает документ по ID.
        /// </summary>
        /// <param name="id">ID документа.</param>
        /// <returns>Документ с указанным ID.</returns>
        public Document Get(int id)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return this.context.Documents.Find(id);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        /// <summary>
        /// Получает все документы.
        /// </summary>
        /// <returns>Все документы.</returns>
        public IQueryable<Document> GetAll()
        {
            return this.context.Documents;
        }

        /// <summary>
        /// Сохраняет документ.
        /// </summary>
        /// <param name="entity">Документ для сохранения.</param>
        /// <returns>True, если документ был успешно сохранен; в противном случае, false.</returns>
        public bool Save(Document entity)
        {
            if (entity == null)
            {
                return false;
            }

            this.context.Documents.Add(entity);
            this.context.SaveChanges();
            return true;
        }
    }
}