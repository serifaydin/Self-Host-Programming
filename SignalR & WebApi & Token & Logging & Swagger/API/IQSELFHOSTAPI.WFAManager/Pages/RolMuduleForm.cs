using System.Windows.Forms;

namespace IQSELFHOSTAPI.WFAManager.Pages
{
    public partial class RolMuduleForm : Form
    {
        public RolMuduleForm()
        {
            InitializeComponent();

            treeView1.Nodes.Add("Cari Modul");
            treeView1.Nodes.Add("Finans Modul");

            treeView1.Nodes[0].Nodes.Add("Cari Alt Modul");
        }
    }
}