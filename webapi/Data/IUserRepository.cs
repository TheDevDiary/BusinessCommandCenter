using System;
using System.Collections.Generic;
using webapi.Models;

public interface IUserRepository
{
    User GetUserById(int userId);
    User GetUserByUsername(string username);
    List<User> GetUserByRole(UserRole role);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
