using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    private KeyCode shootKey = KeyCode.A;


    public float canSlowTimeTimes;
    [SerializeField] float maxCanSlowTimeTimes;
    public bool youMayStopTime;
    private float slowMoTime;
    public float haveTimeToTimeStop;
    [SerializeField] public float maxHaveTimeToTimeStop=6f;
    [SerializeField] float maxSlowMoTime = 0.9f;
    [SerializeField] float minSlowMoTime = 0.015f;
    [SerializeField] float decayRate = 0.025f; //if this is too high,stop time lenght will be short
    [SerializeField] float timeToEnterSlowMotion = 0.01f;  //if this is high,you will enter slowmo faster
    public bool canDash;
    public bool decrementCanSlowTimeCount1=false;
    public bool check;
    

    public float timeToEnterAfterPress = 0.15f; //dont change;
    public float timeAfterPress;
    public float timeOutPress;
    

    BasicControl basicControl;
    public DashToEnemy dashToEnemy;
    void Start()
    {
        dashToEnemy=GetComponent<DashToEnemy>();
        basicControl = GetComponent<BasicControl>();
        haveTimeToTimeStop = maxHaveTimeToTimeStop;
        decrementCanSlowTimeCount1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timeAfterPress);
        
        if(Input.GetKey(shootKey))
        {
            timeAfterPress += Time.deltaTime;
            timeOutPress += Time.deltaTime;

            if (timeAfterPress>=timeToEnterAfterPress)
            {
                PressTheKey();

                if (decrementCanSlowTimeCount1==true)
                {
                    decrementCanSlowTimeCount1 = false;
                    canSlowTimeTimes--;
                }  

                




            }
            



        }
        /*if(check==true)
        {
            decrementCanSlowTimeCount1 = true;
            Debug.Log("fkfkalfflak");

        }
        if(check==false)
        {
            timeAfterPress = 0;
        }*/
       
       

       
        if(Input.GetKeyUp(shootKey))
        {
            if(timeAfterPress<=timeToEnterAfterPress)
            {
                timeAfterPress = 0;
                
            }


            decrementCanSlowTimeCount1 = true;
            timeOutPress = 0;
            haveTimeToTimeStop = 0;
            youMayStopTime = false;
            if (haveTimeToTimeStop == 0)
            {

                Invoke("RefillLenghtSoYouCanStopTimeAgain", 0.02f);
            }
        }
        

        if (basicControl.isGrounded == true)
        {
            canSlowTimeTimes = maxCanSlowTimeTimes+1;
        }
        if (youMayStopTime == false)
        {

            StopTimeStop();
        }

        
        
    }
   
    
    
    public void PressTheKey()
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

    private void CountDownSoYouCanStopTimeAtThisLenght()
    {
        haveTimeToTimeStop -= decayRate;
        if(haveTimeToTimeStop > 0)
        {
            canDash = true;
            youMayStopTime =true;
        }
        else if(haveTimeToTimeStop<=0)
        {
            canDash = false;
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
    
    
}
