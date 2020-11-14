using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TesorosApp.Data
{
    public interface ITesoroService
    {
        Task<List<Tesoros>> GetAllTreasure(Guid Uid);
        Task<Tesoros> GetTreasure(Guid Tid);
        Task<bool> SetTreasure(Tesoros T);
        Task<Coordenadas> GetCoordinate(Guid Tid);
        Task<List<Coordenadas>> GetAllCoordinate(Guid Uid);
    }
    public class ServicesTesoros: ITesoroService
    {
        private readonly ApplicationDbContext db;
        public ServicesTesoros(ApplicationDbContext _dbContext)
        {
            db = _dbContext;
        }

        public Task<List<Coordenadas>> GetAllCoordinate(Guid Uid)
        {
            List<Coordenadas> coordinates = db.Cordenadas
            .Where(c => c.Uid.Equals(Uid)).ToList<Coordenadas>();
            return Task.FromResult(coordinates);
        }
        public async Task<List<Tesoros>> GetAllTreasure(Guid _Uid)
        {
            List<Tesoros> treasures = await db.Tesoro
            .Where(t => t.Uid.Equals(_Uid))
            .ToListAsync<Tesoros>();
            return await Task.FromResult(treasures);
        }
        public Task<Coordenadas> GetCoordinate(Guid Tid)
        {
            Coordenadas coordinate = db.Cordenadas
            .Where(c => c.Tid.Equals(Tid)).FirstOrDefault();
            return Task.FromResult(coordinate);
        }
        public Task<Tesoros> GetTreasure(Guid Tid)
        {
            Tesoros treasure = db.Tesoro
            .Where(t => t.Id.Equals(Tid)).FirstOrDefault();
            return Task.FromResult(treasure);
        }
        public Task<bool> SetTreasure(Tesoros T)
        {
            bool status = false;
            try
            {
                db.Tesoro.Add(T);
                db.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                Console.WriteLine(e.Message);
            }
            return Task.FromResult(status);
        }
    }
}
