﻿using IdentityServer.Application.Authentiacion.Interfaces;
using IdentityServer.Application.Authentiacion.UseCase.Authenticate;
using IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Requests;

namespace IdentityServer.Application.Authentiacion.Services;

public class AuthenticationService(AuthenticateUseCase authenticateUseCase) : IAuthenticationService
{
    private readonly AuthenticateUseCase _authenticateUseCase = authenticateUseCase;

    public async Task<bool> Authenticate(AuthenticateRequest request)
    {
        var result = await _authenticateUseCase.ExecuteAsync(request);
        return result;
    }
}
