using System;

namespace RiotGamesApi.Attributes
{
    /// <summary>
    /// allows special characters in request Url 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        public string StringValue { get; }

        /// <inheritdoc />
        ///
        public override string ToString()
        {
            return StringValue.ToString();
        }
    }
}