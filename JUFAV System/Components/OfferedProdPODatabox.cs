using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUFAV_System.Components
{
    public partial class OfferedProdPODatabox : Component
    {
        public OfferedProdPODatabox()
        {
            InitializeComponent();
        }

        public OfferedProdPODatabox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
