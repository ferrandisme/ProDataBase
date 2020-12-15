﻿using System;
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
            Vector2 vector = new Vector2(24.2f, -39.5f);
            PDBSave.Save("Vector2Test", vector);
            Vector2 newVector = PDBLoad.LoadVector2("Vector2Test");
            Assert.AreEqual(newVector.x, vector.x);
            Assert.AreEqual(newVector.y, vector.y);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SaveLoadVector3()
        {
            Vector3 vector = new Vector3(-324.2f, -339.5f, 0.1f);
            PDBSave.Save("Vector3Test", vector);
            Vector3 newVector = PDBLoad.LoadVector3("Vector3Test");
            Assert.AreEqual(newVector.x, vector.x);
            Assert.AreEqual(newVector.y, vector.y);
            Assert.AreEqual(newVector.z, vector.z);
            yield return null;
        }


        [UnityTest]
        public IEnumerator SaveLoadTransform()
        {
            GameObject o = new GameObject();
            Transform t = o.transform;
            t.position = new Vector3(1, 2, 3);
            t.rotation = new Quaternion(1f, 0.5f, 0.25f, 0.1f);

            PDBSave.Save("TransformTest", t);
            Transform newTransform = PDBLoad.LoadTransform("TransformTest");
            Assert.AreEqual(t.localPosition.x, newTransform.localPosition.x);
            Assert.AreEqual(t.localPosition.y, newTransform.localPosition.y);
            Assert.AreEqual(t.localPosition.z, newTransform.localPosition.z);
            Assert.AreEqual(t.localRotation.x, newTransform.localRotation.x);
            Assert.AreEqual(t.localRotation.y, newTransform.localRotation.y);
            Assert.AreEqual(t.localRotation.z, newTransform.localRotation.z);
            Assert.AreEqual(t.localRotation.w, newTransform.localRotation.w);
            Assert.AreEqual(t.localScale.x, newTransform.localScale.x);
            Assert.AreEqual(t.localScale.y, newTransform.localScale.y);
            Assert.AreEqual(t.localScale.z, newTransform.localScale.z);
            yield return null;
        }
    }
}
