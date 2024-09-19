
using System.Collections.Generic;
using OT.Assessment.App.Data;
using OT.Assessment.App.Models;

namespace OT.Assessment.App.Reposistory
    {
    public class GameReposistory : IGameReposistory
        {
        private readonly ApplicationDbContext _context;
        public GameReposistory(ApplicationDbContext context)
            {
            _context = context;
            }

        public Task<IList<Game>> GetAllGames( )
            {
                IList <Game> games = _context.Games.ToList();
                return (Task<IList<Game>>)games;
            }

        public Task<Game> GetGameById(string gameId)
            {
            return Task.FromResult(_context.Games.Where(g=>g.Name== gameId).FirstOrDefault());
            }

        public Task<Game> GetGameByName(string gameName)
            {
            return Task.FromResult(_context.Games.Where(g => g.Name == gameName).FirstOrDefault());
            }

        public Task<bool> HasGame(string gameId)
            {
            Game foundGame = _context.Games.Where(g => g.Name == gameId).FirstOrDefault();
            if(foundGame != null)
                return Task.FromResult(false);
            return Task.FromResult(true);
            }

        public Task<bool> AddGame(Game newGame)
            {
            try
                {
                _context.Games.Add(newGame);
                _context.SaveChanges();
                }
            catch (Exception)
                {
                return Task.FromResult(false);
                }
                
            return Task.FromResult(true);
            }
        }
    }
