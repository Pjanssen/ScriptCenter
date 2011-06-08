using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptCenter.Repository;
using ScriptCenter.Installer;
using ScriptCenter.Installer.Actions;
using ScriptCenter.Installer.UI;
using ScriptCenter.Utils;

namespace ScriptCenter.Controls
{
    public partial class BrowsePage : UserControl
    {
        public BrowsePage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.DesignMode)
                return;

            this.repositoryTree.BeginUpdate();

            listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);
            listView1.ItemChecked += new ItemCheckedEventHandler(listView1_ItemChecked);
            
            this.repositories = new List<ScriptRepository>();

            JsonFileHandler<ScriptRepositoryList> h = new JsonFileHandler<ScriptRepositoryList>();
            this.repositoryList = h.Read(repositoryListFile);
            if (this.repositoryList != null)
            {
                foreach (ScriptRepositoryReference r in this.repositoryList.Repositories)
                {
                    this.repositoryTree.Nodes.Add(String.Format("{0} - {1}", r.Name, r.URI));
                }
            }

            this.repositoryTree.EndUpdate();
        }


        private ScriptRepositoryList repositoryList;
        private String repositoryListFile = "C:/temp/scriptcenter/" + Defaults.RepositoryList;
        private List<ScriptRepository> repositories;


        private void LoadManifest(String address)
        {
            JsonFileHandler<ScriptManifest> manifest_handler = new JsonFileHandler<ScriptManifest>();
            manifest_handler.ReadComplete += manifest_handler_LoadComplete;
            manifest_handler.ReadError += manifest_handler_LoadError;
            manifest_handler.ReadAsync(address);
        }
        void manifest_handler_LoadError(object sender, ErrorEventArgs args)
        {
            MessageBox.Show("Could not load manifest:\n" + args.Exception.Message);
        }
        void manifest_handler_LoadComplete(object sender, ReadCompleteEventArgs<ScriptManifest> args)
        {
            String id = args.Data.Id;
            
            //TODO fix icon uri
            String imgKey = "default";

            if (imgKey != "default" && !this.imageList1.Images.ContainsKey(imgKey))
            {
                try
                {
                    /*
                    System.Net.WebRequest r = System.Net.WebRequest.Create(args.Data.Info.IconURI);
                    System.Net.WebResponse resp = r.GetResponse();
                    
                    System.IO.Stream str = resp.GetResponseStream();
                    Image ico = Image.FromStream(str);
                    this.imageList1.Images.Add(imgKey, ico);

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ico.Save(ms, ico.RawFormat);
                    Console.WriteLine(Convert.ToBase64String(ms.ToArray(), Base64FormattingOptions.InsertLineBreaks));
                    //byte[] imgData = new byte[str.Length];
                    //str.Read(imgData, 0, (int)str.Length);
                    //Console.WriteLine(Convert.ToBase64String(imgData, Base64FormattingOptions.None));
                     */
                }
                catch
                {
                    imgKey = "error";
                }
            }

            ListViewItem i = new ListViewItem(args.Data.Name, imgKey);
            i.SubItems.Add(args.Data.Author);
            i.Tag = args.Data;
            listView1.Items.Add(i);
        }

        private void LoadRepository(String address)
        {
            if (address.EndsWith(".manifest"))
            {
                LoadManifest(address);
                return;
            }
            if (!address.EndsWith(".repository"))
                address += "/" + Defaults.Repository;

            JsonFileHandler<ScriptRepository> repository_handler = new JsonFileHandler<ScriptRepository>();
            repository_handler.ReadComplete += repository_handler_LoadComplete;
            repository_handler.ReadError += repository_handler_LoadError;
            repository_handler.ReadAsync(address);
        }
        void repository_handler_LoadError(object sender, ErrorEventArgs args)
        {
            String msg = "Could not load repository.\n" + args.Exception.Message + "\n\nRemove repository from list?";
            DialogResult r = MessageBox.Show(msg, "Load Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == System.Windows.Forms.DialogResult.Yes)
            {

            }
        }
        void repository_handler_LoadComplete(object sender, ReadCompleteEventArgs<ScriptRepository> args)
        {
            /*
            foreach (ScriptManifestReference scriptRef in args.Data.Scripts)
            {
                LoadManifest(scriptRef.URI);
            }
             */
        }



        void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyData & Keys.Enter) == Keys.Enter)
            {
                ScriptRepositoryReference rep = new ScriptRepositoryReference();
                //rep.URI = this.comboBox1.Text;
                this.repositoryList.Repositories.Add(rep);
                JsonFileHandler<ScriptRepositoryList> h = new JsonFileHandler<ScriptRepositoryList>();
                h.Write(this.repositoryListFile, this.repositoryList);
                this.LoadRepository(rep.URI);
            }
        }

        void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem == null)
                return;

            if (e.ListItem is ScriptRepositoryReference)
            {
                ScriptRepositoryReference r = (ScriptRepositoryReference)e.ListItem;
                //e.Value = String.Format(comboBox1.FormatString, r.Name, r.URI);
            }
            else
                e.Value = e.ListItem.ToString();
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            //object selItem = this.comboBox1.SelectedItem;
            //if (selItem is ScriptRepositoryReference)
             //   LoadRepository(((ScriptRepositoryReference)selItem).URI);
        }

        void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
            ScriptManifest manifest = handler.Read("C:/temp/scriptcenter/unpacked_installer/outliner.manifest.xml");
            
            JsonFileHandler<InstallerConfiguration> configHandler = new JsonFileHandler<InstallerConfiguration>();
            InstallerConfiguration config = configHandler.Read("C:/temp/scriptcenter/unpacked_installer/config.installer.xml");

            Installer.Installer installer = new Installer.Installer("C:/temp/scriptcenter/unpacked_installer", manifest, config);
            InstallerUIConfiguration uiConfig = new InstallerUIConfiguration();

            ScriptCenter.Installer.UI.InstallerDialog d = new ScriptCenter.Installer.UI.InstallerDialog(installer, uiConfig);
            d.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            ScriptCenter.Installer.NewInstallerWizard.NewInstallerWizard w = new Installer.NewInstallerWizard.NewInstallerWizard();
            w.Show();
             */
            ScriptManifest m = new ScriptManifest();
            m.Id = "nl.threesixty.outliner";
            m.Name = "Outliner";
            m.Versions.Add(new ScriptVersion(2, 0, 96, ScriptReleaseStage.Release));

            InstallerConfiguration config = new InstallerConfiguration();
            InstallerUIConfiguration uiConfig = new InstallerUIConfiguration();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InstallerConfiguration config = new InstallerConfiguration();
            config.AddAction(new CopyDirAction("scripts", AppPaths.Directory.Scripts));
            config.AddAction(new CopyDirAction("startupscripts", AppPaths.Directory.StartupScripts));
            config.AddAction(new AssignHotkeyAction(Keys.H | Keys.Alt, "", ""));

            JsonFileHandler<InstallerConfiguration> handler = new JsonFileHandler<InstallerConfiguration>();
            handler.Write("C:/temp/scriptcenter/config.installer", config);
        }
    }
}
