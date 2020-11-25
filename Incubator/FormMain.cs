using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incubator
{
    public partial class FormMain : Form
    {
        CWorld world;
        public FormMain()
        {
            InitializeComponent();
            world = new CWorld();
            world.Start();
        }

    }
}
