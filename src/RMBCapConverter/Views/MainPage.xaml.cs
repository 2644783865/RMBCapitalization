using System;
using System.Linq;
using Windows.Media.SpeechSynthesis;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using RMBCapConverter.Helpers;
using RMBCapConverter.Services;

namespace RMBCapConverter.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            _synthesizer = new SpeechSynthesizer();
            CapitalizedRmb = string.Empty;
        }

        public string CapitalizedRmb
        {
            get => _capitalizedRmb;
            set
            {
                _capitalizedRmb = value;
                TxtCapitalizedRmb.Text = value;
            }
        }

        private readonly SpeechSynthesizer _synthesizer;

        private string _inputedNumbers;
        private string _capitalizedRmb;

        public string InputedNumbers
        {
            get => _inputedNumbers;
            set
            {
                if (value.Length <= 11)
                {
                    if (!string.IsNullOrEmpty(value) && value.Contains("."))
                    {
                        var parts = value.Split('.');
                        var decPart = parts[1];
                        if (decPart.Length <= 2)
                        {
                            if (value == ".")
                            {
                                value = "0.";
                                _inputedNumbers = value;
                            }
                            else
                            {
                                _inputedNumbers = value;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    // e.g. 01234... format to 1234
                    if (value.StartsWith("0") && !value.Contains("."))
                    {
                        value = int.Parse(value).ToString();
                        _inputedNumbers = value;
                    }
                    else
                    {
                        _inputedNumbers = value;
                    }
                    TxtInputNumbers.Text = value;
                    CalcRmb();
                }
            }
        }

        public void CalcRmb()
        {
            var response = RMBConverter.GetCapitalizedRmb(InputedNumbers);
            if (response.IsSuccess)
            {
                CapitalizedRmb = response.Item;
            }
        }

        private void BtnB_OnClick(object sender, RoutedEventArgs e)
        {
            if (InputedNumbers.Length > 0)
            {
                InputedNumbers = InputedNumbers.Substring(0, InputedNumbers.Length - 1);
            }
        }

        private void Btn1_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 1;
        }

        private void Btn2_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 2;
        }

        private void Btn3_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 3;
        }

        private void Btn4_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 4;
        }

        private void Btn5_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 5;
        }

        private void Btn6_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 6;
        }

        private void Btn7_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 7;
        }

        private void Btn8_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 8;
        }

        private void Btn9_OnClick(object sender, RoutedEventArgs e)
        {
            InputedNumbers += 9;
        }

        private void Btn0_OnClick(object sender, RoutedEventArgs e)
        {
            if (InputedNumbers != "0")
            {
                InputedNumbers += 0;
            }
        }

        private void BtnC_OnClick(object sender, RoutedEventArgs e)
        {
            CapitalizedRmb = string.Empty;
            InputedNumbers = string.Empty;
        }

        private void MainPage_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case VirtualKey.Number0:
                case VirtualKey.NumberPad0:
                    if (InputedNumbers != "0")
                    {
                        InputedNumbers += 0;
                    }
                    break;
                case VirtualKey.Number1:
                case VirtualKey.NumberPad1:
                    InputedNumbers += 1;
                    break;
                case VirtualKey.Number2:
                case VirtualKey.NumberPad2:
                    InputedNumbers += 2;
                    break;
                case VirtualKey.Number3:
                case VirtualKey.NumberPad3:
                    InputedNumbers += 3;
                    break;
                case VirtualKey.Number4:
                case VirtualKey.NumberPad4:
                    InputedNumbers += 4;
                    break;
                case VirtualKey.Number5:
                case VirtualKey.NumberPad5:
                    InputedNumbers += 5;
                    break;
                case VirtualKey.Number6:
                case VirtualKey.NumberPad6:
                    InputedNumbers += 6;
                    break;
                case VirtualKey.Number7:
                case VirtualKey.NumberPad7:
                    InputedNumbers += 7;
                    break;
                case VirtualKey.Number8:
                case VirtualKey.NumberPad8:
                    InputedNumbers += 8;
                    break;
                case VirtualKey.Number9:
                case VirtualKey.NumberPad9:
                    InputedNumbers += 9;
                    break;
                case VirtualKey.Decimal:
                    if (!InputedNumbers.Contains("."))
                    {
                        InputedNumbers += ".";
                    }
                    break;
                case VirtualKey.Back:
                    if (InputedNumbers.Length > 0)
                    {
                        InputedNumbers = InputedNumbers.Substring(0, InputedNumbers.Length - 1);
                    }
                    break;
                case VirtualKey.Delete:
                    InputedNumbers = string.Empty;
                    break;
                case VirtualKey.Escape:
                    CapitalizedRmb = string.Empty;
                    InputedNumbers = string.Empty;
                    break;
                default:
                    if ((int)e.Key == 190)
                    {
                        if (!InputedNumbers.Contains("."))
                        {
                            InputedNumbers += ".";
                        }
                    }
                    break;
            }
        }

        private void BtnDot_OnClick(object sender, RoutedEventArgs e)
        {
            if (!InputedNumbers.Contains("."))
            {
                InputedNumbers += ".";
            }
        }

        private void BtnCopy_OnClick(object sender, RoutedEventArgs e)
        {
            Edi.UWP.Helpers.Utils.CopyToClipBoard(CapitalizedRmb);
            Singleton<ToastNotificationsService>.Instance.ShowConvertNotification(CapitalizedRmb, InputedNumbers);
        }

        private async void BtnRead_OnClick(object sender, RoutedEventArgs e)
        {
            if (media.CurrentState.Equals(MediaElementState.Playing))
            {
                media.Stop();
            }
            else
            {
                string text = TxtCapitalizedRmb.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    try
                    {
                        var chsVoice =
                            SpeechSynthesizer.AllVoices.FirstOrDefault(
                                x => x.Gender == VoiceGender.Female && x.Language.Contains("zh")) ??
                            SpeechSynthesizer.AllVoices.FirstOrDefault(
                                x => x.Gender == VoiceGender.Male && x.Language.Contains("zh"));

                        if (null != chsVoice)
                        {
                            _synthesizer.Voice = chsVoice;
                        }

                        // Create a stream from the text. This will be played using a media element.
                        SpeechSynthesisStream synthesisStream = await _synthesizer.SynthesizeTextToStreamAsync(text);

                        // Set the source and start playing the synthesized audio stream.
                        media.AutoPlay = true;
                        media.SetSource(synthesisStream, synthesisStream.ContentType);
                        media.Play();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        // If media player components are unavailable, (eg, using a N SKU of windows), we won't
                        // be able to start media playback. Handle this gracefully
                        var messageDialog = new Windows.UI.Popups.MessageDialog("Media player components unavailable");
                        await messageDialog.ShowAsync();
                    }
                    catch (Exception ex)
                    {
                        // If the text is unable to be synthesized, throw an error message to the user.
                        media.AutoPlay = false;
                        var messageDialog = new Windows.UI.Popups.MessageDialog("Unable to synthesize text: " + ex.Message);
                        await messageDialog.ShowAsync();
                    }
                }
            }
        }
    }
}
