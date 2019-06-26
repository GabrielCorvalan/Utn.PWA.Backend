using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utn.PWA.DTOs;
using Utn.PWA.Entity.Models;
using Utn.PWA.Repository.Interfaces;

namespace Utn.PWA.Repository.Repositories
{
    public class CareerRepository : BaseRepository, ICareerRepository
    {
        private readonly IMapper _mapper;
        public CareerRepository(IMapper mapper, Utn_SysContext context) : base(context)
        {
            _mapper = mapper;
        }

        public List<CareerDTO> GetAllCareers()
        {
            return ctx.Careers.AsNoTracking()
                                .Select(s =>
                                    _mapper.Map<CareerDTO>(s)
                                ).ToList();
        }

        public CareerDTO GetCareerById(int Id)
        {
            return _mapper.Map<CareerDTO>(ctx.Careers
                                .AsNoTracking()
                                    .Where(s => s.Id.Equals(Id))
                                        .FirstOrDefault());
        }
        public bool Delete(CareerDTO career)
        {
            ctx.Careers.Remove(_mapper.Map<Careers>(career));
            ctx.SaveChanges();
            return true;
        }
        public bool CreateOrUpdate(CareerDTO career)
        {
            var oCareer = ctx.Careers.AsNoTracking()
                            .Where(c => c.Id == career.Id)
                                .FirstOrDefault();

            if (oCareer == null)
            {
                oCareer = new Careers();
                ctx.Careers.Add(oCareer);
            }
            else
            {
                ctx.Careers.Attach(oCareer);
            }
            oCareer.Name = career.Name;
            oCareer.Deleted = false;

            ctx.SaveChanges();
            return true;
        }

    }
}
