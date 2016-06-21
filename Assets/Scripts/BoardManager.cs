using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	static public BoardManager instance;

	GameObject OriginalTriger;
	int[,] board = new int[20,20];
	TriggerScript[,] trigger = new TriggerScript[20, 20];

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		OriginalTriger = Resources.Load ("Trigger") as GameObject;
		for (int i = 0; i < 20; i++) {
			for (int j = 0; j < 20; j++) {
				Vector3 pos = new Vector3 (i, 0, j);
				GameObject obj = Instantiate (OriginalTriger,pos,Quaternion.identity) as GameObject;
				if (obj.GetComponent<TriggerScript> () != null) {
					trigger [i, j] = obj.GetComponent<TriggerScript> ();
				}
			}
		}
		for (int i = -5; i < 26; i++) {
			for (int j = -5; j < 26; j++) {
				if (i <= -1 || i >= 20 || j <= -1 || j >= 20) {
					Vector3 pos = new Vector3 (i, 0, j);
					GameObject obj = Instantiate (OriginalTriger,pos,Quaternion.identity) as GameObject;
				}
			}
		}

	}

	// Update is called once per frame
	void Update () {

	}

	//
	public bool CanPut1(int x,int y,int color){
		if (!(0 <= x && x < 20 && 0 <= y && y < 20 && 1 <= color && color <= 4)) {
			return false;
		}	
		for (int i = -1; i <= 1; i++) {
			for (int j = -1; j <= 1; j++) {
				if (i == 0 && j == 0) { //真下がおけなかったらダメ
					if (board [x, y] != 0) {
						return false;
					} 
				}else if (i == 0 || j == 0) {
					if ((0 <= x + i && x + i < 20 && 0 <= y + j && y + j < 20)) {
						if (board [x + i, y + j] == color) {
							return false;
						}
					}
				} 
			}
		}
		return true;
	}
	//
	public bool CanPut2(int x,int y,int color){
		if (!(0 <= x && x < 20 && 0 <= y && y < 20 && 1 <= color && color <= 4)) {
			return false;
		}
		bool ok = false;
		for (int i = -1; i <= 1; i += 2) {
			for (int j = -1; j <= 1; j += 2) {


				if ((0 <= x + i && x + i < 20 && 0 <= y + j && y + j < 20)) {
					if (board [x + i, y + j] == color) {
						ok = true;
					}
				}

			}
		}

		return ok;
	}
	public void WriteBoard(int x,int y,int color){
		board [x, y] = color;
	}

}



