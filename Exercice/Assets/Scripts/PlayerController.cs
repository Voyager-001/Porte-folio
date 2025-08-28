using UnityEngine;
using Unity.Netcode;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : NetworkBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float maxHorizontalSpeed = 10f;
        
    [Header("Combat")]
    public float pushForce = 8f;
    public float fallYThreshold = -5f;
    
    private Rigidbody _rb;
    private Vector2 input;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.interpolation = RigidbodyInterpolation.Interpolate;
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        if (!IsOwner) return;
        if (GameManager.Instance.state.Value != GameState.Playing)
        {
            input = Vector2.zero;
            return;
        }
        
        input = ReadInput();
    }

    void FixedUpdate()
    {
        if (!IsOwner) return;
        if (GameManager.Instance.state.Value != GameState.Playing) return;
        
        var vel = new Vector3(input.x, 0, input.y) * moveSpeed;

        var lv = _rb.linearVelocity;
        lv.x = vel.x;
        lv.z = vel.z;

        if (maxHorizontalSpeed > 0)
        {
            var horiz = new Vector2(lv.x, lv.z);
            var mag = horiz.magnitude;
            if (mag > maxHorizontalSpeed)
            {
                horiz = horiz / mag * maxHorizontalSpeed;
                lv.x = horiz.x;
                lv.z = horiz.y;
            }
        }

        _rb.linearVelocity = lv;
    }

    Vector2 ReadInput()
    {
        var h = 0f;
        var v = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) v += 1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) h -= 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) v -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) h += 1f;
        
        var dir = new Vector2(h, v);
        if (dir.sqrMagnitude > 1f) dir.Normalize();
        return dir;
    }

    void OnCollisionEnter(Collision other)
    {
        if (!IsServer) return;
        if (!other.rigidbody) return;
        
        var dir = (other.transform.position - transform.position).normalized;
        other.rigidbody.AddForce(dir * pushForce, ForceMode.Impulse);
        
        StartCoroutine(CheckFall(other.rigidbody));
    }
    
    IEnumerator CheckFall(Rigidbody target)
    {
        var time = 0f;
        while (time < 2f)
        {
            if (!target) yield break;
            if (target.transform.position.y < fallYThreshold)
            {
                GameManager.Instance.WinServer(OwnerClientId, " (fall)");
                yield break;
            }
            time += Time.deltaTime;
            yield return null;
        }
    }
}