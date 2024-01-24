using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform player; // 추적할 게임 오브젝트
    public float dist = 10.0f; // 카메라와의 일정 거리
    public float height = 5.0f; // 카메라 높이 설정
    public float dampTrace = 20.0f; // 부드러운 추적을 위한 변수


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position - (player.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
        transform.LookAt(player);
    }
}
