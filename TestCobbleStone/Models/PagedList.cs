namespace TestCobbleStone.Models
{
    public class PagedList<TModel>
    {
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public List<TModel> Items { get; set; }
    }
}
