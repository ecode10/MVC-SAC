using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSAC.Models
{
    public class CascadeCombo
    {
        public Pais pais { get; set; }

        public Estado estado { get; set; }

        public Cidade cidade { get; set; }
    }
}