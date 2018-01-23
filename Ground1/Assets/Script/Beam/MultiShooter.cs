using UnityEngine;
using System.Collections;

public class MultiShooter : MonoBehaviour {

	public Camera camera;
	public GameObject Shot1;
	public GameObject Shot2;
    public GameObject Wave;
	public float Disturbance = 0;
	public int ShotType = 0;

	int layer;
	private GameObject NowShot;

	void Start () {
		NowShot = null;
		layer = LayerMask.GetMask ("Plane");
	}

	void Update () {	
		GameObject Bullet;

		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer)){
			Vector3 target = hit.point - transform.position;
			target.y = -3f;
			transform.rotation = Quaternion.LookRotation (target);
		}
			
        //create BasicBeamShot
		if (Input.GetButtonDown("Fire1") && HeroDamaged.manager.IsStunn==false)
        {
            Bullet = Shot1;
            //Fire
            GameObject s1 = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);
            s1.GetComponent<BeamParam>().SetBeamParam(this.GetComponent<BeamParam>());
            
            GameObject wav = (GameObject)Instantiate(Wave, this.transform.position, this.transform.rotation);
            wav.transform.localScale *= 0.25f;
            wav.transform.Rotate(Vector3.left, 90.0f);
            wav.GetComponent<BeamWave>().col = this.GetComponent<BeamParam>().BeamColor;
            
        }


        //create GeroBeam
		if (Input.GetButtonDown("Fire2") && HeroDamaged.manager.IsStunn==false)
        {
            GameObject wav = (GameObject)Instantiate(Wave, this.transform.position, this.transform.rotation);
            wav.transform.Rotate(Vector3.left, 90.0f);
            wav.GetComponent<BeamWave>().col = this.GetComponent<BeamParam>().BeamColor;

            Bullet = Shot2;
            //Fire
            NowShot = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);
			EnergyGage.manager.IsBeam = true;
        }
            //it's Not "GetButtonDown"
		if (Input.GetButton ("Fire2") && NowShot != null)
		{
			BeamParam bp = this.GetComponent<BeamParam>();
			if(NowShot.GetComponent<BeamParam>().bGero)
				NowShot.transform.parent = transform;

			Vector3 s = new Vector3(bp.Scale,bp.Scale,bp.Scale);

			NowShot.transform.localScale = s;
			NowShot.GetComponent<BeamParam>().SetBeamParam(bp);
			EnergyGage.manager.gage.value -= Time.deltaTime *  0.4f;
		}
		Debug.Log (HeroDamaged.manager.hitCount);
		if (Input.GetButtonUp ("Fire2") || EnergyGage.manager.gage.value <= 0f || HeroDamaged.manager.IsStunn==true)
		{
			if(NowShot != null)
			{
				NowShot.GetComponent<BeamParam>().bEnd = true;
			}
			EnergyGage.manager.IsBeam = false;
			EnergyGage.manager.SuperBeam = false;
		}
	}
}
