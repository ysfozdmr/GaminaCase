using System.Collections;
using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.Managers;
using UnityEngine;

public class MazeController : GameActor<GameManager>
{
    private Vector3 firstMousePositon;
    private float currentMagnitude;

    private float _threshold;
    private int screenWidth;
    private Quaternion firstRotation;
    private Quaternion targetRotation;
    private float fullSwipeAngle;
    private float rotationSpeed;
    private float thresholdScreenDivider;

    public override void ActorAwake()
    {
        fullSwipeAngle = DataManager.Instance.GameConfiguration.FullSwipeAngle;
        rotationSpeed = DataManager.Instance.GameConfiguration.RotationSpeed;
        thresholdScreenDivider = DataManager.Instance.GameConfiguration.ThresholdScreenDivider;
    }

    public override void ActorStart()
    {
        screenWidth = Screen.width;
        _threshold = screenWidth / thresholdScreenDivider;
    }

    public override void ActorUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstMousePositon = Input.mousePosition;
            firstRotation = gameObject.transform.rotation;
        }
        else if (Input.GetMouseButton(0))
        {
            currentMagnitude = Input.mousePosition.x - firstMousePositon.x;
            if (Mathf.Abs(currentMagnitude) > _threshold)
            {
                targetRotation =
                    firstRotation * Quaternion.Euler(0, 0, currentMagnitude * fullSwipeAngle / screenWidth);
                transform.rotation =
                    Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            targetRotation = transform.rotation;
        }
    }
}