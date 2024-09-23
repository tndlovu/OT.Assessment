using Microsoft.AspNetCore.Mvc;

namespace OT.Assessment.App.Controllers
    {

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlayerController : ControllerBase
    {
        private IRabbitMQService _rabbitMQService { get; set; }
        private readonly IPlayerervice _Playerervice;
        private readonly IWagerService _wagerService;

        public PlayerController( IRabbitMQService rabbitMQService,
                                 IPlayerervice Playerervice,
                                 IWagerService wagerService)
            { 

            this._rabbitMQService = rabbitMQService;
            this._Playerervice=Playerervice;
            this._wagerService = wagerService;
            }

        //POST api/player/casinowager
        [HttpPost]
        public async Task<ActionResult> CasinoWager(WagerEventModel request)
            {
            Console.WriteLine("Received the following message: " + request);
            var result=await _rabbitMQService.PublishWagerEventToRabbitMq(request);
            return Ok(result);
            }


        //GET api/player/{playerId}/wagers
        [HttpGet("/api/[controller]/{playerId}/[action]")]
        public async Task<ActionResult> casino( string playerId )
            {
            PlayerGameModel returnValue= new PlayerGameModel();
            var result= await _wagerService.GetWagersForPlayer(playerId);
            var total = result.Sum(wa => decimal.Parse(wa.Amount));
            returnValue.Wagers = result;
            returnValue.Page= 1;
            returnValue.TotalPages=result.Count();
            returnValue.Total=total;
            return Ok(returnValue);
            }

        //GET api/player/topSpenders?count=10        
        [HttpGet("/api/[controller]/[action]")]
        public async Task<ActionResult> topSpenders(int count)
            {
            var results = await _wagerService.GetTopSpenders(count);
            return Ok(results.OrderBy(od=>od.TotalAmountSpend));
            }
        }
}
