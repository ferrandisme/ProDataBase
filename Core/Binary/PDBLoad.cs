using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
using UnityEditor.UIElements;
using NUnit.Framework;
using System.Collections;
using System;

public static class PDBLoad
{
    // Start is called before the first frame update
    public static System.Object Load(string name, System.Object def)
    {
        string path = Application.persistentDataPath + "/" + name + ".pdb";
        if (File.Exists(path)) 
            return DefaultLoad<System.Object>(path);
        else
            return def;
    }

    private static E DefaultLoad<E>(string path)
    {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            E result = (E)formatter.Deserialize(stream);
            stream.Close();
            return result;
    }

    public static Vector2 Load(string name, Vector2 def)
    {
        string path = Application.persistentDataPath + "/" + name + ".pdb";
        if (File.Exists(path))
            return LoadVector2(name);
        else
            return def;
    }

    public static Vector2 LoadVector2(string name)
    {
        string path = Application.persistentDataPath + "/" + name + ".pdb";
        float[] pos = DefaultLoad<float[]>(path);
        return new Vector2(pos[0], pos[1]);
    }

}
