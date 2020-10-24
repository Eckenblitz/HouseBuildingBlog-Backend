namespace HouseBuildingBlog.Api.Costplan.Commands.Contracts
{
    public class CostplanItemCommandDto
    {
        public string Name { get; set; }

        public decimal EstimatedCost { get; set; }

        public int Number { get; set; }
    }
}
