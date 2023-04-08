using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.EventBehaviour.Attributes;
using Fenrir.Managers;
using UnityEngine;


public class BallManager : GameActor<GameManager>
{
    [SerializeField] private Pool _pool;

    private int ballAmount;
    internal int ballCounter;

    public override void ActorStart()
    {
        
        ballAmount = DataManager.Instance.levelCapsule.Levels[GameManager.Instance.runtime.currentLevelIndex]
            .BallCount;
        _pool = DataManager.Instance.levelCapsule.Levels[GameManager.Instance.runtime.currentLevelIndex].LevelPrefab
            .GetComponent<CustomLevelActor>()._pool;
    }

    [GE(Constants.BALLCOUNTEREVENT)]
    private void BallCounter()
    {
        ballCounter++;
        GameManager.Instance.PushEvent(Constants.FXEVENT);
        if (ballCounter == ballAmount)
        {
            ballCounter = 0;
            DataManager.Instance.adManager.ShowInterstitial();
            GameManager.Instance.PushEvent(Constants.LEVELENDEVENT);
        }
    }
}