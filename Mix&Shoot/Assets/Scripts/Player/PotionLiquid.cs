using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PotionLiquid : MonoBehaviour
{
    [SerializeField] private float _maxWobble = 0.03f;
    [SerializeField] private float _wobbleSpeedMove = 1f;
    [SerializeField] private PlayerGun _playerGun;
    [SerializeField] private float _recovery = 1f;
    [SerializeField] private float _thickness = 1f;
    [Range(0, 1)] public float CompensateShapeAmount;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Renderer _rend;
    private Vector3 _pos;
    private Vector3 _lastPos;
    private Vector3 _velocity;
    private Quaternion _lastRot;
    private Vector3 _angularVelocity;
    private float _wobbleAmountX;
    private float _wobbleAmountZ;
    private float _wobbleAmountToAddX;
    private float _wobbleAmountToAddZ;
    private float _pulse;
    private float _sinewave;
    private float _time = 0.5f;
    private Vector3 _comp;

    void Start()
    {
        GetMeshAndRend();
    }

    private void OnValidate()
    {
        GetMeshAndRend();
    }

    void GetMeshAndRend()
    {
        if (_mesh == null)
        {
            _mesh = GetComponent<MeshFilter>().mesh;
        }
        if (_rend == null)
        {
            _rend = GetComponent<Renderer>();
        }
    }
    void Update()
    {
        // decrease wobble over time
        _wobbleAmountToAddX = Mathf.Lerp(_wobbleAmountToAddX, 0, (Time.deltaTime * _recovery));
        _wobbleAmountToAddZ = Mathf.Lerp(_wobbleAmountToAddZ, 0, (Time.deltaTime * _recovery));

        // make a sine wave of the decreasing wobble
        _pulse = 2 * Mathf.PI * _wobbleSpeedMove;
        _sinewave = Mathf.Lerp(_sinewave, Mathf.Sin(_pulse * _time), Time.deltaTime * Mathf.Clamp(_velocity.magnitude + _angularVelocity.magnitude, _thickness, 10));

        _wobbleAmountX = _wobbleAmountToAddX * _sinewave;
        _wobbleAmountZ = _wobbleAmountToAddZ * _sinewave;

        // velocity
        _velocity = (_lastPos - transform.position) / Time.deltaTime;

        _angularVelocity = GetAngularVelocity(_lastRot, transform.rotation);

        // add clamped velocity to wobble
        _wobbleAmountToAddX += Mathf.Clamp((_velocity.x + (_velocity.y * 0.2f) + _angularVelocity.z + _angularVelocity.y) * _maxWobble, -_maxWobble, _maxWobble);
        _wobbleAmountToAddZ += Mathf.Clamp((_velocity.z + (_velocity.y * 0.2f) + _angularVelocity.x + _angularVelocity.y) * _maxWobble, -_maxWobble, _maxWobble);


        _rend.material.SetFloat("_WobbleX", _wobbleAmountX);
        _rend.material.SetFloat("_WobbleZ", _wobbleAmountZ);

        UpdatePos();
        _lastPos = transform.position;
        _lastRot = transform.rotation;
    }

    void UpdatePos()
    {

        Vector3 worldPos = transform.TransformPoint(new Vector3(_mesh.bounds.center.x, _mesh.bounds.center.y, _mesh.bounds.center.z));
        if (CompensateShapeAmount > 0)
        {
            _comp = Vector3.Lerp(_comp, (worldPos - new Vector3(0, GetLowestPoint(), 0)), Time.deltaTime * 10);
            _comp = (worldPos - new Vector3(0, GetLowestPoint(), 0));
            _pos = worldPos - transform.position - new Vector3(0, _playerGun.GetPotionFillAmount() - (_comp.y * CompensateShapeAmount), 0);
        }
        else
        {
            _pos = worldPos - transform.position - new Vector3(0, _playerGun.GetPotionFillAmount(), 0);
        }

        _rend.material.SetVector("_FillAmount", _pos);
    }

    Vector3 GetAngularVelocity(Quaternion foreLastFrameRotation, Quaternion lastFrameRotation)
    {
        var q = lastFrameRotation * Quaternion.Inverse(foreLastFrameRotation);
        // no rotation?
        // You may want to increase this closer to 1 if you want to handle very small rotations.
        // Beware, if it is too close to one your answer will be Nan
        if (Mathf.Abs(q.w) > 1023.5f / 1024.0f)
            return Vector3.zero;
        float gain;
        // handle negatives, we could just flip it but this is faster
        if (q.w < 0.0f)
        {
            var angle = Mathf.Acos(-q.w);
            gain = -2.0f * angle / (Mathf.Sin(angle) * Time.deltaTime);
        }
        else
        {
            var angle = Mathf.Acos(q.w);
            gain = 2.0f * angle / (Mathf.Sin(angle) * Time.deltaTime);
        }
        Vector3 angularVelocity = new Vector3(q.x * gain, q.y * gain, q.z * gain);

        if (float.IsNaN(angularVelocity.z))
        {
            angularVelocity = Vector3.zero;
        }
        return angularVelocity;
    }

    float GetLowestPoint()
    {
        float lowestY = float.MaxValue;
        Vector3 lowestVert = Vector3.zero;
        Vector3[] vertices = _mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 position = transform.TransformPoint(vertices[i]);

            if (position.y < lowestY)
            {
                lowestY = position.y;
                lowestVert = position;
            }
        }
        return lowestVert.y;
    }
}
