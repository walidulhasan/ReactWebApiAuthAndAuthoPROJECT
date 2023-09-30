﻿using Backend_WebApi.Core.Dtos.Auth;
using Backend_WebApi.Core.Dtos.General;
using System.Security.Claims;

namespace Backend_WebApi.Core.Interfaces;

public interface IAuthService
{
    Task<GeneralServiceResponseDto> SeedRolesAsync();
    Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto);
    Task<LoginServiceResponseDto?> LoginAsync(LoginDto loginDto);
    Task<GeneralServiceResponseDto> UpdateRoleAsync(ClaimsPrincipal User,UpdateRoleDto updateRoleDto);
    Task<LoginServiceResponseDto?> MeAsync(MeDto meDto);
    Task<IEnumerable<UserInfoResult>> GetUsersListAsync();
    Task<UserInfoResult?> GetUserDetailsByUserNameAsync(string userName);
    Task<IEnumerable<string>> GetUserNamesListAsync(CancellationToken cancellationToken=default);

}
