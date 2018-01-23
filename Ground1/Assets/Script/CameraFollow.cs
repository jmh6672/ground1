using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float SMOOTH_TIME;
	public float zLength;

	public bool LockX;
	public bool LockY;
	public bool LockZ;
	public bool useSmoothing;
	public Transform target;

	private Transform thisTransform;
	private Vector3 velocity;

	private void Awake()
	{
		velocity = new Vector3(0.0f, 0f, 0f);
	}

	void Update()
	{
		
	}

	// ReSharper disable UnusedMember.Local
	private void LateUpdate()
	// ReSharper restore UnusedMember.Local
	{
		var newPos = Vector3.zero;

		if (useSmoothing)
		{
			newPos.x = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, SMOOTH_TIME);
			newPos.y = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, SMOOTH_TIME);
			newPos.z = Mathf.SmoothDamp(transform.position.z, target.position.z + zLength, ref velocity.z, SMOOTH_TIME);
		}
		else
		{
			newPos.x = target.position.x;
			newPos.y = target.position.y;
			newPos.z = target.position.z;
		}

		#region Locks
		if (LockX)
		{
			newPos.x = transform.position.x;
		}

		if (LockY)
		{
			newPos.y = transform.position.y;
		}

		if (LockZ)
		{
			newPos.z = transform.position.z;
		}
		#endregion

		transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
	}
}
