using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SmartEvent.Core.DTO;
using SmartEvent.Core.Models;

namespace SmartEvent.Services
{
    public class AuthService
    {
        private readonly UserManager<UserAuth> _userManager;
        private readonly IConfiguration _configuration;
        private readonly UserService _userService;
        private readonly OrganisationService _organisationService;

        public AuthService(UserManager<UserAuth> userManager, IConfiguration configuration, UserService userService, OrganisationService organisationService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _userService = userService;
            _organisationService = organisationService;
        }

        public async Task<AuthModel> UserRegisterAsync(UserRegisterModel userRegisterModel)
        {
            if (await _userManager.FindByEmailAsync(userRegisterModel.Email) is not null)
                return new AuthModel { Message = "Email is already registred !" };
            if (await _userManager.FindByNameAsync(userRegisterModel.Email) is not null)
                return new AuthModel { Message = "Username is already registred !" };



            var userAuth = new UserAuth
            {
                Id = Guid.NewGuid(),
                Email = userRegisterModel.Email,
                UserName = userRegisterModel.Email,
            };

            var result = await _userManager.CreateAsync(userAuth, userRegisterModel.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                    Console.WriteLine(error.Description);
                }
                return new AuthModel { Message = errors };
            }


            var user = new User
            {
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                AuthId = userAuth.Id
            };

            var user1 = await _userService.CreateUserAsync(user);


            await _userManager.AddToRoleAsync(userAuth, "User");

            var jwtSecurityToken = await CreateJwtToken(userAuth, user1.Id);

            return new AuthModel
            {
                Email = userAuth.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            };
        }

        public async Task<AuthModel> OrganisationRegisterAsync(OrganisationRegisterModel organisationRegisterModel)
        {
            if (await _userManager.FindByEmailAsync(organisationRegisterModel.Email) is not null)
                return new AuthModel { Message = "Email is already registred !" };
            if (await _userManager.FindByNameAsync(organisationRegisterModel.Email) is not null)
                return new AuthModel { Message = "Username is already registred !" };



            var userAuth = new UserAuth
            {
                Id = Guid.NewGuid(),
                Email = organisationRegisterModel.Email,
                UserName = organisationRegisterModel.Email,

            };

            var result = await _userManager.CreateAsync(userAuth, organisationRegisterModel.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthModel { Message = errors };
            }

            var organisation = new Organisation
            {
                Nom = organisationRegisterModel.Nom,
                AuthId = userAuth.Id
            };

            var organisation1 = await _organisationService.CreateOrganisationAsync(organisation);


            await _userManager.AddToRoleAsync(userAuth, "Organisation");

            var jwtSecurityToken = await CreateJwtToken(userAuth, organisation1.Id);

            return new AuthModel
            {
                Email = userAuth.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Organisation" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            };
        }

        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var user1 = await _userService.GetUserByAuthIdAsync(user.Id);

            var jwtSecurityToken = await CreateJwtToken(user, user1.Id);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email!;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();



            return authModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(UserAuth user, Guid id)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("uid", id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(double.Parse(_configuration["Jwt:DurationInDays"]!)),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}