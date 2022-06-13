using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using System;
public class Quick :MonoBehaviour
{
    int[] data = { 2, 5, 7, 8, 1, 9, 3, 4, 6 };

  

    [SerializeField]
    GameObject[] images;
    [SerializeField]
    GameObject image;
    [SerializeField]
    GameObject image1;

    int[] imagesBox;

    //left 4 right 5
    IEnumerator Sort(int left, int right)
    {
       
   
        int l= left;
        int r = right-1;

        while (true)
        {
       
            while (data[l] < data[right] )
            {
               
         
                if (l == right-1)
                {
                    break; 
                }
                l++;
            }
           

            while (data[r] > data[right])
            {

                if (r == left)
                {
                    r = l;
                    break;
                }
                r--;

            }


            if (r <= l)
            {
             




                if (r == l)
                {
                    Debug.Log("°°À½!!");
                 
                    if (data[l] > data[right])
                    {
                        for (int i = 0; i < (right - (r)); i++)
                        {

                            Debug.Log(right - (r -1));
                            Debug.Log(l+i);
                            Debug.Log(right);

                            int tempData = data[l + i];
                            data[l + i] = data[right];
                            data[right] = tempData;

                            Vector3 tempPosl = images[imagesBox[l + i]].transform.localPosition;
                            tempPosl.x = images[imagesBox[right]].transform.localPosition.x;

                            Vector3 tempPosr = images[imagesBox[right]].transform.localPosition;
                            tempPosr.x = images[imagesBox[l + i]].transform.localPosition.x;

                            images[imagesBox[l + i]].transform.localPosition = tempPosl;
                            images[imagesBox[right]].transform.localPosition = tempPosr;


                            int tempImaN = imagesBox[l + i];
                            imagesBox[l + i] = imagesBox[right];
                            imagesBox[right] = tempImaN;

                            yield return new WaitForSeconds(0.5f);
                        }
                        if (r - left >= 1)
                        {
                            Debug.Log(33333);
                            Debug.Log(left);
                            Debug.Log(r);
                            yield return StartCoroutine(Sort(left, r));
                        }

                        if (right - (l + 1) >= 1)
                        {
                            Debug.Log(222);
                            Debug.Log(l + 1);
                            Debug.Log(right);
                            yield return StartCoroutine(Sort(l + 1, right));
                        }
                    }
                    else
                    {
                        for (int i = 1; i < (right - (r)); i++)
                        {
                            Debug.Log(l + i);
                            Debug.Log(right);

                            int tempData = data[l + i];
                            data[l + i] = data[right];
                            data[right] = tempData;

                            Vector3 tempPosl = images[imagesBox[l + i]].transform.localPosition;
                            tempPosl.x = images[imagesBox[right]].transform.localPosition.x;

                            Vector3 tempPosr = images[imagesBox[right]].transform.localPosition;
                            tempPosr.x = images[imagesBox[l + i]].transform.localPosition.x;

                            images[imagesBox[l + i]].transform.localPosition = tempPosl;
                            images[imagesBox[right]].transform.localPosition = tempPosr;


                            int tempImaN = imagesBox[l + i];
                            imagesBox[l + i] = imagesBox[right];
                            imagesBox[right] = tempImaN;

                            yield return new WaitForSeconds(0.5f);
                        }

                        if (r - left >= 1)
                        {
                            Debug.Log(33333);
                            Debug.Log(left);
                            Debug.Log(r);
                            yield return StartCoroutine(Sort(left, r));
                        }

                        if (right - (l + 1) >= 1)
                        {
                            Debug.Log(222);
                            Debug.Log(l + 1);
                            Debug.Log(right);
                            yield return StartCoroutine(Sort(l + 1, right));
                        }

                    }

                }
                else {
                    for (int i = 0; i < (right - (r)); i++)
                    {
                        Debug.Log(l + i);
                        Debug.Log(right);

                        int tempData = data[l+i];
                        data[l+i] = data[right];
                        data[right] = tempData;

                        Vector3 tempPosl = images[imagesBox[l + i]].transform.localPosition;
                        tempPosl.x = images[imagesBox[right]].transform.localPosition.x;

                        Vector3 tempPosr = images[imagesBox[right]].transform.localPosition;
                        tempPosr.x = images[imagesBox[l + i]].transform.localPosition.x;

                        images[imagesBox[l + i]].transform.localPosition = tempPosl;
                        images[imagesBox[right]].transform.localPosition = tempPosr;


                        int tempImaN = imagesBox[l + i];
                        imagesBox[l + i] = imagesBox[right];
                        imagesBox[right] = tempImaN;

                        yield return new WaitForSeconds(0.5f);
                    }

                    if (r - left >= 1)
                    {
                       
                        Debug.Log(left);
                        Debug.Log(r);
                        yield return StartCoroutine(Sort(left, r));
                    }

                    if (right - (l + 1) >= 1)
                    {
                    
                        Debug.Log(l + 1);
                        Debug.Log(right);
                        yield return StartCoroutine(Sort(l + 1, right));
                    }

                }

                

               

             
                    break;


            }
            else
            {
                int tempData = data[l];
                data[l] = data[r];
                data[r] = tempData;

           
                Vector3 tempPosl = images[imagesBox[l]].transform.localPosition;
                tempPosl.x = images[imagesBox[r]].transform.localPosition.x;

                Vector3 tempPosr = images[imagesBox[r]].transform.localPosition;
                tempPosr.x = images[imagesBox[l]].transform.localPosition.x;

                images[imagesBox[l]].transform.localPosition = tempPosl;
                images[imagesBox[r]].transform.localPosition = tempPosr;

                int tempImaN = imagesBox[l];
                imagesBox[l] = imagesBox[r];
                imagesBox[r] = tempImaN;

                yield return new WaitForSeconds(0.5f);
            }

        }
       
    }




    // Start is called before the first frame update
    void Start()
    {
        images = new GameObject[data.Length];
        imagesBox = new int[data.Length];

        for (int i = 0; i < imagesBox.Length; i++)
        {
            imagesBox[i] = i;
        }

        int pivot = data.Length-1;


        int tempNum = -120 * (data.Length / 2);
        for (int i = 0; i < data.Length; i++)
        {
            images[i] = GameObject.Instantiate(image, this.transform.position, Quaternion.identity, image1.transform);
            Vector3 temp = Vector3.zero;
            temp.x = tempNum;
            temp.y = -120 * (data.Length / 2) - 120 + 120 * data[i];
            images[i].transform.localPosition = temp;

            images[i].transform.GetChild(0).GetComponent<Text>().text = data[i].ToString();
            images[i].SetActive(true);

            tempNum += 120;
        }
      


        StartCoroutine(Sort(0, pivot));

    }

   
}
