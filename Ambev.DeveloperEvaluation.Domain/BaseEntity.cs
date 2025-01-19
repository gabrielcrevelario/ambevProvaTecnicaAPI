using Ambev.DeveloperEvaluation.Common.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator = Ambev.DeveloperEvaluation.Common.Validation.Validator;

namespace Ambev.DeveloperEvaluation.Domain
{

    public class BaseEntity : IComparable<BaseEntity>
    {
        public Guid Id { get; set; }

        public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
        {
            return Validator.ValidateAsync(this);
        }

        public int CompareTo(BaseEntity? other)
        {
            if (other == null)
            {
                return 1;
            }

            return other!.Id.CompareTo(Id);
        }
    }
}
