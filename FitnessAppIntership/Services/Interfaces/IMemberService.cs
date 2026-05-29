using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface IMemberService
    {
        void RegisterMember(MemberEntity member);
        void EditMember(Guid id, MemberEntity member);
        MemberEntity GetMember(Guid id);
        void ActivateMember(Guid id);
        void DeactivateMember(Guid id);
        bool HasMemberActiveSubscription(Guid memberId);
        bool ExistsMember(Guid id);
    }
}
