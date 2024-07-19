using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraControls : MonoBehaviour
{
  public Transform target; // The transform the camera will follow; ASSIGN IN EDITOR
  public Vector3 posOffset; // The offset to set how far the camera should be from the target; EDIT IN EDITOR
  private void LateUpdate() // LateUpdate is the same as Update(), it is only called it
  {
       transform.position = target.position + posOffset; // Every frame, move the camera to the target's position plus the posOffset
  }
}