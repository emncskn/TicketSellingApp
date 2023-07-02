using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Business
{
    public class ValidationResult
    {
        public bool IsValid
        {
            get
            {
                return !Messages.Any();
            }
        }

        public ICollection<string> Messages { get; } = new List<string>();

        public new string ToString => string.Join('\n', Messages);
    }
}
