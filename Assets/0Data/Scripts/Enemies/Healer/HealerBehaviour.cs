using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerBehaviour : EnemysBehavior
{
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartStatus();
        CalculateFireRate();
        shipTransform = GameObject.Find("AllShip").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateMove();

        if (currentFireDelayTime > fireDelayTime)
        {
            
            Shoot(bullet);
            currentBulletsToRecharg--;
            currentFireDelayTime = 0;
        }
        else
        {
            currentFireDelayTime += Time.deltaTime * GameManager.Instance.gameTime;
        }
    }

    void RotateMove()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime * GameManager.Instance.gameTime, 0);
    }

    void CalculateFireRate()
    {
        fireDelayTime = 1 / status[level - 1].fireRate;
    }
}
