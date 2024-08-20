using Commons.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace EventCore.Models
{
    /// <summary>
    /// Represents a photo associated with a event property.
    /// </summary>
    public class EventPhoto : BaseModel
    {
        /// <summary>
        /// The unique identifier of the event photo.
        /// </summary>

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }

        /// <summary>
        /// The URL of the photo.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The ID of the associated event property.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// The associated event property.
        /// </summary>
        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}