using MyStocks.Forms.Interfaces;
using MyStocks.Forms.WinPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.Speech.Synthesis;

[assembly: Xamarin.Forms.Dependency (typeof (TextToSpeech_WinPhone))]
namespace MyStocks.Forms.WinPhone
{

  public class TextToSpeech_WinPhone : ITextToSpeech
  {
    public TextToSpeech_WinPhone() { }

    public async void Speak(string text)
    {
      var synth = new SpeechSynthesizer();
      await synth.SpeakTextAsync(text);
    }
  }
}
