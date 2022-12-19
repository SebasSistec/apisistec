using apisistec.Constants;

namespace apisistec.Models.Parameters
{
    public class QueryParams
    {
        public string? search { get; set; }
        public int page { get; set; } = 1;
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > PagingConstants.MAX_PAGE_SIZE) ? PagingConstants.MAX_PAGE_SIZE : value;
            }
        }

        public string orderBy { get; set; } = "asc";
    }
}
