using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    int time = 5;
    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*100, Color.cyan);
        RaycastHit hit;
        
        if(Input.GetMouseButtonDown(0))
        {
                if(Physics.Raycast(ray, out hit) == true)
                {
                    var selection = hit.transform;
                    if(selection.CompareTag("Scene1") || selection.CompareTag("Scene2") || selection.CompareTag("Scene3"))
                    {
                        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                        Debug.Log(hit.transform.gameObject.tag);
                        if (selection.CompareTag("Scene1"))
                        {
                            StartCoroutine(ChangeScene("Scene1"));
                        }
                        else if (selection.CompareTag("Scene2"))
                        {
                            StartCoroutine(ChangeScene("Scene2"));
                        }
                        else if (selection.CompareTag("Scene3"))
                        {
                            StartCoroutine(ChangeScene("Scene3"));
                        }
                    } 
                }     
        }

        timer.GetComponent<Text>().text = time.ToString();
    }

    IEnumerator ChangeScene(string scene){
        time = 5;

        while(time > 0){
            yield return new WaitForSeconds(1);
            time --;
        }

        SceneManager.LoadScene(scene);
    }

    public void ReturnMenu(){
        SceneManager.LoadScene("SceneMenu");
    }
}
