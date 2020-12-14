using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
using UnityEditor.UIElements;
using NUnit.Framework;
using System.Collections;
using System;

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
        Debug.Log("Saving on... " + path);
        FileStream stream = new FileStream(path, FileMode.Create);
        //PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, item);
        stream.Close();
    }

    public static void Save(string name, Vector2 item)
    {
        float[] pos = new float[] { item.x, item.y };
        DefaultSave<System.Object>(name, pos);
    }
}

