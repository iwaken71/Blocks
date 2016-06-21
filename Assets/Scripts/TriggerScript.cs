using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
	int x,y;

	// Use this for initialization
	void Start () {
		x = (int)transform.position.x;
		y = (int)(transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	public int GetX(){
		return x;
	}
	public int GetY(){
		return y;
	}
}
