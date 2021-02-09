﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JSCodingStudy.EFSqlDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using JSCodingStudy.UserEntities;

    public partial class UsersDbContext : DbContext
    {
        public UsersDbContext()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int Users_Add(string login, string password)
        {
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Users_Add", loginParameter, passwordParameter);
        }
    
        public virtual ObjectResult<User> Users_GetById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("Users_GetById", idParameter);
        }
    
        public virtual ObjectResult<User> Users_GetByLogin(string login)
        {
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("Users_GetByLogin", loginParameter);
        }
    
        public virtual int Users_UpdateLessons(Nullable<int> id, Nullable<int> robot_last_lesson)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var robot_last_lessonParameter = robot_last_lesson.HasValue ?
                new ObjectParameter("robot_last_lesson", robot_last_lesson) :
                new ObjectParameter("robot_last_lesson", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Users_UpdateLessons", idParameter, robot_last_lessonParameter);
        }
    }
}
