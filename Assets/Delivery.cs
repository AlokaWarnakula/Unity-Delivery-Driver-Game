using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Delivery : MonoBehaviour
{

    bool hasPackage;
    // [SerializeField] Color32 hasPackageColor = new(255, 255, 255,255);
    Color32 hasPackageColor = new(255, 255, 255,255);

    // [SerializeField] Color32 noPackageColor = new(43, 212, 65,255);
    Color32 noPackageColor = new(43, 212, 65,255);


    [SerializeField] float destroyDeplyed = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Sprite collid with:" + other.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player enter the Zeron:" + other.gameObject.name);
        Debug.Log("Tag detected: '" + other.tag + "'");

        if (other.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package pick up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDeplyed);
            spriteRenderer.color = hasPackageColor;
        }
        else if (other.CompareTag("Customer") && hasPackage)
        {
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package drop off");
            hasPackage = false;
        }
    }
}
