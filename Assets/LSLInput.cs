using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;


public class LSLInput : MonoBehaviour
{
    public string StreamType = "Band-Power";
    public float scaleInput = 0.001f;

    StreamInfo[] streamInfos;
    StreamInlet streamInlet;

    float[] sample;
    private int channelCount = 0;

    // 표정변화 관련
    public Animator anim;
    string feeling;

    void Update()
    {
        // 인렛이 없으면 만들어주기 위한 block
        if (streamInlet == null)
        {
            streamInfos = LSL.LSL.resolve_stream("type", StreamType, 1, 0.0);   // type, EEG, 1(받아올 최대 채널 수), 0(타임아웃 기준)

            // 스트림 정보가 뭐라도 있으면
            if (streamInfos.Length > 0) 
            {
                streamInlet = new StreamInlet(streamInfos[0]);
                channelCount = streamInlet.info().channel_count();  // 인렛이 받은 정보서 채널 개수를 읽어보고
                streamInlet.open_stream();
            }
        }

        // 인렛이 만들어 졌다면
        if (streamInlet != null)
        {
            sample = new float[channelCount];   // 채널 개수 길이의 float 배열, sample 

            double lastTimeStamp = streamInlet.pull_sample(sample, 0.0f);
            if (lastTimeStamp != 0.0)
            {
                Process(sample, lastTimeStamp);
                while ((lastTimeStamp = streamInlet.pull_sample(sample, 0.0f)) != 0)
                {
                    Process(sample, lastTimeStamp);
                }
            }
        }
    }


    float[] oldSample;
    void Process(float[] newSample, double timeStamp)
    {
        if (oldSample == null)  // 초견고로시 방지, 처음 비어있는 sample을 채워져서 에러안나게해줌.
            oldSample = newSample;

        Debug.Log("p7/betaL : " + newSample[28] + " p7/betaH " + newSample[29]);
        Debug.Log("p8/betaL : " + newSample[43] + " p8/betaH " + newSample[44]);


        if (((newSample[28] + newSample[43]) / 2) > 100.0)
        //feeling = "eye_close@unitychan";
        {
            //EEG_Control(true);
        }
/*        else
        {
            anim.SetFloat("EEG_Act", 0);
            feeling = "default@unitychan";

        }*/


        //anim.CrossFade(feeling, 0); // 이놈이 점프시키는 장본인

        /*
        var inputVelocity = new Vector3( scaleInput * (oldSample[28] - newSample[28]) , scaleInput * (oldSample[43] - newSample[43]), 0);
        gameObject.transform.position = gameObject.transform.position + inputVelocity;
        */

        oldSample = newSample;
    }
}

// p7/theta = [26], p8/theta = [41].
// theta, alpha, betaL, betaH, gamma
/*
  
p7 betaL : 28 // p7 betaH : 29
p8 betaL : 43 // p8 betaH : 44

 */