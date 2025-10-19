using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap7 : MonoBehaviour
{
    public speed_ speed_;
    public float speed;
    public float addspeed;
    public float decelerationSpeed;
    public float jump;
    public float addjump;
    private void Start()
    {
        speed = speed_.speed;
        jump=speed_.jumpForce;
    }
    public void addJumpSpeed()
    {
        speed_.jumpForce = addjump;
    }
    public void resetJumpSpeed()
    {
        speed_.jumpForce = jump;
    }
    public void addspeedMover()
    {
        speed_.speed = addspeed;
    }   
    public void resetSpeedMover()
    {
        speed_.speed = speed;
    }
    public void decelerationSpeedMover()
    {
        speed_.speed = decelerationSpeed;
    }    
}
