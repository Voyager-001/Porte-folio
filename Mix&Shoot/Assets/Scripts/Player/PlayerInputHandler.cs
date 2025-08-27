using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Mover mover;

    [SerializeField] private OneSlot oneSlot;

    [SerializeField] private PlayerGun playerGun;

    [SerializeField] private Transform pickUp;

    [SerializeField] private float distanceToLaunch = 5f;
    [SerializeField] private float endTime = 0.2f;
    [SerializeField] private MaterialPropertyBlock materialPropertyBlock;
    [SerializeField] private MeshRenderer arrowRenderer;
    [SerializeField] [Range(0, 5)] private float arrowOpacityAnimationSmoothness = 0.5f;
    [SerializeField] private AudioPack audioPackInteract;
    [SerializeField] private AudioPack audioPackPortal;
    [SerializeField] private AudioMixerGroup audioMixerGroup;

    private float arrowOpacity = 0f;
    private bool _launchItemTriggered;
    private bool _isAttack;

    private AudioSource _audioSource;

    private GameObject _objectInteracted;

    private Cauldron _cauldronInRange;

    private enum EPickUpState
    {
        None,
        Ingredient,
        Cauldron,
        Teleporter
    }

    private EPickUpState _pickUpState;

    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        _audioSource.outputAudioMixerGroup = audioMixerGroup;
    }

    private void Start()
    {
        materialPropertyBlock = new MaterialPropertyBlock();
        arrowRenderer.SetPropertyBlock(materialPropertyBlock);
    }

    public void Update()
    {
        if (_isAttack) playerGun.Fire();
        materialPropertyBlock.SetFloat("_Opacity",
            Mathf.Lerp(materialPropertyBlock.GetFloat("_Opacity"), 0,
                arrowOpacityAnimationSmoothness * Time.deltaTime));
        arrowRenderer.SetPropertyBlock(materialPropertyBlock);
    }

    public void OnMove(CallbackContext context)
    {
        if (mover != null) mover.SetInputVector(context.ReadValue<Vector2>());
    }

    public void OnLook(CallbackContext context)
    {
        if (mover != null) mover.SetInputRotation(context.ReadValue<Vector2>());
    }

    public void OnDash(CallbackContext context)
    {
        if (context.performed && mover != null) mover.Dash();
    }

    public void OnInteract(CallbackContext context)
    {
        if (context.performed)
        {
            audioPackInteract.PlayOn(_audioSource);

            switch (_pickUpState)
            {
                case EPickUpState.Ingredient:
                    HandleIngredient();
                    // gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    break;

                case EPickUpState.Cauldron:
                    if (!gameObject.GetComponentInChildren<UsableObject>() && _cauldronInRange != null)
                        _cauldronInRange.Mix();
                    break;

                case EPickUpState.Teleporter:
                    _objectInteracted?.GetComponent<PortalActivator>()?.ActivatePortal();
                    break;

                case EPickUpState.None:
                    _objectInteracted = null;
                    break;
            }

            if (gameObject.GetComponentInChildren<UsableObject>())
                if (gameObject.GetComponentInChildren<UsableObject>().Use())
                    if (_cauldronInRange != null)
                        _pickUpState = EPickUpState.Cauldron;
        }
    }

    private void HandleIngredient()
    {
        if (_objectInteracted == null || gameObject.GetComponentInChildren<UsableObject>()) return;

        Transform childTransform = _objectInteracted.transform;

        childTransform.SetParent(transform);
        childTransform.position = pickUp.position;
        childTransform.rotation = pickUp.rotation;
    }

    public void OnDrop(CallbackContext context)
    {
        if (context.canceled && !_launchItemTriggered && _pickUpState == EPickUpState.Ingredient)
        {
            if (gameObject.GetComponentInChildren<UsableObject>())
            {
                Transform childTransform = gameObject.GetComponentInChildren<UsableObject>().transform;

                if (childTransform != null)
                {
                    GameObject droppedObject = childTransform.gameObject;

                    droppedObject.transform.SetParent(null);

                    droppedObject.transform.position = new Vector3(childTransform.position.x, childTransform.position.y,
                        droppedObject.transform.position.z);
                    droppedObject.transform.rotation = Quaternion.identity;
                }
            }

            _pickUpState = EPickUpState.None;
        }
    }

    public void OnLaunchItem(CallbackContext context)
    {
        if (context.performed && _pickUpState == EPickUpState.Ingredient)
        {
            _launchItemTriggered = true;

            if (gameObject.GetComponentInChildren<UsableObject>())
            {
                Transform childTransform = gameObject.GetComponentInChildren<UsableObject>().transform;

                if (childTransform != null)
                {
                    GameObject launchedObject = childTransform.gameObject;

                    launchedObject.transform.SetParent(null);

                    StartCoroutine(LaunchDelayed(launchedObject));
                }
            }

            _pickUpState = EPickUpState.None;
        }
    }

    private IEnumerator LaunchDelayed(GameObject launchedObject)
    {
        _launchItemTriggered = false;

        Vector3 startPosition = launchedObject.transform.position;
        Vector3 endPosition = startPosition + transform.forward * distanceToLaunch;

        float elapsedTime = 0f;

        while (elapsedTime < endTime)
        {
            launchedObject.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / endTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        launchedObject.transform.position = endPosition;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out UsableObject usableObject))
        {
            _pickUpState = EPickUpState.Ingredient;
            _objectInteracted = other.gameObject;
        }
        else if (other.TryGetComponent(out PortalActivator portalActivator))
        {
            _pickUpState = EPickUpState.Teleporter;
            _objectInteracted = portalActivator.gameObject;
        }
        else if (other.TryGetComponent(out Cauldron cauldron))
        {
            _pickUpState = EPickUpState.Cauldron;
            _cauldronInRange = cauldron;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Cauldron cauldron))
        {
            _cauldronInRange = null;

            _pickUpState = gameObject.GetComponentInChildren<UsableObject>()
                ? EPickUpState.Ingredient
                : EPickUpState.None;
        }
        else if (other.TryGetComponent(out PortalActivator portalActivator)) _pickUpState = EPickUpState.None;
        else if (other.TryGetComponent(out UsableObject usableObject)) _pickUpState = EPickUpState.None;
    }

    public void OnAttack(CallbackContext context)
    {
        if (context.performed && !gameObject.GetComponentInChildren<UsableObject>())
        {
            _isAttack = true;
            // gameObject.transform.GetChild(2).gameObject.SetActive(true);

            materialPropertyBlock.SetFloat("_Opacity", 1);
            arrowRenderer.SetPropertyBlock(materialPropertyBlock);
        }
        else if (context.canceled || gameObject.GetComponentInChildren<UsableObject>()) _isAttack = false;
    }

    public void OnPause(CallbackContext context)
    {
        if (context.performed && GameManager.Instance != null)
            GameManager.Instance.Pause();
    }

    public void OnBook(CallbackContext context)
    {
        if (context.performed)
        {
            HUDManager.Instance.ToggleRecipe();
        }
    }
}
