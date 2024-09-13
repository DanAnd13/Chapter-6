using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnAnimationObject : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public SwitchingMusic SwitchingMusic;
    public GameObject UIElements;
    private ARRaycastManager _arRaycastManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        SpawnOnTouch();
    }
    private void SpawnOnTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !IsTouchOverUI(touch))
            {
                if (_arRaycastManager.Raycast(touch.position, _hits, TrackableType.PlaneWithinPolygon))
                {
                    SpawnObjectsAndPlayMusic();
                }
            }
        }
    }
    private void SpawnObjectsAndPlayMusic()
    {
        Pose hitPose = _hits[0].pose;
        SwitchingMusic.PlayOrPauseMusic();
        UIElements.SetActive(true);
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = hitPose.position;
    }
    private bool IsTouchOverUI(Touch touch)
    {
        return EventSystem.current.IsPointerOverGameObject(touch.fingerId);
    }
}
