using System;
using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.Managers;
using UnityEngine;


public class BallGlassController : GameActor<GameManager>
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.PushEvent(Constants.BALLCOUNTEREVENT);
        }
    }
}