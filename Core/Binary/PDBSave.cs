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
using static PDBCore;

public static class PDBSave
{

    public static void Save(string name, System.Object item)
    {
       DefaultSave<System.Object>(name, item);
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

}

