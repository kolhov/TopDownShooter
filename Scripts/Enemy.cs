
using UnityEngine;


public class Enemy : MonoBehaviour
{
    //parameters
    [SerializeField] private float health = 100;
    [SerializeField] private float minAttackSpeed = 0.2f;
    [SerializeField] private float maxAttackSpeed = 1f;
    [SerializeField] private int scoreForKill = 100;

    
    //Cached refer
    private VFXSystem _vfxSystem;
    private ScoreCounter _scoreCounter; 
    private SFXSystem _callSfx;
    private ShootSystem _combatSystem;
    private float _shotCounter;
    private void OnTriggerEnter2D(Collider2D col)
    {
        DamageSystem damageSystem = col.gameObject.GetComponent<DamageSystem>();
        if (!damageSystem) return;
        health -= damageSystem.GetDamage();
        damageSystem.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _scoreCounter.AddScore(scoreForKill);
        
        if (CompareTag("Enemy"))
            _vfxSystem.PlayOnDeathVFX();
        else
            _vfxSystem.PlayOnDeathVFX(6);
        
        _callSfx.DeathSFX();
        Destroy(gameObject);
    }

    void Start()
    {
        _vfxSystem = GetComponent<VFXSystem>();
        _scoreCounter = FindObjectOfType<ScoreCounter>();
        _combatSystem = GetComponent<ShootSystem>();
        _callSfx = GetComponent<SFXSystem>();
        _shotCounter = Random.Range(minAttackSpeed, maxAttackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0f)
        {
            _combatSystem.ShootProj();
            _callSfx.FireSFX();
            _shotCounter = Random.Range(minAttackSpeed, maxAttackSpeed);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<EnemySpawner>().SubtractEnemy();
    }
}
