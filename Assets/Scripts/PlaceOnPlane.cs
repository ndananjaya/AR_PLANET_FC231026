using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using static Unity.Burst.Intrinsics.X86.Avx;
public class PlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager raycastManager; // drag XR Origin here
    public GameObject objectToPlace; // drag the prefab here
    private GameObject placedObject; // the copy we placed
    private List <ARRaycastHit> hits = new List <ARRaycastHit>();
void Update()
    {
        // 1. Did the user tap the screen this frame?
        if (!TryGetTap(out Vector2 tapPosition)) return;
        // 2. Shoot an invisible ray from the finger into the real world.
        // Did it hit a detected surface (plane)?
        if (raycastManager.Raycast(tapPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            // 3. hits[0] is the closest surface. Its pose = position + rotation.
            Pose hitPose = hits[0].pose;
            if (placedObject == null)
            {
                // first tap: create the object
                placedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
            }
            else
            {
                // later taps: move the same object
                placedObject.transform.position = hitPose.position;
            }
        }
    }


// A tap = one finger touching down (phone) or a mouse click (editor)
bool TryGetTap(out Vector2 position)
    {
        position = Vector2.zero;
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
{
            position = Input.GetTouch(0).position;
            return true;
        }
        if (Input.touchCount == 0 && Input.GetMouseButtonDown(0))
{
            position = Input.mousePosition;
            return true;
        }
        return false;
    }
}
