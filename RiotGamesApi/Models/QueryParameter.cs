namespace RiotGamesApi.Models
{
    public class QueryParameter
    {
        public string Key { get; }
        public object Value { get; }

        public QueryParameter(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public QueryParameter()
        {
            Key = null;
            Value = null;
        }
    }
}