using System.IO;

namespace SpeechToTextApp
{
    public partial class MainForm : Form
    {
        string userDownloadDirectory = Utility.GetUserDownloadDirectory();
        SpeechRecognizedUtility chtEngSpeechRecognizedUtility = new SpeechRecognizedUtility(new List<string> { "zh-TW", "en-US" });
        public MainForm()
        {
            InitializeComponent();
            fileLocationText.Text = userDownloadDirectory;
        }

        private async void run_button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string outputFileName = Path.ChangeExtension(fileLocationText.Text, ".wav");
            await Utility.ConvertIntoWav(fileLocationText.Text, outputFileName);
            string restultString = await chtEngSpeechRecognizedUtility.ContinuousRecognitionWithFileAndPhraseListsAsync(outputFileName);
            string captionOutputFile = Path.ChangeExtension(fileLocationText.Text, ".txt");
            if (File.Exists(captionOutputFile))
            {
                File.Delete(captionOutputFile);
            }
            File.WriteAllText(captionOutputFile, restultString);
            this.Cursor = Cursors.Default;
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = userDownloadDirectory;
            openFileDialog1.Filter = "MP3/MP4/WAV files (*.mp3, *.mp4, *.wav)|*.mp3;*.mp4;*.wav";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileLocationText.Text = openFileDialog1.FileName;
            }
        }
    }
}