﻿namespace IdentityServer.Application.Authentiacion.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string passwordHash);
}
