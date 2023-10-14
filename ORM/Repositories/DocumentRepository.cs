// <copyright file="DocumentRepository.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    /// <summary>
    /// Репозиторий для управления сущностями <see cref="Document"/>.
    /// </summary>
    public class DocumentRepository : IRepository<Document>
    {
        private readonly ISession session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DocumentRepository"/>.
        /// </summary>
        /// <param name="session">Сессия NHibernate.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, когда сессия равна null.</exception>
        public DocumentRepository(ISession session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
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

            this.session.Delete(entity);
            this.session.Flush();
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
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        public Document Find(Expression<Func<Document, bool>> predicate) =>
#pragma warning disable SA1101 // Prefix local calls with this
            GetAll().FirstOrDefault(predicate);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Получает документ по ID.
        /// </summary>
        /// <param name="id">ID документа.</param>
        /// <returns>Документ с указанным ID.</returns>
        public Document Get(int id)
        {
            return this.session.Get<Document>(id);
        }

        /// <summary>
        /// Получает все документы.
        /// </summary>
        /// <returns>Все документы.</returns>
        public IQueryable<Document> GetAll()
        {
            return this.session.Query<Document>();
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

            this.session.Save(entity);
            this.session.Flush();
            return true;
        }
    }
}
