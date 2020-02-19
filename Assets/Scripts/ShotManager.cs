using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShotManager : MonoBehaviour
{
	public CinemachineVirtualCamera activeVCam;

    public void SetShot(CinemachineVirtualCamera newVCam)
	{
		activeVCam.Priority = 0;
		newVCam.Priority = 100;

		activeVCam = newVCam;
	}
}
