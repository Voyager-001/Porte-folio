using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSpell : MonoBehaviour
{
    private Vector3 initPos;
    [SerializeField] private float vineGroundOffset;
    [SerializeField] private float maxDistance;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float lifeTime;
    private float spawnTime;

    [SerializeField] private LineRenderer vine;
    [SerializeField] private BoxCollider vineCollider;
    [SerializeField] private Collider ballCollider;
    [SerializeField] private Transform vineBall;
    [SerializeField] private MeshRenderer vineBallRenderer;
    [SerializeField] private MeshRenderer spikesRenderer;
    [SerializeField] private MeshRenderer windRenderer;
    [SerializeField] private GameObject vineLight;
    [SerializeField] private GameObject impactParticle;

    [SerializeField][Range(0.0f, 1.0f)] private float minVineBallSize;
    private float maxVineBallSize;

    [SerializeField] private float damageDealedBySec;

    private bool projectileTravelling;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        maxVineBallSize = vineBall.localScale.x;

        Physics.Raycast(transform.position, -transform.up, out RaycastHit hitInfo);
        vine.SetPosition(0, new Vector3(transform.position.x, hitInfo.point.y + vineGroundOffset, transform.position.z));

        projectileTravelling = true;
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(initPos, transform.position);

        if (projectileTravelling) 
        {
            transform.position += transform.forward * projectileSpeed * Time.deltaTime;

            Physics.Raycast(transform.position, -transform.up, out RaycastHit hitInfo);
            vine.SetPosition(1, new Vector3(transform.position.x, hitInfo.point.y + vineGroundOffset, transform.position.z));

            vineBall.localScale = Vector3.Lerp(new Vector3(maxVineBallSize, maxVineBallSize, maxVineBallSize), new Vector3(minVineBallSize, minVineBallSize, minVineBallSize), Mathf.Clamp((currentDistance / maxDistance), 0.0f, 1.0f));
            vineCollider.center = new Vector3(0, -Vector3.Distance(transform.position, hitInfo.point) + vineGroundOffset, -currentDistance / 2);
            vineCollider.size = new Vector3(vineCollider.size.x, vineCollider.size.y, currentDistance);
        }

        if (projectileTravelling && currentDistance > maxDistance) 
        {
            StopProjectile();
        }

        if (!projectileTravelling && Time.time - spawnTime > lifeTime) Destroy(gameObject);
    }

    public void StopProjectile()
    {
        spawnTime = Time.time;
        projectileTravelling = false;
        vineBallRenderer.enabled = false;
        spikesRenderer.enabled = false;
        vineLight.SetActive(false);
        windRenderer.enabled = false;
        ballCollider.enabled = false;
        Instantiate(impactParticle, transform.position, transform.rotation);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<Health>(out Health enemy))
            {
                enemy.TakeDamage(damageDealedBySec * Time.deltaTime);
            }
        }
    }
}
