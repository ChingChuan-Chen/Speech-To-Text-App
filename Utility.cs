using System.Runtime.InteropServices;
using Xabe.FFmpeg;

namespace SpeechToTextApp
{    public static class KnownFolder
    {
        public static readonly Guid Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
    }

    class Utility
    {

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);
        public static string GetUserDownloadDirectory()
        {
            string downloadDirectory;
            Utility.SHGetKnownFolderPath(KnownFolder.Downloads, 0, IntPtr.Zero, out downloadDirectory);
            return downloadDirectory;
        }

        public static string GetCurrentExecutableDirectory()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(strExeFilePath) ?? "";
        }
        public static async Task ConvertIntoWav(string filePath, string outputFilePath)
        {
            int threadsCount = Environment.ProcessorCount;
            FFmpeg.SetExecutablesPath(GetCurrentExecutableDirectory());
            var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(filePath, outputFilePath);
            conversion.SetOverwriteOutput(true);
            conversion.UseMultiThread(threadsCount);
            await conversion.Start();
        }
    }
}
