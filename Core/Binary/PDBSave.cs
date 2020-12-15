using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
using UnityEditor.UIElements;
using NUnit.Framework;
using System.Collections;
using System;
using System.Transactions;
using UnityEditorInternal;

public static class PDBSave
{

    public static void Save(string name, System.Object item)
    {
        DefaultSave<System.Object>(name, item);
    }

    private static void DefaultSave<E>(string name, E item)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + name + ".pdb"; //.data is trivial and can be changed to any file type
        FileStream stream = new FileStream(path, FileMode.Create);
        //PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, item);
        stream.Close();
    }

    public static void Save(string name, Vector2 vector)
    {
        float[] pos = new float[] { vector.x, vector.y };
        DefaultSave<float[]>(name, pos);
    }

    public static void Save(string name, Vector3 vector)
    {
        float[] pos = new float[] { vector.x, vector.y, vector.z };
        DefaultSave<float[]>(name, pos);
    }

    
    public static void Save(string name, Transform transform)
    {
        STransform item = new STransform(transform);
        DefaultSave<STransform>(name, item);
    }

    [Serializable]
    public struct STransform //add parent?
    {
        public float[] pos { get; }
        public STransform(Transform transform) {
            pos = new float[10];
            pos[0] = transform.localPosition.x; pos[1] = transform.localPosition.y; pos[2] = transform.localPosition.z;
            pos[3] = transform.localRotation.x; pos[4] = transform.localRotation.y; pos[5] = transform.localRotation.z; pos[6] = transform.localRotation.w;
            pos[7] = transform.localScale.x; pos[8] = transform.localScale.y; pos[9] = transform.localScale.z;
        }
    }
}

