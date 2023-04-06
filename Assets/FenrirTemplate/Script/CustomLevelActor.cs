using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using UnityEngine;

public class CustomLevelActor : LevelActor
{
    [SerializeField] internal Transform SpawnTransform;
    [SerializeField] internal GameObject Prefab;

    public override void SetupLevel()
    {
        // ball pool
       
        Instantiate(Prefab,SpawnTransform.position,Quaternion.identity);
        
    }
}
