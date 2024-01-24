using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class serial_test : MonoBehaviour {
	SerialPort sp = new SerialPort("COM7", 9600);
	string val = ""; // 데이터를 받아온다
	float output = 0; // 숫자로 변경

	int St_int = 0;
	int sum = 0;
	int count = 0;
	float res = 0;
	

	void Start () {
		sp.Open ();
	}
	// Update is called once per frame
	public float dataRead () {
		val = sp.ReadLine ();//EMG데이터 읽어들이기
		output = int.Parse (val);//문형의 데터를 int형으로 변환

		return output;
	}
}
