using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BinCoreTest
    {
        [UnityTest]
        public IEnumerator SaveLoadInt()
        {
            PDBSave.Save("intTest", 5);
            Assert.AreEqual(PDBLoad<int>.Load("intTest"), 5);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SaveLoadString()
        {
            PDBSave.Save("StringTest", "my Test");
            Assert.AreEqual(PDBLoad<string>.Load("StringTest"), "my Test");
            yield return null;
        }

        [UnityTest]
        public IEnumerator SaveLoadBool()
        {
            PDBSave.Save("BoolTest", false);
            Assert.AreEqual(PDBLoad<bool>.Load("BoolTest"), false);
            yield return null;
        }
    }
}
