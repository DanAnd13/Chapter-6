using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnAndScaleMarker : MonoBehaviour
{
    public GameObject MarkerPrefab;
    private GameObject _spawnedMarker;
    private ARRaycastManager _raycastManager;
    private ARPlaneManager _planeManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Vector3 _minScale = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 _maxScale = new Vector3(1f, 1f, 1f);

    private void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
        _planeManager = GetComponent<ARPlaneManager>();
    }
    private void Update()
    {
        MarkerPlacement();
    }
    private void MarkerPlacement()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        if (_raycastManager.Raycast(screenCenter, _hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = _hits[0].pose;
            ARPlane plane = _planeManager.GetPlane(_hits[0].trackableId);
            if (plane != null)
            {
                Vector2 planeSize = plane.size;

                float planeWidth = planeSize.x;
                Vector3 newScale = Vector3.Lerp(_minScale, _maxScale, planeWidth / 10f);
                if (_spawnedMarker == null)
                {
                    _spawnedMarker = Instantiate(MarkerPrefab, hitPose.position, hitPose.rotation);
                }
                _spawnedMarker.transform.position = hitPose.position;
                _spawnedMarker.transform.rotation = hitPose.rotation;
                _spawnedMarker.transform.localScale = newScale;
            }
        }
    }
}
