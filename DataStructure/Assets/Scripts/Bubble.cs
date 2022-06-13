using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Bubble : MonoBehaviour
{
    int[] data = {2,5,7,8,4,9,3,1,6 };


    [SerializeField]
    GameObject[] images;
    [SerializeField]
    GameObject image;
    [SerializeField]
    GameObject image1;

    int[] imagesBox;
    int count;
    private void Awake()
    {

        imagesBox = new int[data.Length];

        for (int i = 0; i < imagesBox.Length; i++)
        {
            imagesBox[i] = i;
            count += 2;
        }


        int tempNum = -120*(data.Length / 2);   
        images = new GameObject[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
         images[i] = GameObject.Instantiate(image, this.transform.position, Quaternion.identity,image1.transform);
            Vector3 temp = Vector3.zero;
            temp.x = tempNum;
            temp.y = -120 * (data.Length / 2)-120+ 120*data[i];
            images[i].transform.localPosition = temp;

            images[i].transform.GetChild(0).GetComponent<Text>().text = data[i].ToString();
            images[i].SetActive(true);

            tempNum += 120;
        }

     
    }

    private void Start()
    {
        StartCoroutine(Sort());
        //StartCoroutine(SortMove());
    }

    //public IEnumerator SortMove()
    //{
    //    float[] temp2 = new float[data.Length];
    //    for (int j = 0; j < data.Length; j++)
    //    {
            

    //        temp2[j] = (images[j].transform.localPosition.x - images[imagesBox[j]].transform.localPosition.x) / (count * 2);


    //    }

    //    for (int i = 0; i < count*2; i++)
    //    {


    //        Vector3 temp1 = this.transform.GetChild(1).position;
    //        temp1.y -= 2;
    //        this.transform.GetChild(1).position = temp1;

    //        for (int j = 0; j < data.Length; j++)
    //        {
                
    //            Vector3 temp= images[imagesBox[j]].transform.localPosition;
    //            temp.x += temp2[j];
    //            images[imagesBox[j]].transform.localPosition = temp;

             
    //        }

    //        yield return new WaitForSeconds(0.05f);
    //    }
    //}

        public IEnumerator Sort()
    {
        //data에 대해 버블 정렬

        for (int j = 0; j < data.Length-1; j++)
        { 
            for (int i = 0; i < data.Length-1-j; i++)
            {
                int temp = data[i];
                Vector3 tempPos = images[imagesBox[i+1]].transform.localPosition;
                tempPos.x = images[imagesBox[i]].transform.localPosition.x;
            
                Vector3 tempPos1 = images[imagesBox[i]].transform.localPosition;
                tempPos1.x = images[imagesBox[i + 1]].transform.localPosition.x;
      
                if (data[i] > data[i + 1])
                    {
                        data[i] = data[i + 1];
                   
                        data[i + 1] = temp;

                    int tempImaN = imagesBox[i];
                    images[imagesBox[i]].transform.localPosition = tempPos1;
                    images[imagesBox[i + 1]].transform.localPosition = tempPos;
                   
                    imagesBox[i] = imagesBox[i + 1];
                    imagesBox[i + 1] = tempImaN;
                    yield return new WaitForSeconds(0.5f);
                }              
            }
        }
    }

    public void PrintAll()
    {
        string result = "";
        
        for (int i = 0; i < data.Length; i++)
        {
            result += data[i] + " ";

        }
      
        Debug.Log(result);
    }
    
}
