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
    //[SerializeField] private AdManager _adManager;

    public override void ActorStart()
    {
        ballAmount = DataManager.Instance.levelCapsule.Levels[GameManager.Instance.runtime.currentLevelIndex]
            .BallCount;
    }

    IEnumerator LevelEnd()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.FinishLevel(true);
        GameManager.Instance.NextLevel();
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
                DataManager.Instance.adManager.ShowInterstitial();
                StartCoroutine(LevelEnd());
            }
        }
    }
}