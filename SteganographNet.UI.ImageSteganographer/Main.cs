using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SteganographNet.Images;
using Image = SixLabors.ImageSharp.Image;

namespace SteganographNet.UI.ImageSteganographer
{
    public partial class Main : Form
    {
        string? _filepath;
        ISteganographer<Image<Rgba32>> _steganographer;
        Image<Rgba32> _image;

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
            _steganographer = ImageRgba32Steganographer.Default;
        }

        async void SaveAsToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (_image == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            if (_saveImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                await _image.SaveAsStegoAsync(_saveImageFileDialog.FileName);
            }
        }

        async void SaveToolStripMenuItemOnClick(object? sender, EventArgs e)
        {
            if (_image == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            await _image.SaveAsStegoAsync(_filepath);
        }

        void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _image?.Dispose();
        }

        async void OpenToolStripMenuItemOnClick(object? sender, EventArgs e)
        {
            if (_openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filepath = _openImageFileDialog.FileName;
                _image = await Image.LoadAsync<Rgba32>(_filepath);
                _labelName.Text = $"Name: {Path.GetFileName(_filepath)}";
                _labelWidth.Text = $"Width: {_image.Width}";
                _labelHeight.Text = $"Height: {_image.Height}";
                _labelMaxCapacity.Text = $"Storage Capacity: {_steganographer.CalculateBitCapacity(_image) /8} Bytes";
                _textBoxMessage.Text = string.Empty;
                await ShowImage();
            }
        }
        
        void ExitToolStripMenuItem_Click(object? sender, EventArgs e) => Close();

        void ButtonExtract_Click(object sender, EventArgs e)
        {
            if (_image == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            _textBoxMessage.Text = _steganographer.ExtractMessage(_image);
        }

        void ButtonEmbed_Click(object sender, EventArgs e)
        {
            if (_image == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            _steganographer.EmbedMessage(_image, _textBoxMessage.Text);
        }

        void TextBoxMessage_TextChanged(object sender, EventArgs e)
        {
            var messageSize = Encoding.UTF8.GetBytes(_textBoxMessage.Text).LongLength;

            _groupBoxMessage.Text = $"Message ({messageSize} Bytes):";
        }
        
        async Task ShowImage()
        {
            if (_image == null)
                return;

            await using var memoryStream = new MemoryStream();
            await _image.SaveAsStegoAsync(memoryStream);
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
            if (_image == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            await using var inputStream = File.OpenRead(_textBoxSourceFile.Text);

            _steganographer.EmbedStream(_image, inputStream);
        }

        async void ButtonExtractFile_Click(object sender, EventArgs e)
        {
            if (_image == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }
            
            await using var outputStream = File.Create(_textBoxTargetFile.Text);

            _steganographer.ExtractToStream(_image, outputStream);
        }
    }
}
