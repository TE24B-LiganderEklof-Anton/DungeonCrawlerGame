using UnityEngine;

public class ExplosiveBarrelHandler : MonoBehaviour// handles exploding effects and hitregistration for explsoive barrels
{
    EventHandler eventHandler;
    HitBoxHandler hitBoxHandler;
    ParticleSystem particles;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        eventHandler = GetComponent<EventHandler>();
        hitBoxHandler = GetComponentInChildren<HitBoxHandler>();
        particles = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        eventHandler.wasHit.Bind(Explode);
    }
    public void Explode(GameObject _)
    {
        eventHandler.wasHit.UnBind(Explode);
        particles.Play();

        Invoke("Bind", 0.25f);
    }
    public void Bind()
    {
        hitBoxHandler.Bind(OnHit);
        spriteRenderer.enabled = false;
        Destroy(this.gameObject, 1f);
    }
    public void OnHit(Collider2D collision)
    {
        //deal damage if applicable
        HpHandler hpHandler = collision.gameObject.GetComponent<HpHandler>();
        if (hpHandler != null)
        {
            hpHandler.ChangeHp(-50);
        }
        //apply fire if applicable
        ElementHandler elementHandler = collision.gameObject.GetComponent<ElementHandler>();
        if (elementHandler != null)
        {
            elementHandler.Add(Elements.fire, 1);
        }
    }
}
