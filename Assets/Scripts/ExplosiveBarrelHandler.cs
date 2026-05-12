using UnityEngine;

public class ExplosiveBarrelHandler : MonoBehaviour
{
    EventHandler eventHandler;
    HitBoxHandler hitBoxHandler;
    ParticleSystem particleSystem;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        eventHandler = GetComponent<EventHandler>();
        hitBoxHandler = GetComponentInChildren<HitBoxHandler>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        eventHandler.wasHit.Bind(Explode);
    }
    public void Explode(GameObject _)
    {
        eventHandler.wasHit.UnBindAfterFiring(Explode);
        particleSystem.Play();
        
        Invoke("Bind",0.25f);
    }
    public void Bind()
    {
        hitBoxHandler.Bind(OnHit);
        spriteRenderer.enabled = false;
        Destroy(this.gameObject,1f);
    }
    public void OnHit(Collider2D collision)
    {
        HpHandler hpHandler = collision.gameObject.GetComponent<HpHandler>();
        if (hpHandler != null)
        {
            hpHandler.ChangeHp(-50);
        }
        ElementHandler elementHandler = collision.gameObject.GetComponent<ElementHandler>();
        if (elementHandler != null)
        {
            elementHandler.Add(Elements.fire,1);
        }
    }
}
