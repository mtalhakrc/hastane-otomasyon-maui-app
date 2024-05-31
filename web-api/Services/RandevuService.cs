using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;

namespace web_api.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRandevuService
{
    Task<Randevu.RandevuModel> GetRandevuAsync(int id);
    Task<IEnumerable<Randevu.RandevuModel>> GetAllRandevularAsync();
    Task<Randevu.RandevuModel> CreateRandevuAsync(Randevu.RandevuModel model);
    Task<Randevu.RandevuModel> UpdateRandevuAsync(int id, Randevu.RandevuModel model);
    Task<bool> DeleteRandevuAsync(int id);
}



public class RandevuService : IRandevuService
{
    private readonly AppDbContext _context;

    public RandevuService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Randevu.RandevuModel> GetRandevuAsync(int id)
    {
        return await _context.Randevular.FindAsync(id);
    }

    public async Task<IEnumerable<Randevu.RandevuModel>> GetAllRandevularAsync()
    {
        return await _context.Randevular.ToListAsync();
    }

    public async Task<Randevu.RandevuModel> CreateRandevuAsync(Randevu.RandevuModel model)
    {
        model.CreatedAt = DateTime.UtcNow;
        _context.Randevular.Add(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Randevu.RandevuModel> UpdateRandevuAsync(int id, Randevu.RandevuModel model)
    {
        var randevu = await _context.Randevular.FindAsync(id);
        if (randevu == null)
        {
            return null;
        }

        randevu.Isim = model.Isim;
        randevu.DoctorID = model.DoctorID;
        randevu.HastaID = model.HastaID;
        randevu.Tarih = model.Tarih;
        randevu.Not = model.Not;
        randevu.UpdatedAt = DateTime.UtcNow;

        _context.Randevular.Update(randevu);
        await _context.SaveChangesAsync();

        return randevu;
    }

    public async Task<bool> DeleteRandevuAsync(int id)
    {
        var randevu = await _context.Randevular.FindAsync(id);
        if (randevu == null)
        {
            return false;
        }

        _context.Randevular.Remove(randevu);
        await _context.SaveChangesAsync();

        return true;
    }
}