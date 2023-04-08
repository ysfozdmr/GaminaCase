using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.EventBehaviour.Attributes;
using Fenrir.Managers;
using Fenrir.Resources;
using UnityEngine;

public class CustomLevelActor : LevelActor
{
    [SerializeField] internal Transform SpawnTransform;
    [SerializeField] public Pool _pool;
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

    [GE(Constants.LEVELENDEVENT)]
    private void LevelEnd()
    {
        StartCoroutine(LevelEndNum());
    }
    IEnumerator LevelEndNum()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.FinishLevel(true);
        GameManager.Instance.NextLevel();
    }
}