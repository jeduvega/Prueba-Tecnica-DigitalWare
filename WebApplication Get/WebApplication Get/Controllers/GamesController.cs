using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_Get.Data;
using WebApplication_Get.Models;

namespace WebApplication_Get.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly WebApplication_GetContext _context;

        public GamesController(WebApplication_GetContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Games>>> GetGames(int id)
        {

            List<Games> listGames = new List<Games>();


            for (int i = 1; listGames.Count < id; i++)
            {
                if (GamesExists(i))
                {
                    var games = await _context.Games.FindAsync(i);
                    listGames.Add(games);
                }


            }

            return listGames;
        }


        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
