using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace web_api.Services;
public interface IRandevuService
{
    Task<RandevuModel> GetRandevuByIdAsync(int id);
    Task<IEnumerable<RandevuModel>> GetAllRandevularAsync();
    Task<RandevuModel> CreateRandevuAsync(RandevuModel randevu);
    Task<RandevuModel> UpdateRandevuAsync(RandevuModel randevu);
    Task<bool> DeleteRandevuAsync(int id);
}

public class RandevuService : IRandevuService
{
    private readonly AppDbContext _context;

    public RandevuService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RandevuModel> GetRandevuByIdAsync(int id)
    {
        return await _context.Randevular
                             .Include(r => r.Doctor)
                             .Include(r => r.Hasta)
                             .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<RandevuModel>> GetAllRandevularAsync()
    {
        return await _context.Randevular
                             .Include(r => r.Doctor)
                             .Include(r => r.Hasta)
                             .ToListAsync();
    }

    public async Task<RandevuModel> CreateRandevuAsync(RandevuModel randevu)
    {
        randevu.CreatedAt = DateTime.UtcNow;
        _context.Randevular.Add(randevu);
        await _context.SaveChangesAsync();
        return randevu;
    }

    public async Task<RandevuModel> UpdateRandevuAsync(RandevuModel randevu)
    {
        var existingRandevu = await _context.Randevular.FindAsync(randevu.Id);
        if (existingRandevu == null)
        {
            return null;
        }

        existingRandevu.Isim = randevu.Isim;
        existingRandevu.DoctorID = randevu.DoctorID;
        existingRandevu.HastaID = randevu.HastaID;
        existingRandevu.Tarih = randevu.Tarih;
        existingRandevu.Not = randevu.Not;
        existingRandevu.UpdatedAt = DateTime.UtcNow;

        _context.Randevular.Update(existingRandevu);
        await _context.SaveChangesAsync();

        return existingRandevu;
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