using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Commons.Models
{
    /// <summary>
    /// Represents a log of changes made to a event property.
    /// </summary>
    public class ChangeLog : BaseModel
    {
        /// <summary>
        /// The unique identifier of the change log entry.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }

        /// <summary>
        /// The date and time when the change was made.
        /// </summary>
        public DateTime ChangeDate { get; set; }

        /// <summary>
        /// A description of the change that was made.
        /// </summary>
        public string Description { get; set; }
    }
}
