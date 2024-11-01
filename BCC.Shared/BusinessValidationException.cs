
namespace BCC.Shared
{
    public class BusinessValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BusinessValidationException(string message) : base(message) { }
    }
}
