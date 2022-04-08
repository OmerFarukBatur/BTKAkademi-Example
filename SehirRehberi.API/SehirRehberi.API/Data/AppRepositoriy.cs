using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class AppRepositoriy : IAppRepository
    {
        private DataContext _context;

        public AppRepositoriy(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity)
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            _context.Update(entity);
        }

        public List<City> GetCities()
        {
            var cities = _context.Cities.Include(c => c.Photos).ToList();
            return cities;
        }

        public City GetCityById(int id)
        {
            var city = _context.Cities.Include(c => c.Photos).FirstOrDefault(c => c.Id == id);
            return city;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            return photo;
        }

        public List<Photo> GetPhotosByCity(int id)
        {
            var photos = _context.Photos.Where(p => p.CityId == id).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges()>0;
        }

        public void Update<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
