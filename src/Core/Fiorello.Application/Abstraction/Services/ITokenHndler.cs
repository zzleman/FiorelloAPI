using Fiorello.Application.DTOs.ResponseDTOs;
using Fiorello.Domain.Entities;

namespace Fiorello.Application.Abstraction.Services;

public interface ITokenHndler
{
    public Task<TokenResponseDto> CreateAccessToken(int minutes,AppUser user);
}
