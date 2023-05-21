
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{

    void Start()
    {
        Destroy(FindObjectOfType<Player>().gameObject);
    }

}
