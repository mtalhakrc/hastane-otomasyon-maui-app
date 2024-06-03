using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Services;
using web_api.ViewModels;
namespace web_api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RandevuController : Controller
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
                ID = r.Doctor.Id,
                UserName = r.Doctor.UserName,
                Email = r.Doctor.Email
            },
            Hasta = new UserViewmodel.MeViewModel
            {
                ID = r.Doctor.Id,
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

    public async Task<IActionResult> Create([FromBody]RandevuViewModel model)
    {
        await _randevuService.CreateRandevuAsync(new RandevuModel()
        {
            Isim = model.Isim,
            DoctorID = model.DoctorID,
            HastaID = model.HastaID,
            Tarih = model.Tarih,
            Not = model.Not
        });
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> RandevuUpdate(int id, [FromBody] RandevuViewModel model)
    {
        await _randevuService.UpdateRandevuAsync(new RandevuModel()
        {
            Id = model.Id,
            Isim = model.Isim,
            DoctorID = model.DoctorID,
            HastaID = model.HastaID,
            Tarih = model.Tarih,
            Not = model.Not
        });
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRandevu(int id)
    {
        await _randevuService.DeleteRandevuAsync(id);
        return Ok();
    }
}
