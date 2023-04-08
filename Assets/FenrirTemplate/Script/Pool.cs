using System.Collections.Generic;
using Fenrir.Actors;
using Fenrir.Managers;
using UnityEngine;


public class Pool : GameActor<GameManager>
{
     #region BallPool
    Stack<GameObject> balls = new Stack<GameObject>();
    
    [SerializeField] private GameObject ballPrefab;
    private GameObject ball;

    int generatedBallCount;

    #endregion
    
    void Start()
    {
        StartMethods();
    }

    #region StartMethods

    void StartMethods()
    { 
        GenerateBall(50);
    }



    #endregion
    
    void GenerateBall(int agentCount)
    {
        for (int i = 0; i < agentCount; i++)
        {
            ball = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            ball.name = "Agent" + generatedBallCount.ToString();
            generatedBallCount++;
            balls.Push(ball);
            ball.SetActive(false);
        
        }
    }

    public GameObject SpawnBallFromPool(Vector3 spawnPosition, Quaternion spawnRotation )
    {
        if (balls.Count < 1)
        {
            GenerateBall(10);
        }
        ball = balls.Pop();
        ball.transform.SetParent(gameObject.transform);
        ball.transform.position = spawnPosition;
        ball.transform.rotation = spawnRotation;
        ball.SetActive(true);
        return ball;
    }
    
    public void BackToThePool(GameObject particleCubeObject)
    {
        ball = particleCubeObject;
        ball.SetActive(false);
        ball.transform.SetParent(gameObject.transform);
        balls.Push(ball);
    }
    
    
    
}
