using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bottle : MonoBehaviour
{
    private bool isActivated;
    public float ActivateDuration;
    public GameObject capPrefab;
    public Transform capSpawnPoint;
    public float popStrength;
    private bool opened;
    public GameObject toDelete;
    public AudioSource popSound;

    private float totalActivatedTime;
    public GameObject openedShatterPrefab;
    private ParticleSystem waterFlow;
    public GameObject liquidEmiter;
    private List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();

    [Range(0.0f, 1.0f)]
    private float fill;
    private bool isPouring;
    public GameObject liquid;
    public float flow_l_per_s;
    public float liters;
    public float dropSize_l = 0.01f;
    public float volume;
    private float fullBottle;
    private bool pourCheck;
    public bool empty;
    public GameObject emptyBottleShatteredPrefab;
    private LiquidInfos liquidInfos;

    private void Start()
    {
        waterFlow = liquidEmiter.GetComponent<ParticleSystem>();

        var particlesEmission = waterFlow.emission;
        particlesEmission.rateOverTime = flow_l_per_s * (1 / dropSize_l);

        fill = liters / volume;
    }

    private void Update()
    {
        if (liters <= 0 && !empty)
        {
            empty = true;
            gameObject.GetComponent<Destructible>().destroyedVersionPrefab = emptyBottleShatteredPrefab;
        }

        if (isActivated && !opened)
        {
            totalActivatedTime += Time.deltaTime;

            if (totalActivatedTime >= ActivateDuration)
            {
                OpenBottle();
            }
        }

        if (opened && !empty)
        {
            pourCheck = CalculatePourAngle() > 190 - fill * 180 || CalculatePourAngle() > 170;
        }
        else if (empty)
        {
            pourCheck = false;
        }

        if (pourCheck != isPouring)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }

        if (isPouring)
        {
            liters -= flow_l_per_s * Time.deltaTime;

            if (liters <= 0)
            {
                fill = 0;
            }
            else
            {
                fill = liters / volume;
            }
        }

        liquid.GetComponent<Renderer>().material.SetFloat("_Fill", fill);
    }

    private void OnParticleCollision(GameObject other)
    {
        int events = waterFlow.GetCollisionEvents(other, particleCollisionEvents);

        for (var e = 0; e < events; e++)
        {

        }
    }

    public void StartActivate()
    {
        isActivated = true;
        totalActivatedTime = 0.0f;
    }

    public void StopActivate()
    {
        isActivated = false;
    }

    public void StartPour()
    {
        waterFlow.Play();
    }

    public void EndPour()
    {
        waterFlow.Stop();
    }

    private float CalculatePourAngle()
    {
        print("Calculated radians: " + transform.up.y);

        if (transform.up.y >= 0)
        {
            return 90 - 90 * transform.up.y;
        }
        else
        {
            return 90 + 90 * -1 * transform.up.y;
        }
    }

    private void OpenBottle()
    {
        opened = true;

        popSound.Play();

        GameObject obj = Instantiate(capPrefab, capSpawnPoint.transform.position, capSpawnPoint.transform.rotation);

        obj.GetComponent<Rigidbody>().velocity = capSpawnPoint.forward * popStrength;

        gameObject.GetComponent<Destructible>().destroyedVersionPrefab = openedShatterPrefab;

        Destroy(toDelete);
    }
}
