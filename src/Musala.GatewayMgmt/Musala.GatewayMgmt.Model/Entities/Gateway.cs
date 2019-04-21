using Musala.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Musala.GatewayMgmt.Model.Entities
{
    public class Gateway : MusalaEntity<int>
    {
        #region Local Properties

        // TODO: Set as Unique Index by Configuration
        public string SerialNumber { get; set; }

        // TODO: human-readable name(string). What's means with human readable in this context,
        // how can I verify this is or will be human-readable?
        public string Name { get; set; }
        
        // TODO: This field must be validated
        public string IPv4 { get; set; }

        #endregion

        #region Collections
        public virtual ICollection<Device> Devices { get; set; }

        #endregion

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(SerialNumber))
                yield return new ValidationResult("Serial number must have a value.", new[] { nameof(SerialNumber) });
            if (string.IsNullOrWhiteSpace(SerialNumber))
                yield return new ValidationResult("Gateway name can not be empty.", new[] { nameof(Name) });
        }
    }
}
