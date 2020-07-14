using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnockoutTSPrototype.Data.Entities;
using KnockoutTSPrototype.Dto;

namespace KnockoutTSPrototype.Services
{
    public class PartnerProcessor : GenericHandler
    {
        public void PartnerHandle(HttpContext context)
        {
            PartnerSearchDto dto;
            if (!PartnerSearchDto.GetFromContext(context, out dto))
            {
                return;
            }

            // Create dummy data
            Partner p1 = new Partner();
            p1.Name = "John Doe";
            p1.City = "Praha";
            Partner p2 = new Partner();
            p2.Name = "Jane Doe";
            p2.City = "Brno";
            List<Partner> ps = new List<Partner>();
            ps.Add(p1);
            ps.Add(p2);
            // Create dummy data

            // Some filters
            //var resultWhere = ps.Where(x => x.Name.Contains(dto.Name));
            //var result = resultWhere.ToList();
                

            WriteSuccessResponse(context, "", ps);
        }
    }
}