using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeMovement : MonoBehaviour
{
    public Rigidbody[] cubeFirstLayer;
    public Rigidbody[] cubeSecondLayer;
    public Rigidbody[] cubeThirdLayer;
    public GameObject layer2;
    public GameObject layer3;
    bool check=false;
    int count;
    int count2;

    private void Start()
    {
        layer2.SetActive(false);
        layer3.SetActive(false);
        for (int i = 0; i < cubeSecondLayer.Length; i++)
        {
            cubeSecondLayer[i].detectCollisions = false;
            cubeThirdLayer[i].detectCollisions = false;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }
    

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            other.gameObject.tag = "empty";
            other.attachedRigidbody.isKinematic = false;
            other.gameObject.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, -40));
            count2++;
            count++;
            print(count);
            if (count >= cubeFirstLayer.Length)
            {
                
                count = 0;
                print("COUNTTTTT" + count);
                if (check)
                {
                    layer2.SetActive(false);
                    layer3.SetActive(true);
                    for (int i = 0; i < cubeThirdLayer.Length; i++)
                    {
                        cubeThirdLayer[i].detectCollisions = true;
                    }
                }
                
                layer2.SetActive(true);
                check = true;
                
                for (int i = 0; i < cubeSecondLayer.Length; i++)
                {
                    cubeSecondLayer[i].detectCollisions = true;
                }
                

            }
            

        }
        else if (other.CompareTag("layer2"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.66f);
        }
        else if (other.CompareTag("layer3"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.27f);
        }

        if (count2>=144)
        {
            Invoke("SceneReload",2f);
        }

    }


    void SceneReload()
    {
        SceneManager.LoadScene("SampleScene");
    }
}


