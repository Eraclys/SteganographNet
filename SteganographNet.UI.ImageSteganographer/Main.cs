using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteganographNet.Steganographers;

namespace SteganographNet.UI.ImageSteganographer
{
    public partial class Main : Form
    {
        SteganoPng? _steganograph;
        string _filepath;

        public Main()
        {
            InitializeComponent();

            _exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            _openToolStripMenuItem.Click += OpenToolStripMenuItemOnClick;
            _saveToolStripMenuItem.Click += SaveToolStripMenuItemOnClick;
            _saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            FormClosing += Main_FormClosing;

            _openImageFileDialog.Filter = "Png Images|*.png|Jpeg Images|*.jpg";
            _saveImageFileDialog.Filter = "Png|*.png";
        }

        async void SaveAsToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (_steganograph == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            if (_saveImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                await _steganograph.Save(_saveImageFileDialog.FileName);
            }
        }

        async void SaveToolStripMenuItemOnClick(object? sender, EventArgs e)
        {
            if (_steganograph == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            await _steganograph.Save(_filepath);
        }

        void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _steganograph?.Dispose();
        }

        async void OpenToolStripMenuItemOnClick(object? sender, EventArgs e)
        {
            if (_openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filepath = _openImageFileDialog.FileName;
                _steganograph = await SteganoPng.Load(_filepath);
                _labelName.Text = $"Name: {Path.GetFileName(_filepath)}";
                _labelWidth.Text = $"Width: {_steganograph.Value.Width}";
                _labelHeight.Text = $"Height: {_steganograph.Value.Height}";
                _labelMaxCapacity.Text = $"Storage Capacity: {_steganograph.CapacityInBits()/8} Bytes";
                _textBoxMessage.Text = string.Empty;
                await ShowImage();
            }
        }
        
        void ExitToolStripMenuItem_Click(object? sender, EventArgs e) => Close();

        void ButtonExtract_Click(object sender, EventArgs e)
        {
            if (_steganograph == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            _textBoxMessage.Text = _steganograph.ExtractMessage();
        }

        void ButtonEmbed_Click(object sender, EventArgs e)
        {
            if (_steganograph == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            _steganograph.EmbedMessage(_textBoxMessage.Text);
        }

        void TextBoxMessage_TextChanged(object sender, EventArgs e)
        {
            var messageSize = Encoding.UTF8.GetBytes(_textBoxMessage.Text).LongLength;

            _groupBoxMessage.Text = $"Message ({messageSize} Bytes):";
        }

        async Task EmbedMessage()
        {
            if (_steganograph == null)
                return;

            _steganograph.EmbedMessage(_textBoxMessage.Text);

            await ShowImage();
        }

        async Task ShowImage()
        {
            if (_steganograph == null)
                return;

            await using var memoryStream = new MemoryStream();
            await _steganograph.Save(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            pictureBox1.Image = new Bitmap(memoryStream);
        }
        
        void RadioButtonMessage_CheckedChanged(object sender, EventArgs e) => UpdateFileOrMessageSelection();

        void RadioButtonFile_CheckedChanged(object sender, EventArgs e) => UpdateFileOrMessageSelection();

        void ButtonSelectSourceFile_Click(object sender, EventArgs e)
        {
            if (_openSourceFileDialog.ShowDialog() == DialogResult.OK)
            {
                _textBoxSourceFile.Text = _openSourceFileDialog.FileName;
            }
        }

        void ButtonSelectTargetFile_Click(object sender, EventArgs e)
        {
            if (_saveTargetFileDialog.ShowDialog() == DialogResult.OK)
            {
                _textBoxTargetFile.Text = _saveTargetFileDialog.FileName;
            }
        }

        void UpdateFileOrMessageSelection()
        {
            _groupBoxMessage.Visible = _radioButtonMessage.Checked;
            _groupBoxFile.Visible = _radioButtonFile.Checked;
        }

        async void ButtonEmbedFile_Click(object sender, EventArgs e)
        {
            if (_steganograph == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            await using var inputStream = File.OpenRead(_textBoxSourceFile.Text);

            _steganograph.EmbedStream(inputStream);
        }

        async void ButtonExtractFile_Click(object sender, EventArgs e)
        {
            if (_steganograph == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }
            
            await using var outputStream = File.Create(_textBoxTargetFile.Text);

            _steganograph.ExtractToStream(outputStream);
        }
    }
}
