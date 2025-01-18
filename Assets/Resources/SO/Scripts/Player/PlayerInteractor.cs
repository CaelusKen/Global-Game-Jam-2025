using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionUI _interactionUI;
    //[SerializeField] private FadeUI _fadeUI;
    private readonly Collider[] _colliders = new Collider[3];
    private readonly Collider2D[] _collider2Ds = new Collider2D[3];
    [SerializeField] private int _numFound;
    private IInteractable _interactable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if (_numFound > 0) {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if(_interactable!= null) 
            {
                if (!_interactionUI.IsDisplayed) _interactionUI.Setup(_interactable.InteractionPrompt == "TheVoid" ? "Enter ???" : "Enter " + _interactable.InteractionPrompt );

                if(Keyboard.current.fKey.wasPressedThisFrame) _interactable.Interact(this);
            }
        } else {
            if(_interactable != null) _interactable = null;
            if(_interactionUI.IsDisplayed) _interactionUI.Hide();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
