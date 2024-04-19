namespace SimpleAuthNet.Models.Dto.Response;

public record LoginResponseModel(string AccessToken, string RefreshToken, int ExpiresIn);