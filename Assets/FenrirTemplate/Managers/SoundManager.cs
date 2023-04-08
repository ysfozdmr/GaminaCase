using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.EventBehaviour.Attributes;
using Fenrir.Managers;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class SoundManager : GameActor<GameManager>
{
    private AudioSource Audio;
    public override void ActorStart()
    {
        Audio = GetComponent<AudioSource>();
    }

    [GE(Constants.FXEVENT)]
    private void FXEvent()
    {
        MMVibrationManager.Haptic(HapticTypes.LightImpact, false, true, this);
        Audio.PlayOneShot(Audio.clip);
    }
}
