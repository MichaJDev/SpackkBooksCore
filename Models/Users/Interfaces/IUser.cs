﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Users.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Uid { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}
