using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCamArea : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
	private ShotManager shotManager;

	private void Start()
	{
		shotManager = GameObject.FindObjectOfType<ShotManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		shotManager.SetShot(virtualCamera);
	}
}
