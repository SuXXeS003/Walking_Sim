using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionObject : MonoBehaviour {
    private Camera _mainCamera;
    private Renderer _renderer;
    private RaycastHit _hit;
    [SerializeField] private LayerMask _interactableLayer;
    private Ray _ray;
    
    private void Start()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();
    }

    private void Update() {
        DetectInteraction();
    }

    private void DetectInteraction() {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            _ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(_ray, out _hit, 0.5f, _interactableLayer)) {
                if (_hit.transform == transform) {
                    var interactable = _renderer.GetComponent<IInteractionItem>();
                    
                    if (interactable != null) {
                        interactable.Interact();
                    }
                }
            } 
        }
    }

    public void OnMouseEnter() {
        Debug.Log("Mouse enter");
        GameObject.Find("Crosshair").GetComponent<Renderer>().material.SetFloat("_index", 10);
    }

    public void OnMouseExit() {
        Debug.Log("Mouse exit");
        GameObject.Find("Crosshair").GetComponent<Renderer>().material.SetFloat("_index", 11);
    }
}
