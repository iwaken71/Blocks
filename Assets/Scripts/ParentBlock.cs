using UnityEngine;
using System.Collections;

public class ParentBlock : MonoBehaviour {
	GameObject[] children;
	BlockScript[] childScripts;
	public int color = 2;
	int state = 1; // 0 選ばれていない; 1 選ばれた, 2 置かれた

	// Use this for initialization
	void Start () {
		children = new GameObject[transform.childCount];
		childScripts = new BlockScript[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			children [i] = transform.GetChild (i).gameObject;
			children[i].transform.tag = "Block";
			childScripts[i] = children [i].AddComponent<BlockScript> ();
			childScripts [i].SetColor (color);
		}
	}

	// Update is called once per frame
	void Update () {
		if (state == 1) {
			if (Input.GetKeyDown ("r")) {
				RotateBlock ();
			}
			Vector3 pos = transform.position;
			float input_x = Input.GetAxis ("Horizontal");
			float input_z = Input.GetAxis ("Vertical");
			if (-0.95f <= input_x && input_x <= 0.95f) {
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					transform.position += Vector3.right;
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					transform.position += Vector3.left;
				}
			} else {
				if (Input.GetKey (KeyCode.RightArrow)) {
					transform.position += Vector3.right;
				}
				if (Input.GetKey (KeyCode.LeftArrow)) {
					transform.position += Vector3.left;
				}
			}
			if (-0.95f <= input_z && input_z <= 0.95f) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					transform.position += Vector3.forward;
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					transform.position += Vector3.back;
				}
			} else {
				if (Input.GetKey (KeyCode.UpArrow)) {
					transform.position += Vector3.forward;
				}
				if (Input.GetKey (KeyCode.DownArrow)) {
					transform.position += Vector3.back;
				}
			}
			Fix ();

			/*
			if (Input.GetKeyDown (KeyCode.Space)) {
				Put ();
			}*/
			/*
			Vector3 newpos = transform.position;

			if (newpos.x <= -2.5f || newpos.x >= 20.5f || newpos.z <= -2.5f || newpos.z >= 20.5f) {
				transform.position = pos;
			}*/

		}




	}
	void Fix(){
		while (true) {
			bool check = true;

			for (int i = 0; i < transform.childCount; i++) {
				if (childScripts [i].InBoard ().x <= -1) {
					transform.position += Vector3.right;
					check = false;
				}
				if (childScripts [i].InBoard ().x >= 20) {
					transform.position += Vector3.left;
					check = false;
				}
				if (childScripts [i].InBoard ().y <= -1) {
					transform.position += Vector3.forward;
					check = false;
				}
				if (childScripts [i].InBoard ().y >= 20) {
					transform.position += Vector3.back;
					check = false;
				}

			}
			if (check) {
				break;
			}
		}
	}


	bool Check(){
		bool check = false;

		for (int i = 0; i < transform.childCount; i++) {
			if (!childScripts [i].Check ()) {
				return false;
			}
		}
		for (int i = 0; i < transform.childCount; i++) {
			if (childScripts [i].StartCheck ()) {
				return true;
			}
		}
		for (int i = 0; i < transform.childCount; i++) {
			if (childScripts [i].Check2 ()) {
				check = true;
			}
		}
		return check;
	}
	void RotateBlock(){
		transform.Rotate (0,90,0);
	}
	public void Put(){
		if (Check ()) {
			state = 2;
			for (int i = 0; i < transform.childCount; i++) {
				childScripts [i].Put ();
			}
		}
	}
}
