using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        });

        return Ok(randevuViewModels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RandevuViewModel>> GetRandevu(int id)
    {
        var randevu = await _randevuService.GetRandevuByIdAsync(id);
        if (randevu == null)
        {
            return NotFound();
        }

        var randevuViewModel = new RandevuViewModel
        {
            Id = randevu.Id,
            Isim = randevu.Isim,
            Tarih = randevu.Tarih,
            Not = randevu.Not,
            Doctor = new UserViewmodel.MeViewModel
            {
                UserName = randevu.Doctor.UserName,
                Email = randevu.Doctor.Email
            },
            Hasta = new UserViewmodel.MeViewModel
            {
                UserName = randevu.Hasta.UserName,
                Email = randevu.Hasta.Email
            }
        };

        return Ok(randevuViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<RandevuViewModel>> CreateRandevu(RandevuViewModel randevuViewModel)
    {
        // Create RandevuModel from RandevuViewModel
        var randevu = new RandevuModel
        {
            Isim = randevuViewModel.Isim,
            Tarih = randevuViewModel.Tarih,
            Not = randevuViewModel.Not,
            DoctorID = randevuViewModel.DoctorID,
            HastaID = randevuViewModel.HastaID
        };

        // Call service method to create Randevu
        var createdRandevu = await _randevuService.CreateRandevuAsync(randevu);

        // Create RandevuViewModel from created RandevuModel
        var createdRandevuViewModel = new RandevuViewModel
        {
            Id = createdRandevu.Id,
            Isim = createdRandevu.Isim,
            Tarih = createdRandevu.Tarih,
            Not = createdRandevu.Not,
            Doctor = new UserViewmodel.MeViewModel
            {
                UserName = createdRandevu.Doctor.UserName,
                Email = createdRandevu.Doctor.Email
            },
            Hasta = new UserViewmodel.MeViewModel
            {
                UserName = createdRandevu.Hasta.UserName,
                Email = createdRandevu.Hasta.Email
            }
        };

        return CreatedAtAction(nameof(GetRandevu), new { id = createdRandevuViewModel.Id }, createdRandevuViewModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRandevu(int id, RandevuViewModel randevuViewModel)
    {
        if (id != randevuViewModel.Id)
        {
            return BadRequest();
        }

        // Create RandevuModel from RandevuViewModel
        var randevu = new RandevuModel
        {
            Id = randevuViewModel.Id,
            Isim = randevuViewModel.Isim,
            Tarih = randevuViewModel.Tarih,
            Not = randevuViewModel.Not,
            DoctorID = randevuViewModel.DoctorID,
            HastaID = randevuViewModel.HastaID
        };

        // Call service method to update Randevu
        var updatedRandevu = await _randevuService.UpdateRandevuAsync(randevu);

        if (updatedRandevu == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRandevu(int id)
    {
        var deleted = await _randevuService.DeleteRandevuAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
