namespace ApiCatalogo.Pagination
{
    public abstract class QueryStringParameters
    {
        const int _maxLengthPage = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > _maxLengthPage) ? _maxLengthPage : value;
            }
        }
    }
}
