using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
using UnityEditor.UIElements;
using NUnit.Framework;
using System.Collections;
using System;

public class PDBLoad<E>
{
    // Start is called before the first frame update
    public static E Load(string name)
    {
        return DefaultLoad(name);
    }

    private static E DefaultLoad(string name)
    {
        string path = Application.persistentDataPath + "/" + name + ".data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            E result = (E)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
        else
        {
            throw new System.Exception("Save file not found " + path);
        }
    }
}
