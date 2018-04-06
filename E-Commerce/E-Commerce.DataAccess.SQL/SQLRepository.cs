﻿using E_Commerce.Core.Contracts;
using E_Commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.SQL {
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity {

        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext context) {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> Collection() {
            return dbSet;
        }

        public void Commit() {
            context.SaveChanges();
        }

        public void Delete(string Id) {
           var item = Find(Id);
            if (context.Entry(item).State == EntityState.Detached) {
                dbSet.Attach(item);
            }
            dbSet.Remove(item);
        }

        public T Find(string Id) {
            return dbSet.Find(Id);
        }

        public void Insert(T item) {
            dbSet.Add(item);
        }

        public void Update(T item) {
            dbSet.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
