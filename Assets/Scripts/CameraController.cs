using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() // mieux car l'objet peut ne pas �tre encore modifi� si Update() seul
    {
        transform.position = player.transform.position + offset;
    }
}
