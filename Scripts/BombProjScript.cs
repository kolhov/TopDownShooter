
using UnityEngine;
using UnityEngine.Serialization;

public class BombProjScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private float minExplodeTime = 0.2f; 
    [SerializeField] private float maxExplodeTime = 0.8f;
    [SerializeField] private int numberOfProj;
    private float explCounter;
    
    void Start()
    {
        explCounter = Random.Range(minExplodeTime, maxExplodeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
        CountDownAndExplode();
    }

    private void CountDownAndExplode()
    {
        explCounter -= Time.deltaTime;
        if (explCounter <= 0f)
        {
            GetComponent<ShootSystem>().ShootProjInCircle(numberOfProj);
            GetComponent<SFXSystem>().DeathSFX();
            Destroy(gameObject);
        }
    }
}
