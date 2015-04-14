using G31DDCAPIWrapperSpace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        #region Members

        private Wrapper wrapper = new Wrapper();
        private WaveOutHandler waveOutHandler = new WaveOutHandler();

        private delegate void WrapperDD2PreprocessedStreamCallbackHandler(object sender, DDC2PreprocessedStreamEventArgs eventArgs);
        private delegate void WrapperAudioStreamCallbackHandler(object sender, AudioStreamEventArgs eventArgs);
        #endregion

        #region Constructors

        public Form1()          
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void InitializeDeviceConnection()
        {
            if (wrapper.Init())
            {
                G31DDCAPIWrapperDeviceInfo aDeviceInfo = wrapper.deviceInfo;
                SNTextBox.Text              =   aDeviceInfo.serialNumber;
                InterfaceTextBox.Text       =   aDeviceInfo.interfaceType == G31DDCAPIWrapper.DEVICE_INTERFACE_USB ? "USB" : "PCI";
                wrapper.SetFrequency(0);
                int minFrequency                =   (int)wrapper.GetFrequency();
                wrapper.SetFrequency(123456789);
                int maxFrequency                =   (int)wrapper.GetFrequency();
                frequencyTrackBar.Minimum   =   minFrequency;
                frequencyTrackBar.Maximum   =   maxFrequency;
                frequencyUDBox.Minimum      =   minFrequency;
                frequencyUDBox.Maximum      =   maxFrequency;
                frequencyUDBox.Value        =   frequencyTrackBar.Value;
            }
            else
            {
                if (wrapper.apiStatus == Wrapper.APISTATUS_WRAPPERLIBRARY_NOTFOUND)
                {
                    errorTextBox.Text = "Unable to find " + Wrapper.APIWRAPPERLIBRARY + " library!";
                }
                else
                {
                    errorTextBox.Text = "Unable to find device!";
                   
                }
            }
            HandleDeviceConnection();
            
        }

        private void HandleDeviceConnection()
        {

            
            if (wrapper.IsDeviceConnected())
            {             
                button1.Enabled =   errorDevicePanel.Visible    = false;

                deviceInfoPanel.Visible = propertiesDevicePanel.Visible = propertiesDevicePanel.Enabled = true;

                statusBar.ForeColor = Color.Green; 

                statusBar.Text = "Connected successful";

                timerConnection.Start();
            }
            else
            {
                timerConnection.Stop();

                wrapper.CloseDevice();

                button1.Enabled = errorDevicePanel.Visible = true;

                deviceInfoPanel.Visible = propertiesDevicePanel.Visible = propertiesDevicePanel.Enabled = false;

                statusBar.ForeColor = Color.Red;

                statusBar.Text = "Connection not established";
            }
        }

        #endregion

        #region GUI Event Handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            wrapper.deviceDDC2PreprocessedStreamReceived += new Wrapper.DeviceDDC2PreprocessedStreamReceivedHandler(OnWrapperDDC2PreprocessedStreamReceived);

            wrapper.deviceAudioStreamReceived += new Wrapper.DeviceAudioStreamReceivedHandler(OnWrapperAudioStreamReceived);

            InitializeDeviceConnection();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerConnection.Stop();

            if (waveOutHandler.isOpened)
            {
                waveOutHandler.Close();
            }

            if (wrapper.IsDeviceConnected())
            {
                wrapper.CloseDevice();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeDeviceConnection();
        }

        private void timerConnection_Tick(object sender, EventArgs e)
        {
            HandleDeviceConnection();
        }

        private void frequencyTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (wrapper.IsDeviceConnected())
            {
                wrapper.SetFrequency((UInt32)frequencyTrackBar.Value);
                UInt32 aFrequency = wrapper.GetFrequency();
                frequencyUDBox.Value = aFrequency;
            }
        }

        private void frequencyUDBox_ValueChanged(object sender, EventArgs e)
        {
            frequencyTrackBar.Value = (int)frequencyUDBox.Value;
        }

        #endregion

        #region Wrapper Event Handlers
        
        private void OnWrapperDDC2PreprocessedStreamReceived(object sender, EventArgs eventArgs)
        {
            if (!InvokeRequired)
            {
                DDC2PreprocessedStreamEventArgs anEventArgs = (DDC2PreprocessedStreamEventArgs)eventArgs;

                double currentSignalLeveldBm    =   (10.0 * Math.Log10(Math.Pow(anEventArgs.sLevelRms, 2) * (1000.0 / 50.0)));

                signalLevelTextBox.Text         =   currentSignalLeveldBm.ToString();

                
                //signalLevelProgressBar.Value    =   (int)((currentSignalLeveldBm + 220) * 10);
            }
            else
            {
                WrapperDD2PreprocessedStreamCallbackHandler aWrapperHandler = new WrapperDD2PreprocessedStreamCallbackHandler(OnWrapperDDC2PreprocessedStreamReceived);
                object aSender = Thread.CurrentThread;

                BeginInvoke(aWrapperHandler, new object[] { aSender, eventArgs });
            }
        }
        private void OnWrapperAudioStreamReceived(object theSender, EventArgs theEventArgs)
        {
            if (!waveOutHandler.isOpened)
            {
                return;
            }

            // If method was called from the same thread, handle received data
            if (!InvokeRequired)
            {

                AudioStreamEventArgs anEventArgs = (AudioStreamEventArgs)theEventArgs;

                // Display audio level
                int aValue = 0;
                for (int anIx = 0; anIx < anEventArgs.numberOfSamples; anIx++)
                {
                    aValue = (int)Math.Max(aValue, 100 * Math.Abs(anEventArgs.buffer[anIx]));
                }
                //progressBarAudioLevel.Value = aValue < progressBarAudioLevel.Maximum ? aValue : progressBarAudioLevel.Maximum;

                // Write to waveOut
                waveOutHandler.Write(anEventArgs.buffer, anEventArgs.numberOfSamples);


            }
            // Else, if this method was called from API thread, call it again from the same thread 
            else
            {
                // Prepare calling the method from the same thread
                WrapperAudioStreamCallbackHandler aWrapperHandler = new WrapperAudioStreamCallbackHandler(OnWrapperAudioStreamReceived);
                object aSender = Thread.CurrentThread;

                BeginInvoke(aWrapperHandler, new object[] { aSender, theEventArgs });
            }
        }
        #endregion

    }
}
