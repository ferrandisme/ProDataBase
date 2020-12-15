using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static PDBCore;

public class DataManager
{
    string path;
    public DataManager(string name)
    {
        path = Application.persistentDataPath + "/DataManager/" + name + "/";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    public void Add(string name, System.Object data)
    {
        DefaultSave<System.Object>(name, data, path + name + ".pdb");
    }

    public E Get<E>(string name)
    {
        if (File.Exists(path + name + ".pdb"))
            return DefaultLoad<E>(path + name + ".pdb");
        else
            throw new Exception("File does not exists");
    }
}
