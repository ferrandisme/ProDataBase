using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int exp;
    public float[] position;

    public PlayerData(Player p){
        health = p.health;
        exp = p.exp;
        position[0] = p.transform.position.x;
        position[1] = p.transform.position.y;
        position[1] = p.transform.position.z;
    }
}
