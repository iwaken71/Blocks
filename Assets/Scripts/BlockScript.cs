using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	public int color = 0;
	Renderer rend;

	// Use this for initialization
	void Awake(){
		rend = GetComponent<Renderer> ();

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// true なら board の中
	public Vector2 InBoard(){
		
		RaycastHit hit;
		//int num = 1;
		int x = 0, y = 0;
		if (Physics.Raycast (transform.position, Vector3.down, out hit, 1)) {
			if (hit.collider.tag == "Trigger") {
				x = (int)hit.transform.position.x;
				y = (int)hit.transform.position.z;

			} 
				
		} 
		return new Vector2(x,y);
	}

	public bool Check(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit, 1)) {
			if (hit.collider.tag == "Trigger") {
				int x = (int)hit.transform.position.x;
				int y = (int)hit.transform.position.z;
				if (!BoardManager.instance.CanPut1 (x, y, color)) {
					return false;
				}
			}
		} else {
			return false;
		}
		return true;
	}
	public bool Check2(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit, 1)) {
			if (hit.collider.tag == "Trigger") {
				int x = (int)hit.transform.position.x;
				int y = (int)hit.transform.position.z;

				if (BoardManager.instance.CanPut2 (x, y, color)) {
					return true;
				}
			}
		} else {
			return false;
		}
		return false;
	}

	public bool StartCheck(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit, 1)) {
			if (hit.collider.tag == "Trigger") {
				int x = (int)hit.transform.position.x;
				int y = (int)hit.transform.position.z;
				if ((x == 0 && (y == 0 || y == 19)) || x == 19 && (y == 0 || y == 19)) {
					return true;
				}
			}
		}
		return false;
	}


	public void SetColor(int num){
		switch (num) {
		case 1: // red
			color = 1;
			rend.material.color = Color.red;
			break;
		case 2: // blue
			color = 2;
			rend.material.color = Color.blue;
			break;
		case 3: // yellow
			color = 3;
			rend.material.color = Color.yellow;
			break;
		case 4: // green
			color = 4;
			rend.material.color = Color.green;
			break;
		default:
			color = 0;
			rend.material.color = Color.white;
			break;
		}
	}
	public void Put(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit, 1)) {
			if (hit.collider.tag == "Trigger") {
				int x = (int)hit.transform.position.x;
				int y = (int)hit.transform.position.z;
				if (x >= 0 && x < 20 && y >= 0 && y < 20) {
					BoardManager.instance.WriteBoard (x, y, color);
				}
			}
		}
	}
}
