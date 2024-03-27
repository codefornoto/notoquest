using UnityEngine;
using NRKernal;

public class MyTrackableImage : MonoBehaviour
{
    public NRTrackableImage Image;

    public void Update()
    {
        if (Image != null && Image.GetTrackingState() == TrackingState.Tracking)
        {
            Pose center = Image.GetCenterPose();
            Quaternion rotation = center.rotation * Quaternion.Euler(270f, 180f, 0f);
            transform.position = center.position;
            transform.rotation = rotation;
        }
    }
}