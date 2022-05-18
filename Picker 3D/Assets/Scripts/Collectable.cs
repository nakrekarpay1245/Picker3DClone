using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //[SerializeField]
    //private LevelController levelController;

    //private void Awake()
    //{
    //    levelController = GameObject.FindObjectOfType<LevelController>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            //gameObject.layer = 11;

            Vector3 direction = other.gameObject.transform.position - transform.position;

            GetComponent<Rigidbody>().AddForce(
                new Vector3(0,0,direction.z) * 2);

            other.gameObject.GetComponent<CollectArea>().IncreaseCollectedCollectableCount();

            //levelController.IncreaseProgress();
        }
    }
}
