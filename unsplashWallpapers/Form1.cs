using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using unsplashWallpapers.Dto;
using unsplashWallpapers.Service;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace unsplashWallpapers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (var tag in this.getTags())
            {
                this.tagSelector.Items.Add(tag as string);
            }

            this.settingsApiKey.Text = (string)Properties.Settings.Default["apiKey"];
            this.settingsInterval.Value = (int)Properties.Settings.Default["interval"];
            this.settingsDownloadPath.Text = (string)Properties.Settings.Default["downloadPath"];

            changeTimer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tagSelector.Items.Add(this.addTagInput.Text);
            this.saveTags();
            this.addTagInput.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["apiKey"] = this.settingsApiKey.Text;
            Properties.Settings.Default["interval"] = (int)this.settingsInterval.Value;
            Properties.Settings.Default["downloadPath"] = this.settingsDownloadPath.Text;
            Properties.Settings.Default.Save();

            changeWallpappers();
            changeTimer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(this.tagSelector);
            selectedItems = this.tagSelector.SelectedItems;

            if (this.tagSelector.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    this.tagSelector.Items.Remove(selectedItems[i]);
            }

            this.saveTags();
        }

        private void saveTags()
        {
            var tags = new List<string>();

            foreach (var item in this.tagSelector.Items)
            {
                tags.Add(item.ToString());
            }

            Properties.Settings.Default["tags"] = JsonSerializer.Serialize(tags);
            Properties.Settings.Default.Save();
        }

        private string[] getTags()
        {
            var json = Properties.Settings.Default["tags"].ToString();
            string[] tags = {};

            if (json != null)
            {
                tags = JsonSerializer.Deserialize<string[]>(json: Properties.Settings.Default["tags"].ToString());
            }

            return tags;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(this.folderBrowserDialog1.SelectedPath))
            {
                this.settingsDownloadPath.Text = this.folderBrowserDialog1.SelectedPath.ToString();
            }
        }

        private void changeWallpappers()
        {
            if (
                Properties.Settings.Default["downloadPath"].ToString().Length > 3
              && Properties.Settings.Default["apiKey"].ToString().Length > 5  
            ) {
                UnsplashApiService api = new UnsplashApiService(Properties.Settings.Default.apiKey);
                string[] tags = this.getTags();

                if (tags.Length > 0)
                {
                    var windowsService = new WindowsService();
                    var image = api.getNewImage(tags);
                    var downloadedImage = api.DownloadImageAsync(image, (string)Properties.Settings.Default["downloadPath"]);

                    downloadedImage.ContinueWith(t => {
                        windowsService.changeWallpappers(t.Result);
                        windowsService.cleanDownloadPath(t.Result);
                    });
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            changeWallpappers();
        }

        private void changeTimer()
        {
            int interval = (int)Properties.Settings.Default["interval"];
            if (interval > 0)
            {
                this.timer1.Interval = (int)Properties.Settings.Default["interval"] * 60000;
                this.timer1.Enabled = true;
            }
            else
            {
                this.timer1.Enabled = false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;
        }
    }
}