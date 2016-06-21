using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public int color = 1;
	GameObject[] blocks = new GameObject[21];
	ParentBlock[] script = new ParentBlock[21];
	public Camera mycamera;
	public Transform point;
	Vector3[] posi = new Vector3[21];
	int index = 0;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 21; i++) {
			blocks [i] = Resources.LoadAll ("Blocks") [i] as GameObject;
			script [i] = blocks [i].GetComponent<ParentBlock> ();
			script [i].color = color;
			Vector3 pos = point.position + point.forward * 10 * i;
			posi [i] = pos;
			Instantiate (blocks [i], pos, point.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x")) {
			index++;

			if (index >= 21) {
				index = 0;
			}
		}
		if (Input.GetKeyDown ("z")) {
			index--;

			if (index < 0) {
				index = 20;
			}
		}
		mycamera.transform.position = posi[index] + new Vector3 (0,2,0);
		//mycamera.transform.LookAt (blocks[index].transform.position);
		if(Input.GetMouseButtonDown(0)){
			Ray ray = mycamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 1000)) {
				Debug.Log ("1");
				if (hit.collider.tag == "Block") {
					Debug.Log ("2");
				}
			}

		}
	}
}
