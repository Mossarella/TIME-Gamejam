using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    private KeyCode shootKey = KeyCode.A;


    public bool youMayStopTime;
    private float slowMoTime;
    private float haveTimeToTimeStop;
    [SerializeField] float maxHaveTimeToTimeStop=4f;
    [SerializeField] float maxSlowMoTime = 0.2f;
    [SerializeField] float minSlowMoTime = 0.1f;
    [SerializeField] float decayRate = 0.05f; //if this is too high,stop time lenght will be short

    
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(shootKey))
        {
            CountDownSoYouCanStopTimeAtThisLenght();
            if (youMayStopTime==true)
            {
                TimeStop();
            }

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
        if (youMayStopTime==false)
        {
            
            stopTimeStop();
        }
        Debug.Log(haveTimeToTimeStop);
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
    private void RefillLenghtSoYouCanStopTimeAgain()
    {
        haveTimeToTimeStop = maxHaveTimeToTimeStop;
    }

    

    private void stopTimeStop()
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
            slowMoTime -=0.045f;
        }
    }
}
