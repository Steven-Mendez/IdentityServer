﻿namespace IdentityServer.Application.Users.UseCases.GetUserByEmail.DataTransferObjects;

public class GetUserByEmailResponse
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Avatar { get; init; } = null!;
    public bool IsBlocked { get; init; }
}