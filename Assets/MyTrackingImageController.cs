using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class MyTrackingImageController : MonoBehaviour
{
    public GameObject TrackingImageVisualizerPrefab;

    private Dictionary<int, MyTrackableImage> m_Visualizers = new Dictionary<int, MyTrackableImage>();
    private List<NRTrackableImage> m_TempTrackingImages = new List<NRTrackableImage>();

    public void Update()
    {
        if (NRFrame.SessionStatus != SessionState.Running) return;
        NRFrame.GetTrackables<NRTrackableImage>(m_TempTrackingImages, NRTrackableQueryFilter.New);
        foreach (NRTrackableImage image in m_TempTrackingImages)
        {
            int idx = image.GetDataBaseIndex();
            m_Visualizers.TryGetValue(idx, out MyTrackableImage visualizer);
            TrackingState state = image.GetTrackingState();
            if (state == TrackingState.Tracking && visualizer == null)
            {
                Pose pose = image.GetCenterPose();
                Quaternion rotation = pose.rotation * Quaternion.Euler(0f, 180f, 0f);
                visualizer = Instantiate(TrackingImageVisualizerPrefab, pose.position, pose.rotation, transform)
                    .AddComponent<MyTrackableImage>();
                visualizer.Image = image;
                m_Visualizers.Add(idx, visualizer);
            }
            else if (state == TrackingState.Stopped && visualizer != null)
            {
                m_Visualizers.Remove(idx);
                Destroy(visualizer.gameObject);
            }
        }
    }
}