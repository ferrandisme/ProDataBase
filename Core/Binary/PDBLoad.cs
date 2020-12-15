using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
using UnityEditor.UIElements;
using NUnit.Framework;
using System.Collections;
using System;
using static PDBSave;

public static class PDBLoad
{
    public static String GetPath(String name)
    {
        return Application.persistentDataPath + "/" + name + ".pdb";
    }
    public static System.Object Load(string name, System.Object def)
    {
        if (File.Exists(GetPath(name))) 
            return DefaultLoad<System.Object>(GetPath(name));
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
        if (File.Exists(GetPath(name)))
            return LoadVector2(name);
        else
            return def;
    }

    public static Vector2 LoadVector2(string name)
    {
        float[] pos = DefaultLoad<float[]>(GetPath(name));
        return new Vector2(pos[0], pos[1]);
    }

    public static Vector3 Load(string name, Vector3 def)
    {
        if (File.Exists(GetPath(name)))
            return LoadVector3(name);
        else
            return def;
    }

    public static Vector3 LoadVector3(string name)
    {
        float[] pos = DefaultLoad<float[]>(GetPath(name));
        return new Vector3(pos[0], pos[1], pos[2]);
    }

    public static Transform Load(string name, Transform def)
    {
        if (File.Exists(GetPath(name)))
            return LoadTransform(name);
        else
            return def;
    }

    public static Transform LoadTransform(string name)
    {
        STransform structure = DefaultLoad<STransform>(GetPath(name));
        GameObject o = new GameObject();
        Transform t = o.transform;
        t.localPosition = new Vector3(structure.pos[0], structure.pos[1], structure.pos[2]);
        t.localRotation = new Quaternion(structure.pos[3], structure.pos[4], structure.pos[5], structure.pos[6]);
        t.localScale = new Vector3(structure.pos[7], structure.pos[8], structure.pos[9]);
        return t;
    }

    
}
