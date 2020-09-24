using SeenLive.Models;

namespace SeenLive.Services.Communication
{
    public class SaveBandResponce
        : BaseResponse
    {
        public Band Band { get; }

        private SaveBandResponce(bool success, string message, Band band) : base(success, message) => Band = band;

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="band">Saved Band.</param>
        /// <returns>Response.</returns>
        public SaveBandResponce(Band band) : this(true, string.Empty, band)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveBandResponce(string message) : this(false, message, null)
        { }
    }
}
