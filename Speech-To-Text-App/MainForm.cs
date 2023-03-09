using System.IO;

namespace SpeechToTextApp
{
    public partial class MainForm : Form
    {
        List<string> autoDetectLanguages = new List<string> { "zh-TW", "en-US" };
        string userDownloadDirectory = Utility.GetUserDownloadDirectory();
        SpeechRecognizedUtility? chtEngSpeechRecognizedUtility = null;
        public MainForm()
        {
            InitializeComponent();
            fileLocationText.Text = userDownloadDirectory;
        }

        private async void run_button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!File.Exists(fileLocationText.Text))
            {
                MessageBox.Show(
                    $"The file path {fileLocationText.Text} is not found or is a directory.",
                    "Error: File is not found", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
            else
            {
                string outputFileName = Path.ChangeExtension(fileLocationText.Text, ".wav");
                if (fileLocationText.Text != outputFileName)
                {
                    await Utility.ConvertIntoWav(fileLocationText.Text, outputFileName);
                }
                if (chtEngSpeechRecognizedUtility == null)
                {
                    if ((keyTextBox.Text.Length == 0) || (regionTextBox.Text.Length == 0))
                    {
                        MessageBox.Show(
                            "You need provide the key and region acquired from Azure Cognitive Service.",
                            "Error: Key or Region is empty", MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                    }
                    else
                    {
                        chtEngSpeechRecognizedUtility = new SpeechRecognizedUtility(keyTextBox.Text, regionTextBox.Text, autoDetectLanguages);
                        runRecognization(outputFileName);
                    }
                }
                else
                {
                    runRecognization(outputFileName);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private async void runRecognization(string outputFileName)
        {
            if (chtEngSpeechRecognizedUtility != null)
            {
                string restultString = await chtEngSpeechRecognizedUtility.ContinuousRecognitionWithFileAndPhraseListsAsync(outputFileName);
                string captionOutputFile = Path.ChangeExtension(fileLocationText.Text, ".txt");
                if (File.Exists(captionOutputFile))
                {
                    File.Delete(captionOutputFile);
                }
                File.WriteAllText(captionOutputFile, restultString);
            }
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