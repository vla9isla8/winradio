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
        private DecimalConverter DecConv = new DecimalConverter();
        public bool initStatus      =   false;
        private int minFrequency    =   0;
        private int maxFrequency    =   0;

        private delegate void WrapperDD2PreprocessedStreamCallbackHandler(object sender, DDC2PreprocessedStreamEventArgs eventArgs);

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
                wrapper.SetFrequency(UInt32.MinValue);
                minFrequency                =   (int)wrapper.GetFrequency();
                wrapper.SetFrequency(UInt32.MaxValue);
                maxFrequency                =   (int)wrapper.GetFrequency();
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
            initStatus = wrapper.IsDeviceConnected();

            errorDevicePanel.Visible = !initStatus;

            deviceInfoPanel.Visible = propertiesDevicePanel.Visible = propertiesDevicePanel.Enabled = initStatus;
            if (initStatus)
            {
                timerConnection.Start();

                statusBar.ForeColor = Color.Green; 

                statusBar.Text = "Connected successful";

            }
            else
            {
                timerConnection.Stop();

                wrapper.CloseDevice();

                minFrequency = 0;

                statusBar.ForeColor = Color.Red;

                statusBar.Text = "Connection not established";
            }
        }

        #endregion

        #region GUI Event Handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            wrapper.deviceDDC2PreprocessedStreamReceived += new Wrapper.DeviceDDC2PreprocessedStreamReceivedHandler(OnWrapperDDC2PreprocessedStreamReceived);

            InitializeDeviceConnection();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerConnection.Stop();

            if (initStatus)
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
            if (initStatus)
            {
                wrapper.SetFrequency((UInt32)frequencyTrackBar.Value);
                frequencyUDBox.Value = wrapper.GetFrequency();
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

                signalLevelTextBox.Text         =   currentSignalLeveldBm.ToString() + " dBm";

                signalLevelProgressBar.Value    =   (int)((currentSignalLeveldBm + 70) * 10);
            }
            else
            {
                WrapperDD2PreprocessedStreamCallbackHandler aWrapperHandler = new WrapperDD2PreprocessedStreamCallbackHandler(OnWrapperDDC2PreprocessedStreamReceived);
                object aSender = Thread.CurrentThread;

                BeginInvoke(aWrapperHandler, new object[] { aSender, eventArgs });
            }
        }

        #endregion

    }
}
