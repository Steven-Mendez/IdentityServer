﻿namespace IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;

public class UpdateUserRequest
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}