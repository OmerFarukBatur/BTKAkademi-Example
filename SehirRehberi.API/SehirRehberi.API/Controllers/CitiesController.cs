using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
       
        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }


        [HttpGet(Name = "cities")]
        public IActionResult GetCities()
        {
            var cities = _appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);
        }


        [HttpPost(Name ="add")]
        public ActionResult Add([FromBody] City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }


        
        [HttpGet(Name = "detail/{id}")]
        public ActionResult GetCityById(int id)
        {
            
            var city = _appRepository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityToReturn);
        }


        [HttpGet(Name = "photos/{id}")]
        public ActionResult GetPhotosByCity(int cityId)
        {

            var photos = _appRepository.GetPhotosByCity(cityId);
            return Ok(photos);
        }

    }
}
