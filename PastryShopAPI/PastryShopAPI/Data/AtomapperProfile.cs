using AutoMapper;
using PastryShopAPI;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Data
{
    public class AtomapperProfile: Profile
    {
        public AtomapperProfile()
        {
            this.CreateMap<ProductModel, ProductEntity>()
                .ForMember(tm => tm.Name, te => te.MapFrom(m => m.Name))
                .ReverseMap();

            /*this.CreateMap<PlayerModel, PlayerEntity>()
                .ForMember(ent => ent.Team, mod => mod.MapFrom(modSrc => new TeamEntity() { Id = modSrc.TeamId }))
                .ReverseMap()
                .ForMember(mod => mod.TeamId, ent => ent.MapFrom(entSrc => entSrc.Team.Id));

            this.CreateMap<TeamWithPlayerModel, TeamEntity>()
                .ReverseMap();*/
        }
    }
}
