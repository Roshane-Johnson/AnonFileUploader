using System;
using System.Windows.Forms;
using Leaf.xNet;
using Newtonsoft.Json;

namespace AnonFileUploader
{
    public partial class Form1 : Form
    {
        //Vars to be used later in uploader\\
        private string fileName;
        private string filePath;
        private string html;
        private dynamic json;
        private string windowTitle = "AnonFile Uploder - by 33Savage";
        private string noFileSelectedError = "Please Select a File to Upload!";
        private string copiedToClipboard = "Text Copied!";
        private string copiedToClipboardError = "Upload a file then copy the link!";
        private string openFileDialogTitle = "Select File to Upload";
        private string openFileDialogFilter = "All Files |*.*";
        private string forumUrl = "https://3rdworld.cc";
        private string nulledForumUrl = "https://www.nulled.to/user/2064686-";
        private string crackedForumUrl = "https://cracked.to/User-33Savage";
        private string btcAddress = "3Leq8rueFeEVbaF31JQxtY5q4EkwocCtuy";
        //End\\

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void selectFile_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = openFileDialogFilter;
                openFileDialog.Title = openFileDialogTitle;
                openFileDialog.ShowDialog();
                tbSelectedFile.Text = openFileDialog.FileName;
                fileName = openFileDialog.SafeFileName;
                filePath = openFileDialog.FileName;
            }
            
        }

        public void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (filePath != null)
            {
                using (HttpRequest request = new HttpRequest())
                {
                    request.UserAgent = Http.FirefoxUserAgent();

                    var multipartContent = new MultipartContent()
                    {
                        {new FileContent(filePath),"file", fileName}
                    };

                    html = request.Post("https://api.anonfiles.com/upload", multipartContent).ToString();
                    json = JsonConvert.DeserializeObject(html);

                    lbUploadName.Text = json["data"]["file"]["metadata"]["name"];
                    lbUploadSize.Text = json["data"]["file"]["metadata"]["size"]["readable"];
                    lbUploadLink.Text = json["data"]["file"]["url"]["short"];


                }
            }
            else
            {
                MessageBox.Show(noFileSelectedError, windowTitle);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbUploadLink.Text))
            {
                Clipboard.SetText(lbUploadLink.Text);
                MessageBox.Show(copiedToClipboard, windowTitle);
            }
            else
            {
                MessageBox.Show(copiedToClipboardError, windowTitle);
            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lbUploadLink_Click(object sender, EventArgs e)
        {

        }

        private void lbUploadSize_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbSelectedFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(forumUrl);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(forumUrl);
            MessageBox.Show(copiedToClipboard, windowTitle);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(nulledForumUrl);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(crackedForumUrl);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(btcAddress);
            MessageBox.Show(copiedToClipboard, windowTitle);
        }
    }
}
