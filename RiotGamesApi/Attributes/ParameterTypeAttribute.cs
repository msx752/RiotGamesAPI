using System;

namespace RiotGamesApi.Attributes
{
    /// <summary>
    /// valueType of Url Path Parameter 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ParameterTypeAttribute : Attribute
    {
        public ParameterTypeAttribute(Type _apitype)
        {
            this.ParameterType = _apitype;
        }

        public Type ParameterType { get; }

        /// <inheritdoc />
        ///
        public override string ToString()
        {
            return ParameterType.ToString();
        }
    }
}