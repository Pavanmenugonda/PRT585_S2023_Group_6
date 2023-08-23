using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Functions.Interfaces;

namespace DAL.Functions.Crud
{
    /// <summary>
    /// Generic based CRUD methods, Create, Read, Update, Delete methods.
    /// <para>In region: BASIC EXAMPLE WITHOUT - DI : you will find a very basic set of examples</para>
    /// </summary>
    public class CRUD: ICRUD
    {
        #region CRUD
        /// <summary>
        /// Create a new record of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectForDb"></param>
        /// <returns></returns>
        public async Task<T> Create<T>(T objectForDb) where T : class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<T>(objectForDb);
                    await context.SaveChangesAsync();
                    return objectForDb;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get a record from the database of Type T, by passing the Id(Primary Key) of the object type you want back. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<T> Read<T>(Int64 entityId) where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T result = await context.FindAsync<T>(entityId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all records from the database of Type T. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Generic List Object</returns>
        public async Task<List<T>> ReadAll<T>() where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<T>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update a record in the database of Type T, by passing both updated value and the primary key. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToUpdate"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<T> Update<T>(T objectToUpdate, Int64 entityId) where T : class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<T>(entityId);
                    if (objectFound != null)
                    {
                        context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return objectFound;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete a record of Type T from the database by passing the primary key value of the object you want deleted for the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<bool> Delete<T>(Int64 entityId) where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T recordToDelete = await context.FindAsync<T>(entityId);
                    if (recordToDelete != null)
                    {
                        context.Remove(recordToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        #region BASIC EXAMPLE WITHOUT - DI
        //CRUD crud = new CRUD();
        ////ADD
        //var addItemResult = await crud.Create<Grade>(new Grade
        //{
        //    Grade_Capacity = 11,
        //    Grade_Name = "Grade 7",
        //    Grade_Number = 7,
        //    Grade_ModifiedDate = DateTime.UtcNow
        //});
        ////UPDATE
        //addItemResult.Grade_Name = "Super Grade 7";
        //    var updateResult = await crud.Update<Grade>(addItemResult, addItemResult.Grade_ID);
        ////READ
        //var readResult = await crud.Read<Grade>(5);
        ////READ ALL FOR SPECIFIED ENTITY
        //var readAllResult = await crud.ReadAll<Grade>();
        ////DELETE
        //var deleted = await crud.Delete<Grade>(4);
        #endregion
        #endregion
    }

}

