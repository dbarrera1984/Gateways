using Musala.GatewayMgmt.Model.Enums;
using Musala.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musala.GatewayMgmt.Model.Entities
{
    public class Device : MusalaEntity<int>, IDateTracking
    {
        #region Local Properties

        public long UID { get; set; }
        public string Vendor { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }

        #endregion

        #region Foreign Keys

        public int GatewayId { get; set; }
        public virtual Gateway Gateway { get; set; }

        #endregion

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Vendor))
                yield return new ValidationResult("Vendor's name must have a value.", new[] { nameof(Vendor) });
        }
    }
}
