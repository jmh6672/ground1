using UnityEngine;
using System.Collections;

public class MadeComputer : MonoBehaviour {
	public static MadeComputer manager;
	public GameObject Computer;
	public int count;
	// Use this for initialization
	void Awake () {
		count = 0;
		manager = this;
		Vector3 madePos= new Vector3(0,2.3f,0);
		Vector3 pos = new Vector3 (3.5f, 2.3f, 23f);
		Vector3 pos1 = new Vector3(-3.5f,2.3f,24f);
		Vector3 pos2 = new Vector3(-3.5f,2.3f,-23f);
		Vector3 pos3 = new Vector3(3.5f,2.3f,-24f);

		int[] a= new int[3];

		for (int i=0; i<4; i++) {
			for(int j=0; j<3; j++){
				a[j] = 4 * Random.Range(0,6);
				for (int c = 0; c < j; c++){
					if (a[j] == a[c])	j--;
				}
			}
			
			for(int l=0; l<3; l++){
				if (i == 0) {
					Computer.tag = "Com0";
					madePos.x = pos.x+a[l];
					madePos.z = pos.z-a[l];
					Instantiate(Computer,madePos,Quaternion.Euler(0,90,0));
				}
				if (i == 1) {
					Computer.tag = "Com1";
					madePos.x = pos1.x-a[l];
					madePos.z = pos1.z-a[l];
					Instantiate(Computer,madePos,Quaternion.Euler(0,180,0));
				}
				if (i == 2) {
					Computer.tag = "Com2";
					madePos.x = pos2.x-a[l];
					madePos.z = pos2.z+a[l];
					Instantiate(Computer,madePos,Quaternion.Euler(0,270,0));
				}
				if (i == 3) {
					Computer.tag = "Com3";
					madePos.x = pos3.x+a[l];
					madePos.z = pos3.z+a[l];
					Instantiate(Computer,madePos,Quaternion.Euler(0,0,0));
				}
				count += 1;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}