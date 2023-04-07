using System;
using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.Managers;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class BallGlassController : GameActor<GameManager>
{
    private int ballAmount;
    [SerializeField] private Pool _pool;
    private int ballCounter;

    public override void ActorStart()
    {
        ballAmount = DataManager.Instance.levelCapsule.Levels[GameManager.Instance.runtime.currentLevelIndex]
            .BallCount;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballCounter++;
            MMVibrationManager.Haptic(HapticTypes.LightImpact, false, true, this);
            _pool.BackToThePool(other.gameObject);
            if (ballCounter == ballAmount)
            {
                //admob inters atılacak
                GameManager.Instance.FinishLevel(true);
                GameManager.Instance.NextLevel();
            }
        }
    }
}