using System.Management;
using System.Text;

namespace PCSpecs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = Environment.MachineName;
            label5.Text = Environment.OSVersion.ToString();

            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
            foreach (ManagementObject Mobject in Search.Get())
            {
                double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                var ramSizeGb = Math.Round(Ram_Bytes / 1073741824);
                label9.Text = ramSizeGb.ToString() + "GB";
            }

            SelectQuery Sq = new SelectQuery("Win32_Processor");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            StringBuilder sb = new StringBuilder();
            foreach (ManagementObject mo in osDetailsCollection)
            {
                var cpuName = (string)mo["Name"];
                label7.Text = cpuName.ToString();
            }

        }
    }
}