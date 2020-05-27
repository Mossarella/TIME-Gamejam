using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    private KeyCode shootKey = KeyCode.A;


    private float canSlowTimeTimes;
    [SerializeField] float maxCanSlowTimeTimes;
    public bool youMayStopTime;
    private float slowMoTime;
    private float haveTimeToTimeStop;
    [SerializeField] float maxHaveTimeToTimeStop=6f;
    [SerializeField] float maxSlowMoTime = 0.9f;
    [SerializeField] float minSlowMoTime = 0.015f;
    [SerializeField] float decayRate = 0.025f; //if this is too high,stop time lenght will be short
    [SerializeField] float timeToEnterSlowMotion = 0.01f;  //if this is high,you will enter slowmo faster

    BasicControl basicControl;
    public DashToEnemy dashToEnemy;
    void Start()
    {
        dashToEnemy=GetComponent<DashToEnemy>();
        basicControl = GetComponent<BasicControl>();
        haveTimeToTimeStop = maxHaveTimeToTimeStop;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(shootKey))
        {
            
                




                CountDownSoYouCanStopTimeAtThisLenght();
                if (youMayStopTime == true)
                {
                    if (canSlowTimeTimes > 0)
                    {
                        TimeStop();
                    }
                }
            
            

        }
        if(Input.GetKeyDown(shootKey))
        {
            canSlowTimeTimes--;
        }
        if(Input.GetKeyUp(shootKey))
        {
            haveTimeToTimeStop = 0;
            youMayStopTime = false;
            if(haveTimeToTimeStop==0)
            {
                
                Invoke("RefillLenghtSoYouCanStopTimeAgain",0.02f);
            }
        }
        if(basicControl.isGrounded == true)
        {
            canSlowTimeTimes = maxCanSlowTimeTimes;
        }
        if (youMayStopTime==false)
        {
            
            StopTimeStop();
        }
        //Debug.Log(canSlowTimeTimes);

        CanStopTimeAgainAfterDash();
    }

    private void CountDownSoYouCanStopTimeAtThisLenght()
    {
        haveTimeToTimeStop -= decayRate;
        if(haveTimeToTimeStop > 0)
        {
            youMayStopTime=true;
        }
        else if(haveTimeToTimeStop<=0)
        {
            youMayStopTime = false;
        }
    }
    public void RefillLenghtSoYouCanStopTimeAgain()
    {
        haveTimeToTimeStop = maxHaveTimeToTimeStop;
    }




    private void StopTimeStop()
    {
        Time.timeScale = 1;
        slowMoTime = maxSlowMoTime;
    }

    private void TimeStop()
    {
        if (slowMoTime > 0)
        {
            slowMoTime=Mathf.Clamp(slowMoTime, minSlowMoTime, maxSlowMoTime);
            Time.timeScale = slowMoTime;
            slowMoTime -= timeToEnterSlowMotion;
            
        }
    }
    public void CanStopTimeAgainAfterDash()
    {
        if (dashToEnemy.isDashing == true )
        {
            canSlowTimeTimes ++;
            RefillLenghtSoYouCanStopTimeAgain();
            
            //Debug.Log("wee");
        }
        
    }
}
