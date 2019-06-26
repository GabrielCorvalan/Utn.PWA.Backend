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
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        private readonly IMapper _mapper;
        public CompanyRepository(IMapper mapper, Utn_SysContext context) : base(context)
        {
            _mapper = mapper;
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            return ctx.Companies.AsNoTracking()
                                .Select(s =>
                                    _mapper.Map<CompanyDTO>(s)
                                ).ToList();
        }

        public CompanyDTO GetCompanyById(int Id)
        {
            return _mapper.Map<CompanyDTO>(ctx.Companies
                                .AsNoTracking()
                                    .Where(s => s.Id.Equals(Id))
                                        .FirstOrDefault());
        }
        public bool Delete(CompanyDTO company)
        {
            ctx.Companies.Remove(_mapper.Map<Companies>(company));
            ctx.SaveChanges();
            return true;
        }
        public bool CreateOrUpdate(CompanyDTO company)
        {
            var oCompany = ctx.Companies.AsNoTracking()
                            .Where(c => c.Id == company.Id)
                                .FirstOrDefault();

            if (oCompany == null)
            {
                oCompany = new Companies();
                ctx.Companies.Add(oCompany);
            }
            else
            {
                ctx.Companies.Attach(oCompany);
            }
            oCompany.Address = company.Address;
            oCompany.Cuit = company.Cuit;
            oCompany.Email = company.Email;
            oCompany.Name = company.Name;
            oCompany.Deleted = false;

            ctx.SaveChanges();
            return true;
        }

    }
}
