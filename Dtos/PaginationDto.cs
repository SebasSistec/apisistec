namespace apisistec.Dtos
{
    public class PaginationDto<T>
    {
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int total { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}
