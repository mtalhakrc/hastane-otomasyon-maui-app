using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;
using web_api.Services;
using web_api.ViewModels;

[Route("api/[controller]")]
[ApiController]
public class RandevuController : ControllerBase
{
    private readonly IRandevuService _randevuService;

    public RandevuController(IRandevuService randevuService)
    {
        _randevuService = randevuService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RandevuViewModel>>> GetAllRandevular()
    {
        var randevular = await _randevuService.GetAllRandevularAsync();

        var randevuViewModels = randevular.Select(r => new RandevuViewModel
        {
            Id = r.Id,
            Isim = r.Isim,
            Tarih = r.Tarih,
            Not = r.Not,
            Doctor = new UserViewmodel.MeViewModel
            {
                UserName = r.Doctor.UserName,
                Email = r.Doctor.Email
            },
            Hasta = new UserViewmodel.MeViewModel
            {
                UserName = r.Hasta.UserName,
                Email = r.Hasta.Email
            }
        }).ToList();

        return Ok(randevuViewModels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RandevuViewModel>> GetRandevu(int id)
    {
        Console.WriteLine("burada");
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<RandevuViewModel>> CreateRandevu(RandevuViewModel randevuViewModel)
    {
        Console.WriteLine("burada");
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRandevu(int id)
    {
        Console.WriteLine("burada");
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRandevu(int id)
    {
        Console.WriteLine("burada");
        return Ok();
    }
}
