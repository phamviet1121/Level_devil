using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap8 : MonoBehaviour
{
    public GameObject gameobj_ball;
    public GameObject point;
    public void SpammBallA()
    {
        GameObject NewgameobjBall = Instantiate(gameobj_ball, point.transform.position, Quaternion.identity);
        RollingBall rollingBall = NewgameobjBall.GetComponent<RollingBall>();
        rollingBall.rolli_right();

    }
    public void SpammBallB()
    {
        GameObject NewgameobjBall = Instantiate(gameobj_ball, point.transform.position, Quaternion.identity);
        RollingBall rollingBall = NewgameobjBall.GetComponent<RollingBall>();
        rollingBall.rolli_left();

    }
}
