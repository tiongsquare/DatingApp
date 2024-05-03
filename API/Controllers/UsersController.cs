using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users will go controller below
public class UsersController : ControllerBase
{
    private readonly DataContext _context;
public UsersController(DataContext context)
{
    _context = context;
}

[HttpGet]
public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() //IEmumerable is a list
{
    var users = await _context.Users.ToListAsync();

    return users;
}

[HttpGet("{id}")] // /api/users/2
public async Task<ActionResult<AppUser>> GetUsers(int id)
{
     return await _context.Users.FindAsync(id);

}
}
