using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.Managers;
using Fenrir.Resources;
using UnityEngine;

public class CustomLevelActor : LevelActor
{
    [SerializeField] internal Transform SpawnTransform;
    [SerializeField] private Pool _pool;
    private GameObject ball;

    public override void SetupLevel()
    {
        int ballAmount = DataManager.Instance.levelCapsule.Levels[GameManager.Instance.runtime.currentLevelIndex]
            .BallCount;
        for (int i = 0; i < ballAmount; i++)
        {
            ball = _pool.SpawnBallFromPool(SpawnTransform.position, Quaternion.identity);
            ball.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        }
    }
}