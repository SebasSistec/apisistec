namespace apisistec.Entities
{
    public class PlanHeaderXDetail
    {
        public int Order { get; set; }

        //FK Plan Header
        public Guid PlanHeaderId { get; set; }
        public PlanHeader Header { get; set; }

        //FK Plan Detail
        public Guid PlanDetailId { get; set; }
        public PlanDetail Detail { get; set; }
    }
}