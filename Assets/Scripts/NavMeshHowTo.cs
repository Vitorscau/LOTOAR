using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.Lightship.AR.NavigationMesh;
using UnityEngine.InputSystem;

public class NavMeshHowTo : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private LightshipNavMeshManager _navmeshManager;

    public int dot = 0;
    [SerializeField]
    private GameObject _agentPrefab;

    private GameObject _creature;
    private LightshipNavMeshAgent _agent;

    private Transform mainCameraTransform;

    private float lastClickTime = 0f;
    private float doubleClickTimeThreshold = 0.3f;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        HandleTouch();
    }

    public void ToggleVisualisation()
    {
        _navmeshManager.GetComponent<LightshipNavMeshRenderer>().enabled =
            !_navmeshManager.GetComponent<LightshipNavMeshRenderer>().enabled;

        _agent.GetComponent<LightshipNavMeshAgentPathRenderer>().enabled =
            !_agent.GetComponent<LightshipNavMeshAgentPathRenderer>().enabled;
    }

    private void HandleTouch()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
#else
        if (Input.touchCount <= 0)
            return;

        var touch = Input.GetTouch(0);

        if (Input.touchCount <= 0)
            return;
        if (touch.phase == UnityEngine.TouchPhase.Began)
#endif
        {
#if UNITY_EDITOR
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
#else
            Ray ray = _camera.ScreenPointToRay(touch.position);
#endif
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float timeSinceLastClick = Time.time - lastClickTime;
                if (timeSinceLastClick <= doubleClickTimeThreshold)
                {
                    // Double click
                    if (dot == 0)
                    {
                        dot = 1;
                        _creature = Instantiate(_agentPrefab);
                        _creature.transform.position = hit.point;
                        _agent = _creature.GetComponent<LightshipNavMeshAgent>();
                    }
                    else
                    {
                        _agent.transform.position = hit.point;
                    }
                }
                else
                {
                    // Single click
                    lastClickTime = Time.time;
                }
            }
        }
    }
}
