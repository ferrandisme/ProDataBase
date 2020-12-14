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
        [SetUp]
        public void SetUP() {
            Debug.Log("Testing  on path:" + Application.persistentDataPath);
        }

        [UnityTest]
        public IEnumerator SaveLoadInt()
        {
            PDBSave.Save("IntTest", 5);
            Assert.AreEqual(PDBLoad.Load("intTest", -1), 5);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SaveLoadString()
        {
            PDBSave.Save("StringTest", "my Test");
            Assert.AreEqual(PDBLoad.Load("StringTest",""), "my Test");
            yield return null;
        }

        [UnityTest]
        public IEnumerator SaveLoadBool()
        {
            PDBSave.Save("BoolTest", false);
            Assert.AreEqual(PDBLoad.Load("BoolTest",false), false);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SaveLoadVector2()
        {
            Vector2 vector = new Vector2(24, -39);
            PDBSave.Save("Vector2Test", vector);
            Vector2 newVector = PDBLoad.LoadVector2("Vector2Test");
            Assert.AreEqual(newVector.x, vector.x);
            Assert.AreEqual(newVector.y, vector.y);
            yield return null;
        }
    }
}
