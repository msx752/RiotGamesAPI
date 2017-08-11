using System;

namespace RiotGamesApi.Models
{
    /// <summary>
    /// RiotGamesApi custom Exception 
    /// </summary>
    public class RiotGamesApiException : Exception
    {
        public RiotGamesApiException()
        {
        }

        public RiotGamesApiException(string message) : base(message)
        {
        }

        public RiotGamesApiException(string message, Exception exception) : base(message, exception)
        {
        }

        /// <inheritdoc />
        ///
        public override string ToString()
        {
            return Message.ToString();
        }
    }
}