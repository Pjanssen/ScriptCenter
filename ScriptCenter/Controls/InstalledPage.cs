using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;

namespace ScriptCenter.Controls
{
    public partial class InstalledPage : UserControl
    {
        private String installedScriptsFile = "C:/temp/scriptcenter/" + Defaults.InstalledScriptsRepository;
        private ScriptRepository installedScripts;


        public InstalledPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.DesignMode)
                return;

            this.listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);
            this.listView1.ItemChecked += new ItemCheckedEventHandler(listView1_ItemChecked);

            JsonFileHandler<ScriptRepository> h = new JsonFileHandler<ScriptRepository>();
            this.installedScripts = h.Read(installedScriptsFile);
            if (installedScripts == null)
            {
                MessageBox.Show("Error loading installed scripts xml:\n" + installedScriptsFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*
            foreach (ScriptManifestReference r in this.installedScripts.Scripts)
            {
                this.LoadManifest(r.URI);
            }
            */
        }



        private void LoadManifest(String address)
        {
            JsonFileHandler<ScriptManifest> h = new JsonFileHandler<ScriptManifest>();
            ScriptManifest m = h.Read(address);

            ListViewItem i = new ListViewItem();
            if (m == null)
                i.Text = "Error loading manifest " + address;
            else
            {
                i.Text = m.Name;
                //i.SubItems.Add(m.Version.ToString());
            }

            this.listView1.Items.Add(i);
        }

        void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = (this.listView1.SelectedItems.Count > 0 || this.listView1.CheckedItems.Count > 0);
        }


        void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.button1.Enabled = (this.listView1.SelectedItems.Count > 0 || this.listView1.CheckedItems.Count > 0);
        }
    }
}
