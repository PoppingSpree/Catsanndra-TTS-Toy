using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catsanndra_TTS_Toy
{
    public class SpeechParams
    {
        public string WhatToSay { get; set; } = "";
        public int IndexOfVoice { get; set; } = 0;
        public int Rate { get; set; } = 0;
        public int Pitch { get; set; } = 0;

        public SpeechParams(string whatToSay, int indexOfVoice)
        {
            this.WhatToSay = whatToSay;
            this.Rate = 1;
            this.Pitch = 4;
            this.IndexOfVoice = indexOfVoice;
        }

        public SpeechParams(string whatToSay, int indexOfVoice, int rate, int pitch)
        {
            this.WhatToSay = whatToSay;
            this.Rate = rate;
            this.Pitch = pitch;
            this.IndexOfVoice = indexOfVoice;
        }
    }
}
