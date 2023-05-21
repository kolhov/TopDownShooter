
using UnityEngine;

public class VFXSystem : MonoBehaviour
{
    [SerializeField] private GameObject onDeathVFX;
    
    public void PlayOnDeathVFX()
    {
        GameObject pVFX = Instantiate(onDeathVFX, transform.position, transform.rotation);
        Destroy(pVFX,0.5f);
    }

    public void PlayOnDeathVFX(int numberOfMultipleVFX)
    {
        
        for (int i = 0; i <= numberOfMultipleVFX; i++)
        {
            Vector3 newPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3),0f);
            GameObject pVFX = Instantiate(onDeathVFX, transform.position + newPosition, transform.rotation);
            Destroy(pVFX,0.5f);
        }
    }
}
