using System.Text;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace SpeechToTextApp
{
    class SpeechRecognizedUtility
    {
        SpeechConfig speechConfig = default!;
        AutoDetectSourceLanguageConfig autoDetectSourceLanguageConfig = default!;

        public SpeechRecognizedUtility(string key, string region, List<string> sourceLanguageConfig)
        {
            speechConfig = SpeechConfig.FromSubscription(key, region);
            autoDetectSourceLanguageConfig = AutoDetectSourceLanguageConfig.FromLanguages(sourceLanguageConfig.ToArray());
        }

        public string GetTimestampString(SpeechRecognitionResult result)
        {
            var startTime = new TimeSpan(result.OffsetInTicks);
            var endTime = startTime.Add(result.Duration);
            return $"{startTime:hh\\:mm\\:ss\\,fff} --> {endTime:hh\\:mm\\:ss\\,fff}";
        }

        public async Task<string> ContinuousRecognitionWithFileAndPhraseListsAsync(string filePath, bool needRecognizingResult = false)
        {
            StringBuilder resultText = new StringBuilder();
            var stopRecognition = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            using (var audioInput = AudioConfig.FromWavFileInput(filePath))
            {
                using (var recognizer = new SpeechRecognizer(speechConfig, autoDetectSourceLanguageConfig, audioInput))
                {
                    recognizer.Recognizing += (s, e) =>
                    {
                        if (needRecognizingResult)
                        {
                            resultText.AppendLine($"{GetTimestampString(e.Result)}");
                            resultText.AppendLine($"RECOGNIZING:  {e.Result.Text}");
                        }
                    };

                    recognizer.Recognized += (s, e) =>
                    {
                        resultText.AppendLine($"{GetTimestampString(e.Result)}");
                        if (e.Result.Reason == ResultReason.RecognizedSpeech)
                        {
                            resultText.AppendLine($"{e.Result.Text}");
                        }
                        else if (e.Result.Reason == ResultReason.NoMatch)
                        {
                            resultText.AppendLine($"\tNOMATCH: Speech could not be recognized.");
                        }
                    };

                    recognizer.Canceled += (s, e) =>
                    {
                        resultText.AppendLine($"{GetTimestampString(e.Result)}");
                        resultText.AppendLine($"\tCANCELED: Reason={e.Reason}");
                        if (e.Reason == CancellationReason.Error)
                        {
                            resultText.AppendLine($"\tCANCELED: ErrorCode={e.ErrorCode}");
                            resultText.AppendLine($"\tCANCELED: ErrorDetails={e.ErrorDetails}");
                            resultText.AppendLine($"\tCANCELED: Did you update the subscription info?");
                        }
                        stopRecognition.TrySetResult(0);
                    };

                    recognizer.SessionStarted += (s, e) =>
                    {
                        resultText.AppendLine($"Start captioning the file {filePath}.");
                    };

                    recognizer.SessionStopped += (s, e) =>
                    {
                        resultText.AppendLine($"Captioning is completed for the file {filePath}.");
                        stopRecognition.TrySetResult(0);
                    };

                    await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);
                    Task.WaitAny(new[] { stopRecognition.Task });
                    await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
                    return resultText.ToString();
                }
            }
        }
    }
}
