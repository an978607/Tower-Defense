using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LivesTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void LivesShouldNotFallBelowZero()
        {
            GameObject go = new GameObject();
            var playerLives = go.AddComponent<LivesManager>().currentLivesRef;
            Assert.GreaterOrEqual(playerLives, 0);
        }
    }
}
