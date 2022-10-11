using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

public class GebruikerLogin
{
    public string? UserName { get; init; }
    public string? Password { get; init; }
}

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<Gebruiker> _userManager;
    private readonly SignInManager<Gebruiker> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<Gebruiker> userManager, SignInManager<Gebruiker> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    [HttpPost]
    [Route("registreer_Gast")]
    public async Task<ActionResult<IEnumerable<Attractie>>> RegistreerGast([FromBody] Gebruiker gebruikerMetWachwoord)
    {
        var resultaat1 = await _userManager.CreateAsync(gebruikerMetWachwoord, gebruikerMetWachwoord.Password);
        if(!resultaat1.Succeeded)
        {
            return new BadRequestObjectResult(resultaat1);
        }
        else
        {
            var roleToAdd = _roleManager.FindByNameAsync("Gast").Result;
            if(roleToAdd != null)
            {
                var resultaat2 = await _userManager.AddToRoleAsync(gebruikerMetWachwoord, roleToAdd.Name);

                return !resultaat2.Succeeded ? new BadRequestObjectResult(resultaat2) : StatusCode(201);
            }
            else
            {
                return StatusCode(403);
            }
        }
    }

    [HttpPost]
    [Route("registreer_Medewerker")]
    public async Task<ActionResult<IEnumerable<Attractie>>> RegistreerMedewerker([FromBody] Gebruiker gebruikerMetWachwoord)
    {
        var resultaat1 = await _userManager.CreateAsync(gebruikerMetWachwoord, gebruikerMetWachwoord.Password);

        if(!resultaat1.Succeeded)
        {
            return new BadRequestObjectResult(resultaat1);
        }
        else
        {
            var roleToAdd = _roleManager.FindByNameAsync("Medewerker").Result;
            if(roleToAdd != null)
            {
                var resultaat2 = await _userManager.AddToRoleAsync(gebruikerMetWachwoord, roleToAdd.Name);

                return !resultaat2.Succeeded ? new BadRequestObjectResult(resultaat2) : StatusCode(201);
            }
            else
            {
                return StatusCode(403);
            }
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] GebruikerLogin gebruikerLogin)
    {
        var _user = await _userManager.FindByNameAsync(gebruikerLogin.UserName);
        if (_user != null)
            if (await _userManager.CheckPasswordAsync(_user, gebruikerLogin.Password))
            {
                Console.WriteLine("Oegaboega: " + await _userManager.FindByNameAsync(gebruikerLogin.UserName));
                var secret = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("awef98awef978haweof8g7aw789efhh789awef8h9awh89efh89awe98f89uawef9j8aw89hefawef"));

                var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, _user.UserName) };
                var roles = await _userManager.GetRolesAsync(_user);
                foreach (var role in roles)
                    claims.Add(new Claim(ClaimTypes.Role, role));
                var tokenOptions = new JwtSecurityToken
                (
                    issuer: "https://localhost:7131",
                    audience: "https://localhost:7131",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signingCredentials
                );
                
                return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions) });
            }

        return Unauthorized();
    }

    [Authorize(Roles = "Medewerker")]
    [HttpPost]
    [Route("addRole")]
    public async Task<ActionResult<IEnumerable<Attractie>>> AddRole([FromBody] IdentityRole role)
    {
        var existingRole = _roleManager.FindByNameAsync(role.Name).Result;

        if(existingRole == null)
        {
            var resultaat = await _roleManager.CreateAsync(role);
            return !resultaat.Succeeded ? new BadRequestObjectResult(resultaat) : StatusCode(201);
        }
        return StatusCode(403);
       
    }

    
}