using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using SpeechLib;
using System.Net;

namespace Catsanndra_TTS_Toy
{
    public partial class frmCatsanndraTTSToy : Form
    {
        SpVoice voice = new SpVoice();
        Thread thSpeak;

        ThreadStart thRefSpeakNoSkip;
        Thread thSpeakNoSkip;

        ThreadStart thRefListen;
        Thread thListen;
        ISpeechObjectTokens voices;

        int selectedVoiceIndex = -1;


        string portNum = "8734";

        bool quitNow = false;

        HttpListener httpListener = new HttpListener();

        public frmCatsanndraTTSToy()
        {
            InitializeComponent();
            this.voice = new SpVoice();

            this.thSpeakNoSkip = new Thread(SpeakCurrentTextNoSkip);

            this.thRefListen = new ThreadStart(ListenForHttpRequests);
            this.thListen = new Thread(thRefListen);

            voices = voice.GetVoices();
            foreach (SpObjectToken voiceOption in voices)
            {
                WriteLine(voiceOption.Id);
                string voiceName = voiceOption.Id.Substring(voiceOption.Id.LastIndexOf("\\") + 1);
                cmbVoices.Items.Add(voiceName);
                if (voiceName.Contains("VW Bridget")) 
                {
                    cmbVoices.SelectedIndex = cmbVoices.Items.Count - 1;
                }
            }

            string thePrefix = "http://localhost:" + portNum + "/";
            httpListener.Prefixes.Add(thePrefix);

            this.thListen.Start();

            WriteLine("Listening for messages on " + thePrefix);
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {

            //voice.Voice = voices.Item(cmbVoices.SelectedIndex);
            SpeechParams speechParams = new SpeechParams(txtInput.Text, cmbVoices.SelectedIndex);
            this.thSpeak = new Thread(SpeakCurrentText);
            this.thSpeak.Start(speechParams);
        }

        public void SpeakCurrentText(object speechParams)
        {
            SpeechParams theSpeechParams = (SpeechParams)speechParams;
            voice.Skip("Sentence", 9999);
            if (theSpeechParams.IndexOfVoice > -1) 
            {
                voice.Voice = voices.Item(theSpeechParams.IndexOfVoice);
                voice.Rate = theSpeechParams.Rate;
            }
            voice.Speak("<pitch absmiddle=\"" + theSpeechParams.Pitch + "\">" + theSpeechParams.WhatToSay + "</pitch>", SpeechVoiceSpeakFlags.SVSFDefault);
        }

        public void SpeakCurrentTextNoSkip(object speechParams)
        {
            SpeechParams theSpeechParams = (SpeechParams)speechParams;
            if (theSpeechParams.IndexOfVoice > -1)
            {
                voice.Voice = voices.Item(theSpeechParams.IndexOfVoice);
                voice.Rate = theSpeechParams.Rate;
            }
            voice.Speak("<pitch absmiddle=\"" + theSpeechParams.Pitch + "\">" + theSpeechParams.WhatToSay + "</pitch>", SpeechVoiceSpeakFlags.SVSFDefault);
        }

        public void SpeakText(string textToBeSpoken)
        {
            voice.Skip("Sentence", 9999);
            voice.Speak(textToBeSpoken, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        public void SpeakTextNoSkip(SpeechParams speechParams)
        {
            SpeechParams theSpeechParams = (SpeechParams)speechParams;
            voice.Speak(theSpeechParams.WhatToSay, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        public void WriteLine(string txt) 
        {
            txtDebugOutput.Text = txt + "\r\n" + txtDebugOutput.Text;
        }

        public void HandleHttpRequest(IAsyncResult result) 
        {
            //WriteLine("Received HTTP Request.");

            HttpListener listener = (HttpListener)result.AsyncState;
            // Call EndGetContext to complete the asynchronous operation.
            HttpListenerContext context = listener.EndGetContext(result);
            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;

            string sayThis = request.QueryString.Get("speak");

            // Construct a response.
            string responseString = "<HTML><BODY>";
            responseString += "Hello world!<br/>";
            responseString += "You want me to say: " + sayThis;
            responseString += "</BODY></HTML>";
        
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.

            output.Close();

            if (sayThis != null && sayThis != "") 
            {
                SpeechParams speechParams = new SpeechParams(sayThis, selectedVoiceIndex);
                this.thSpeakNoSkip = new Thread(SpeakCurrentTextNoSkip);
                this.thSpeakNoSkip.Start(speechParams);
                //SpeakTextNoSkip(sayThis);
            }
        }

        public void ListenForHttpRequests()
        {
            httpListener.Start();
            while (!quitNow) 
            {
                IAsyncResult result = httpListener.BeginGetContext(new AsyncCallback(HandleHttpRequest), httpListener);
                result.AsyncWaitHandle.WaitOne();
            }
        }

        private void frmCatsanndraTTSToy_FormClosed(object sender, FormClosedEventArgs e)
        {
            SpeakText("");
            this.quitNow = true;
            //thSpeak.Abort();
            thListen.Abort();
        }

        private void cmbVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedVoiceIndex = cmbVoices.SelectedIndex;
        }
    }
}
