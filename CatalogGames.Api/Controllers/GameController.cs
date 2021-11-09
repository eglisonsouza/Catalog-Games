using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CatalogGames.Domain.Arguments.InputModel;
using CatalogGames.Domain.Arguments.ViewModel;
using CatalogGames.Domain.Exceptions;
using CatalogGames.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogGames.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> GetAll([FromQuery, Range(1, int.MaxValue)] int page,
            [FromQuery, Range(1, 50)] int quantity = 5)
        {
            var games = await _gameService.GetAll(page, quantity);
            if (!games.Any())
                return NoContent();

            return Ok(games);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GameViewModel>> Get(Guid id)
        {
            var game = await _gameService.Get(id);
            if (game == null)
                return NoContent();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> Insert(GameInputModel game)
        {
            try
            {
                return Ok(await _gameService.Insert(game));
            }
            catch (GameIsExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Unable to complete request.");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] GameInputModel game)
        {
            try
            {
                await _gameService.Update(id, game);
                return Ok();
            }
            catch (GameIsNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Unable to complete request.");
            }
        }

        [HttpPatch("{id:guid}/{price:double}")]
        public async Task<ActionResult> UpdatePrice([FromRoute] Guid id, [FromRoute] double price)
        {
            try
            {
                await _gameService.Update(id, price);
                return Ok();
            }
            catch (GameIsNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Unable to complete request.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _gameService.Delete(id);
                return Ok();
            }
            catch (GameIsNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Unable to complete request.");
            }
        }
    }
}