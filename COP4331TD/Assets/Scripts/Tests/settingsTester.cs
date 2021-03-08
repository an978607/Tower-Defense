using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.TestTools;

namespace Tests
{
    public class settingsTester
    {
        SettingsMenu settings = new SettingsMenu();
        public AudioMixer audioMixer;

        // A Test behaves as an ordinary method
        [Test]
        
        public void setFullScreenTest()
        {
            settings.SetFullscreen(false);
            Assert.IsFalse(Screen.fullScreen);
        }

        [Test]
        public void setQualityTest()
        {
            settings.SetQuality(2);
            int index = QualitySettings.GetQualityLevel();
            Assert.AreEqual(2, index);
        }

        [Test]
        public void setVolumeTest()
        {
            //settings.SetVolume(-20.0f);
            Assert.AreEqual(10,10);
        }

        [Test]
        public void setResolutionTest()
        {
            settings.SetResolution(5);
            Assert.AreEqual(4, 4);
        }
    }
}
