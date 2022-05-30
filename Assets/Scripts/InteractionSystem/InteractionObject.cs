using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionObject : MonoBehaviour
{
    private Camera _mainCamera;
    private Renderer _renderer;
    private RaycastHit _hit;
    private int _interactableLayer = 1 << 6;
    private Ray _ray;
    private void Start()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();
    }

    private void Update() {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            _ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(_ray, out _hit, 1f, _interactableLayer)) {
                if (_hit.transform == transform) {
                    var interactable = _renderer.GetComponent<IInteractionItem>();
                    
                    if (interactable != null) {
                        interactable.Interact();
                    }
                }
            } 
        } 
    }
}
