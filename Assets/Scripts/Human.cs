using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class Human : MonoBehaviour, IDamagable
{
    public UnityEvent OnHealthChanged;
    public UnityEvent OnStaminaChanged;

    [SerializeField] protected float staminaRecoveringDelay;
    [SerializeField] protected float staminaRecoveringDelta;
    [SerializeField] protected float staminaConsumingSpeed;

    [SerializeField] protected float healthRecoveringDelay;
    [SerializeField] protected float healthRecoveringDelta;

    [SerializeField] protected float staminaLosingDelta;
    [SerializeField] protected float stamina;

    [SerializeField] protected float health;

    CharacterController characterController;

    float staminaTimer;
    float healthTimer;

    protected virtual void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        staminaTimer += Time.deltaTime;

        if (characterController.velocity.magnitude > staminaConsumingSpeed)
        {
            stamina -= staminaLosingDelta * Time.deltaTime;
            staminaTimer = 0f;
        }

        if (staminaTimer >= staminaRecoveringDelay)
            stamina += staminaRecoveringDelta * Time.deltaTime;

        stamina = Mathf.Clamp(stamina, 0f, 100f);
    }

    public virtual float GetStamina() => stamina;
    public virtual float GetHealth() => health;

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        OnHealthChanged.Invoke();
    }
}

interface IDamagable
{
    public void TakeDamage(float damage);
}