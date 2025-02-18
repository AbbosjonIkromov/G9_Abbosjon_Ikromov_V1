using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulExam5.Entities
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }

    }
}
