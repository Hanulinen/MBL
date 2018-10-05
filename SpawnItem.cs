using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour {

    public int itemClass;
    public int itemIndex;

    [Tooltip("is reSpawnable?")]
    public bool reSpawn;
    [Tooltip("Delay for spawning the items")]
    public float reSpawnTimer;
    public float Distance { get; set; }
    [Tooltip("Distance between the player and the spawnItem :: 10 equals the distance between your house and the Hairless Bear")]
    public float distanceFromItem;
    public bool CanSpawn { get; set; }

    public ItemScript IScript { get; private set; }
    public SpriteRenderer SR { get; set; }
    public Collider2D Collider { get; set; }

    GameObject playerGO;

    private void Start()
    {
        IScript = gameObject.GetComponent<ItemScript>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        Collider = gameObject.GetComponent<Collider2D>();
        playerGO = GameObject.Find("Player");

        SetParameters();
    }


    private void SetParameters()
    {
        switch (itemClass)
        {
            case 0:
                IScript.ItemClass = InventoryManager.Instance.ItemLists.Combinableitems[itemIndex];
                SR.sprite = IScript.itemSprite;
                gameObject.name = IScript.ItemClass.ItemName;
                break;
            case 1:
                IScript.ItemClass = InventoryManager.Instance.ItemLists.Healingitems[itemIndex];
                SR.sprite = IScript.itemSprite;
                gameObject.name = IScript.ItemClass.ItemName;
                break;
            case 2:
                IScript.ItemClass = InventoryManager.Instance.ItemLists.KeyItems[itemIndex];
                SR.sprite = IScript.itemSprite;
                gameObject.name = IScript.ItemClass.ItemName;
                break;
            case 3:
                IScript.ItemClass = InventoryManager.Instance.ItemLists.NormalItems[itemIndex];
                SR.sprite = IScript.itemSprite;
                gameObject.name = IScript.ItemClass.ItemName;
                break;
            case 4:
                IScript.ItemClass = InventoryManager.Instance.ItemLists.Weapons[itemIndex];
                SR.sprite = IScript.itemSprite;
                gameObject.name = IScript.ItemClass.ItemName;
                break;
            default:
                print("No such item exists");
                break;
        }
    }

    /// <summary>
    /// Calculate distance between item and player and return true when greater than given distance
    /// </summary>
    private bool CalculateDistance()
    {
        Distance = Vector2.Distance(transform.position, playerGO.transform.position);

        if (Distance > distanceFromItem)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ReSpawns item after respawn timers run out and player is far enough
    /// </summary>
    public IEnumerator ReSpawnItem ()
    {
        yield return new WaitForSeconds(reSpawnTimer);

        while (!this.Collider.isActiveAndEnabled)
        {
            if (CalculateDistance() && playerGO.GetComponent<PlayerHealth>().currentHealth > 0)
            {
                SR.enabled = true;
                Collider.enabled = true;
                yield break;
            }
            else if (playerGO.GetComponent<PlayerHealth>().currentHealth <= 0)
            {
                yield break;
            }
            yield return new WaitForSeconds(2);
        }
    }
}
