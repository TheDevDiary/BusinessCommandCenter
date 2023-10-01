using System;
/* This namespac provides functionality for querying collections and performing 
 * various operations using Language Integrated Query) sintax. 
 * Is part of the .Net Framework and .NetCore Libraries :)
*/
using System.Linq;
/*
 * This namespace allows access types and classes that also are part of
 * .Net Framework and .NetCore Libraries
 */
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    // This is the name of the class that will be interacting with the database context
    public class UserRepository : IUserRepository
    {
        /*
         * This will be used to hold an instance of the database context through whih 
         * databese operations will be performed.
         */

        private readonly AppDbContext _dbContext;
        /*
         * This is the constructor of 'UserRepository' class. It takes a parameter of 
         * type 'AppDbContext', which is a database contet. The context is injectex into
         * the repository to work with database.         
         */
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*
        * This method takes an 'int' parameter 'userId' and returns a 'User' object.
        * It uses the '_dbContext to query the 'User' table and retrieve the first user 
        * with specified 'Id' usinf the 'FirstOrDefault' LINQ method.
        */
        public User GetUserById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username);
        }

        /*
         * This method takes 'UserRole' parameter 'role' and return a list of 'User' Object
         * The result is converted to a list using ToList.
         */
        public List<User> GetUserByRole(UserRole role)
        {
            return _dbContext.Users.Where(u => u.Role == role).ToList();
        }

        /*
         * Add, Update and Delete are the basic methods part of a CRUD (Create, Read, Update and Delete) System.
         */
        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            if(user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}
