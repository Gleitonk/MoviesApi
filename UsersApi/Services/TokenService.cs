using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UsersApi.Models;

namespace UsersApi.Services;

public class TokenService
{

    public Token CreateToken(IdentityUser<Guid> user)
    {
        var userRights = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAK+w9wITqYP+0UiZ07v/Dp6sWOCBLicqavtdZec1rD3sXeQv5LSauWiM9SJhH83HErvbkJSNNuPvTW6b4+mCKM2t+79Yu2J/zyCI0Nx+zRec29PpD9qxxm5HU1BlhWsFvTrqVhLq1S615f7BysJjj1mx9CdyHP07md8hQjIl9bIRAgMBAAECgYBS+Sl+spiBPQvL1NI5W/ikmVKUHI4WcyL5OZ/RtPh2ejXReYjyfowHw2JV7Tae8WB4lfZPIe4FcdPI5BicBBuOVnUeh0ZpqXQG4S5mF8t5gRMtdGfJKvopuTidAQoRgT7N/zJHRzzYntWqCZlF9tZjPd7+k8xHV+KVoEWBNLKiAQJBAOgdxtX2yYxjkL4PvvvhSE4zJNknqfbpeY7CqSDLdPjEk7Ap0MPd8yGBRhRqYd4vZgo1ad/MdVc2BnZB4/HyTSECQQDBxOJuj+LSThr8OuF2GrzdyQtfGeUok7etQXBXu55/gekoDotnyR9PwdbD9l6VqoHVf8Km2EAyUj/aA2UaslbxAkEAmxNxyXeU1kea53BLr6qmjSBcSPzX8A+yV++z4SYtIxrqdPKq+IErs8HTmUYt1qyiJsXi01OdPcPpc064ROgWIQJAJ7UnCa0muB4VXZbbWQ6FoZVvZR+zXCtZOoHsea4S/uIqW3EPlEccyYVZc3LrUxRL4up5gyNRlH5SY2TKtTvSoQJAa3xVbp8MXKIpKiNo4ICy7iGtjlwFyswmuMF5lXXUVoTr9t2Rc/WiMopj40xmZc7EqgTj2hNAB+tResVUzX9t+Q=="));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: userRights,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddHours(1));

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new Token(tokenString);
    }
}
