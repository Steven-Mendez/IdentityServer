﻿namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;

public class GetUserByCriteriaResponse
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Avatar { get; init; } = null!;
    public bool IsBlocked { get; init; }
    public DateTime CreatedAt { get; init; }
}