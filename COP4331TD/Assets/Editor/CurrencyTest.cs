using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CurrencyTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CurrencyShouldNotFallBelowZero()
        {
            GameObject go = new GameObject();
            var playerBalance = go.AddComponent<CurrencyManager>().currentBalanceRef;
            Assert.GreaterOrEqual(playerBalance, 0);
        }
    }
}