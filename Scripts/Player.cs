
using System.Collections;
using UnityEngine;



public class Player : MonoBehaviour
{
    [Header("Player stats")] 
    [SerializeField] private float health = 500;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float attackSpeed = 0.8f;
    [Header("Player Effects")]

    //Cached reference
    private SFXSystem _callSfx;
    private ShootSystem _shootSystem;
    private Coroutine _firingCoroutine;
    private float _padding = 0.5f;
    private float _xMin, _xMax, _yMin, _yMax;
    void Start()
    {
        SetUpMoveBoundaries();
        _shootSystem = GetComponent<ShootSystem>();
        _callSfx = GetComponent<SFXSystem>();
    }
    
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (ProcessHit(col)) return;

        if (health <= 0)
        {
            Die();
        }
    }

    private bool ProcessHit(Collider2D col)
    {
        DamageSystem damageSystem = col.gameObject.GetComponent<DamageSystem>();
        if (!damageSystem) return true;
        if (col.gameObject.CompareTag("Projectile"))
        {
            health -= damageSystem.GetDamage();
            damageSystem.Hit();
        }
        else
        {
            health -= damageSystem.GetDamage();
        }

        return false;
    }

    private void Die()
    {
        FindObjectOfType<SceneChanger>().LoadGameOverScene(); //Load game over with delay
        _callSfx.DeathSFX();
        Destroy(gameObject);
        GetComponent<VFXSystem>().PlayOnDeathVFX();
    }

    public float GetHealth()
    {
        return health;
    }
    
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    
    // Control section
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(_firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            _shootSystem.ShootProj();
            _callSfx.FireSFX();
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, _xMin, _xMax);
        var newYPos =  Mathf.Clamp(transform.position.y + deltaY, _yMin,_yMax);
        
        transform.position = new Vector2(newXPos, newYPos);
    }
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        _xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + _padding;
        _xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - _padding;
        _yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + _padding;
        _yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - _padding;
    }
}
