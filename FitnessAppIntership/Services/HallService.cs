using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Services.Interfaces;

namespace FitnessAppIntership.Services
{
    public class HallService : IHallService
    {
        private readonly ApplicationDbContext _context;
        public HallService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateHall(HallEntity entity)
        {
            _context.Halls.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteHall(Guid id)
        {
            if(ExistsHall(id))
            {
                _context.Halls.Remove(GetHall(id));
                _context.SaveChanges();
            }
        }

        public void EditHall(Guid id, HallEntity entity)
        {
            if(ExistsHall(id))
            {
                HallEntity dbHall = GetHall(id);
                _context.Halls.Entry(dbHall).CurrentValues.SetValues(entity);
                _context.Halls.Update(dbHall);
                _context.SaveChanges();
            }
        }

        public bool ExistsHall(Guid id)
        {
            return _context.Halls.Any(entity => entity.Id == id);
        }

        public HallEntity GetHall(Guid id)
        {
            return _context.Halls.Find(id);
        }

        public ICollection<HallEntity> ListAllHalls()
        {
            return _context.Halls.ToList();
        }
    }
}
