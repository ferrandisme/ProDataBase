using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PDBCore
{
    public static void DefaultSave<E>(string name, E item)
    {
        string path = Application.persistentDataPath + "/" + name + ".pdb"; //.data is trivial and can be changed to any file type
        DefaultSave<E>(name, item, path);
    }

    public static void DefaultSave<E>(string name, E item, string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, item);
        stream.Close();
    }

    public static E DefaultLoad<E>(string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        E result = (E)formatter.Deserialize(stream);
        stream.Close();
        return result;
    }

    [System.Serializable]
    public struct STransform //add parent?
    {
        public float[] pos { get; }
        public STransform(Transform transform)
        {
            pos = new float[10];
            pos[0] = transform.localPosition.x; pos[1] = transform.localPosition.y; pos[2] = transform.localPosition.z;
            pos[3] = transform.localRotation.x; pos[4] = transform.localRotation.y; pos[5] = transform.localRotation.z; pos[6] = transform.localRotation.w;
            pos[7] = transform.localScale.x; pos[8] = transform.localScale.y; pos[9] = transform.localScale.z;
        }
    }

    public static void Remove(string name)
    {
        string path = Application.persistentDataPath + "/" + name + ".pdb";
        File.Delete(path);
    }
}
