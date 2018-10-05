using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public AudioSource fStepSource;
    public AudioClip[] fStepSounds;
    [SerializeField]
    float MovementSpeed;
    Rigidbody2D rbody;
    Animator anim;

    PlayerInventory playerInventory;
    bool nextToItem;
    public List<GameObject> collisionedItems;
    bool pickUp;
    GameObject PickUpGO;
    [SerializeField]
    GameObject talktextbox, examinetextbox;
    Text PickUpText;

    int direction = 2;
    [SerializeField]
    GameObject uptrig, lefttrig, rightrig, downtrig;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        playerInventory = GameObject.Find("Inventory").GetComponent<PlayerInventory>();
        nextToItem = false;
        pickUp = true;

        PickUpGO = GameObject.Find("PickUp");
        PickUpText = PickUpGO.GetComponentInChildren<Text>();
        PickUpGO.SetActive(false);
    }


    void Update()
    {
        
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        HandleMovement(movement_vector);
        HandleFighting(movement_vector);
        talktextbox.GetComponent<RectTransform>().position = new Vector2(transform.position.x, transform.position.y);
        examinetextbox.GetComponent<RectTransform>().position = new Vector2(transform.position.x, transform.position.y);

        if (nextToItem && collisionedItems.Count != 0)
        {
            PickUpGO.SetActive(true);
            if (PickUpText.color != Color.red)
            {
                PickUpText.text = collisionedItems[collisionedItems.Count - 1].GetComponent<ItemScript>().ItemClass.ItemName;
            }
            PickUpGO.GetComponent<RectTransform>().position = new Vector2(transform.position.x, transform.position.y);
        }

        if (Input.GetButtonDown("Use") && nextToItem && pickUp)
        {
            StartCoroutine(PickUpItem());
        }
    }


    public void HandleMovement(Vector2 movement_vector)
    {
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
        rbody.velocity = new Vector2(movement_vector.x * MovementSpeed , movement_vector.y * MovementSpeed );
    }


    public void HandleFighting(Vector2 movement_vector)
    {
        if (movement_vector.x > 0 && movement_vector.y == 0)
        {
            direction = 0;
        }
        if (movement_vector.x < 0 && movement_vector.y == 0)
        {
            direction = 1;
        }
        if (movement_vector.y < 0)
        {
            direction = 2;
        }
        if (movement_vector.y > 0)
        {
            direction = 3;
        }
        anim.SetInteger("Direction", direction);
        if (Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Attack");

        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item" && GetComponent<CapsuleCollider2D>().IsTouching(other))
        {
            if (!(collisionedItems.Contains(other.gameObject)))
            {
                collisionedItems.Add(other.gameObject);
                nextToItem = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Item")
        {
            if (collisionedItems.Contains(col.gameObject))
            {
                collisionedItems.Remove(col.gameObject);
            }


            if (collisionedItems.Count == 0)
            {
                nextToItem = false;
                PickUpGO.SetActive(false);
            }
        }
    }

    public IEnumerator PickUpItem()
    {
        pickUp = false;


        if (collisionedItems.Count == 1)
        {
            if (playerInventory.AddItem(collisionedItems[0].GetComponent<ItemScript>()))
            {
                if (collisionedItems[0].GetComponent<SpawnItem>().reSpawn)
                {
                    collisionedItems[0].GetComponent<SpawnItem>().SR.enabled = false;
                    collisionedItems[0].GetComponent<SpawnItem>().CanSpawn = true;
                    collisionedItems[0].GetComponent<SpawnItem>().StartCoroutine(collisionedItems[0].GetComponent<SpawnItem>().ReSpawnItem());
                    collisionedItems[0].GetComponent<SpawnItem>().Collider.enabled = false;
                    PickUpGO.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    pickUp = true;


                }
                else
                {
                    Destroy(collisionedItems[0].gameObject);
                    PickUpGO.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    pickUp = true;

                }
            }
            else
            {
                //Debug.Log("Inventory full");
                yield return StartCoroutine(InventoryFULL());
                pickUp = true;
                yield break;
            }
        }
        else
        {
            if (playerInventory.AddItem(collisionedItems[collisionedItems.Count - 1].GetComponent<ItemScript>()))
            {

                if (collisionedItems[collisionedItems.Count - 1].GetComponent<SpawnItem>().reSpawn)
                {
                    collisionedItems[collisionedItems.Count - 1].GetComponent<SpawnItem>().SR.enabled = false;
                    collisionedItems[collisionedItems.Count - 1].GetComponent<SpawnItem>().CanSpawn = true;
                    collisionedItems[collisionedItems.Count - 1].GetComponent<SpawnItem>().StartCoroutine(collisionedItems[collisionedItems.Count - 1].GetComponent<SpawnItem>().ReSpawnItem());
                    collisionedItems[collisionedItems.Count - 1].GetComponent<SpawnItem>().Collider.enabled = false;
                    yield return new WaitForSeconds(0.1f);
                    pickUp = true;
                }
                else
                {
                    Destroy(collisionedItems[collisionedItems.Count - 1].gameObject);
                    yield return new WaitForSeconds(0.1f);
                    pickUp = true;
                }
            }
            else
            {
                //Debug.Log("Inventory full");
                yield return StartCoroutine(InventoryFULL());
                pickUp = true;
                yield break;
            }

        }

    }

    IEnumerator InventoryFULL()
    {
        PickUpText.text = "INVENTORY FULL";
        PickUpText.color = Color.red;
        yield return new WaitForSeconds(3);
        PickUpText.text = null;
        PickUpText.color = Color.white;
    }


    void footStep()
    {
        float maxvol = 1f;
        maxvol = UnityEngine.Random.Range(0.2f, 0.5f);
        fStepSource.pitch = (UnityEngine.Random.Range(0.6f, 0.9f));
        fStepSource.PlayOneShot(fStepSounds[0], maxvol);
    }

}
