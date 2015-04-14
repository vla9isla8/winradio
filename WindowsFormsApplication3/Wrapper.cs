using G31DDCAPIWrapperSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication3
{
    class Wrapper
    {
        #region Members

        public G31DDCAPIWrapper apiWrapper = new G31DDCAPIWrapper();
        public G31DDCAPIWrapperDeviceInfo deviceInfo;
        //public String deviceSerialNumber;
        
        public UInt32 apiStatus;

        public static String APIWRAPPERLIBRARY = G31DDCAPIWrapper.APILIBRARY;
        public static UInt32 APISTATUS_WRAPPERLIBRARY_LOADED = G31DDCAPIWrapper.STATUS_APILIBRARY_LOADED;
        public static UInt32 APISTATUS_WRAPPERLIBRARY_NOTFOUND = G31DDCAPIWrapper.STATUS_APILIBRARY_NOT_FOUND;

        public delegate void DeviceDDC2PreprocessedStreamReceivedHandler(object sender, EventArgs eventArgs);
        public event DeviceDDC2PreprocessedStreamReceivedHandler deviceDDC2PreprocessedStreamReceived;
        public delegate void DeviceAudioStreamReceivedHandler(object sender, EventArgs eventArgs);
        public event DeviceAudioStreamReceivedHandler deviceAudioStreamReceived;

        #endregion

        #region Public Methods

        public unsafe bool Init()
        {
            apiStatus = apiWrapper.GetStatus();
            if (apiStatus != APISTATUS_WRAPPERLIBRARY_LOADED)
            {
                return false;
            }

            if (apiWrapper.Enumerate() == 0)
            {
                return false;
            }

            if (apiWrapper.Open() == 0)
            {
                return false;
            }

            deviceInfo = new G31DDCAPIWrapperDeviceInfo();
            deviceInfo.serialNumber = apiWrapper.GetSerialNumber();
            deviceInfo.devicePath = apiWrapper.GetDevicePath();
            deviceInfo.interfaceType = apiWrapper.GetInterfaceType();

            // Set callback handlers
            G31DDCAPIWrapper.DDC2PreprocessedStreamCallback ddc2PreprocessedStreamCallback = OnDDC2PreprocessedStreamReceived;
            G31DDCAPIWrapper.AudioStreamCallback audioStreamCallback = OnAudioStreamReceived;
            apiWrapper.RegisterCallbacks(ddc2PreprocessedStreamCallback, audioStreamCallback);

            // Start example
            // Start DDC1 streaming which has to be running before StartDDC2 is called
            apiWrapper.StartDDC1(1024 /* Example */);
            // Start DDC2 streaming handled in example
            apiWrapper.StartDDC2(0 /* Example */, 1024 /* Example */);
            // Start audio streaming
            apiWrapper.StartAudio(0 /* Example */, 1024 /* Example */);

            return true;
        }

        public bool IsDeviceConnected()
        {
            return apiWrapper.IsConnected() == 0 ? false : true;
        }

        public void CloseDevice()
        {
            apiWrapper.StopAudio(0 /* Example */);
            apiWrapper.StopDDC2(0 /* Example */);
            apiWrapper.StopDDC1();

            apiWrapper.Close();
        }

        public void SetFrequency(UInt32 theFrequency)
        {
            apiWrapper.SetFrequency(0 /* Example */, theFrequency);
        }

        public unsafe UInt32 GetFrequency()
        {
            UInt32 aFrequency = 0;
            UInt32* aFrequencyPtr = &aFrequency;
            apiWrapper.GetFrequency(0 /* Example */, aFrequencyPtr);

            return aFrequency;
        }

        #endregion

        #region API Callback Handlers

        public unsafe void OnDDC2PreprocessedStreamReceived(UInt32 theChannel, float* theBuffer, UInt32 theNumberOfSamples, float theSLevelPeak, float theSLevelRms)
        {
            DDC2PreprocessedStreamEventArgs anEventArgs = new DDC2PreprocessedStreamEventArgs();
            anEventArgs.channel = theChannel;
            anEventArgs.numberOfSamples = theNumberOfSamples;
            anEventArgs.sLevelPeak = theSLevelPeak;
            anEventArgs.sLevelRms = theSLevelRms;
            anEventArgs.buffer = new float[theNumberOfSamples];
            // Copy buffer
            for (int anIx = 0; anIx < theNumberOfSamples; anIx++)
            {
                anEventArgs.buffer[anIx] = theBuffer[anIx];
            }

            // Fire event
            deviceDDC2PreprocessedStreamReceived(this, anEventArgs);
        }

        public unsafe void OnAudioStreamReceived(UInt32 theChannel, float* theBuffer, float* theBufferFiltered, UInt32 theNumberOfSamples)
        {
            AudioStreamEventArgs anEventArgs = new AudioStreamEventArgs();
            anEventArgs.channel = theChannel;
            anEventArgs.numberOfSamples = theNumberOfSamples;
            anEventArgs.buffer = new float[theNumberOfSamples];
            // Copy buffer
            for (int anIx = 0; anIx < theNumberOfSamples; anIx++)
            {
                anEventArgs.buffer[anIx] = theBuffer[anIx];
            }

            // Fire event
            deviceAudioStreamReceived(this, anEventArgs);
        }

        #endregion
    }
}
