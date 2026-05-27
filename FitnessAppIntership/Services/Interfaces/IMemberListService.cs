using FitnessAppIntership.Data.Entities;
using NuGet.Protocol.Core.Types;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface IMemberListService
    {
        int EntitiesPerPage { get; set; }
        FilterType FilterType { get; set; }
        string FilterToken { get; set; }
        int Page { get; set; }
        ICollection<MemberEntity> ListAllMembers();
    }
}
