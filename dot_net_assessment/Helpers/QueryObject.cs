namespace dot_net_assessment.Helpers
{
    public class QueryObject
    {
        public bool? Dispatched { get; set; } = null;
        public bool? Faulty { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
