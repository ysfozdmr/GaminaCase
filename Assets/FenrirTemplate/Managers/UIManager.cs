using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.Managers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : GameActor<GameManager>
{
   [SerializeField] private BallManager _ballManager;
    private int ballAmount;
   [SerializeField] private TextMeshProUGUI _levelBallAmountText;
   [SerializeField] private TextMeshProUGUI _currentBallAmountText;
    
    public override void ActorStart()
    {
        ballAmount = DataManager.Instance.levelCapsule.Levels[GameManager.Instance.runtime.currentLevelIndex]
            .BallCount;
        _levelBallAmountText.text = "/ " + ballAmount;
    }

    public override void ActorUpdate()
    {
        _currentBallAmountText.text = _ballManager.ballCounter.ToString();
    }
}
