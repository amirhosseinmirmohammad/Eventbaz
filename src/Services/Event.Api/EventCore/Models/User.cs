using Commons.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventCore.Models
{
    /// <summary>
    /// Represents a user in the system with personal details.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets the user's mobile number.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the user's national code.
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the common properties shared across all models.
        /// </summary>
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            BaseModel = new BaseModel();
        }
    }
}
