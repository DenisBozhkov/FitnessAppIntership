using FitnessAppIntership.Data.Entities;
using System.ComponentModel;

namespace FitnessAppIntership.Models
{
    public class MemberViewModel : MemberEntity
    {
        public List<VisitEntity> Visits { get; set; }
        [DisplayName("Start Date: ")]
        public DateTime? StartDate { get; set; } = null;
        [DisplayName("End Date: ")]
        public DateTime? EndDate { get; set; } = null;
    }
}
