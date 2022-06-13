using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //LinkedList<int> list = new LinkedList<int>();
        //list.Set(0);
        //list.Set(1);
        //list.Set(2);
        //list.Insert(0, 1);
        //list.PrintAll();

        //Tree<int> tree = new Tree<int>();
        //tree.Root = new TreeNode<int>(15);

        

        //tree.Add(5);
        //tree.Add(16);
        //tree.Add(25);
        //tree.PrintAll(tree.Root);


        //Bubble b = new Bubble();

        //b.PrintAll();

        //b.sort();

        //b.PrintAll();


        //Graph<int> g = new Graph<int>();

        //var n1 = g.AddNode(1);
        //var n2 = g.AddNode(2);
        //var n3 = g.AddNode(3);
        //var n4 = g.AddNode(4);
        //var n5 = g.AddNode(5);

        //g.AddLine(n1, n2);
        //g.AddLine(n2, n1);
        //g.AddLine(n3, n2);
        //g.AddLine(n4, n3);
        //g.AddLine(n4, n1);
        //g.AddLine(n4, n2);
        //g.AddLine(n5, n1);
        //g.AddLine(n3, n5);

        ////g.AddLine(n1, n2);
        ////g.AddLine(n2, n1);
        ////g.AddLine(n3, n2);
        ////g.AddLine(n4, n3);
        ////g.AddLine(n3, n1);
        ////g.AddLine(n3, n4);
        ////g.PrintAll();

        //g.FindNode(n4, n1);
        //g.FindMinNode(n4, n1);


        //Debug.Log(test.GetB("»ç°ú"));
        //Debug.Log(test.GetB("µþ±â"));
        //Debug.Log(test.GetB("º¹¼þ¾Æ"));
        //Debug.Log(test.Get("»ç°ú132"));
        //list.PrintAll();

        //list.Remove(2);

        //list.PrintAll();


        //list.Push(6);
        //list.PrintAll();

        //list.Dequeue();
        //list.PrintAll();
        //list.Set(3);
        //list.Set(4);


        //Debug.Log(list.GetValue(0));
        //Debug.Log(list.GetValue(1));
        //Debug.Log(list.GetValue(2));
        //Debug.Log(list.GetValue(3));
        //Debug.Log(list.GetValue(4));


        //list.Remove(2);

        //Debug.Log(list.GetValue(0));
        //Debug.Log(list.GetValue(1));
        //Debug.Log(list.GetValue(2));
        //Debug.Log(list.GetValue(3));

        //list.Remove(0);

        //Debug.Log(list.GetValue(0));
        //Debug.Log(list.GetValue(1));
        //Debug.Log(list.GetValue(2));


    }

    //int[] data = { 2, 5, 7, 8, 1, 9, 3, 4, 6 };

    //int[] dataResult;


    //[SerializeField]
    //GameObject[] images;
    //[SerializeField]
    //GameObject image;
    //[SerializeField]
    //GameObject image1;

    //int[] imagesBox;

    ////left 4 right 5
    //IEnumerator Sort(int pivot, int[] datas, int leftW, int rightW)
    //{

    //    int right = 0;
    //    int left = 0;

    //    int leftNum = 0;
    //    int rightNum = pivot - 1;
    //    while (true)
    //    {




    //        for (int i = rightNum; i >= 0; i--)
    //        {
    //            right = i;

    //            if (right <= leftNum)
    //            {
    //                rightNum = i;


    //                break;
    //            }

    //            if (datas[i] < datas[pivot])
    //            {
    //                rightNum = i - 1;

    //                break;
    //            }



    //        }
    //        for (int i = leftNum; i < pivot; i++)
    //        {
    //            left = i;
    //            if (rightNum < left)
    //            {

    //                leftNum = i;
    //                break;
    //            }

    //            if (left != rightNum)
    //            {
    //                if (datas[left] > datas[pivot])
    //                {
    //                    leftNum = i + 1;
    //                    break;
    //                }
    //            }

    //        }


    //        if (rightNum < leftNum)
    //        {



    //            int[] datasLeft = new int[rightNum + 1];

    //            Array.Copy(datas, datasLeft, rightNum + 1);



    //            for (int i = 0; i < datasLeft.Length; i++)
    //            {
    //                dataResult[leftW + i] = datasLeft[i];



    //            }

    //            dataResult[leftW + rightNum + 1] = datas[pivot];


    //            int[] datasRight = new int[(pivot) - (leftNum)];
    //            Array.Copy(datas, leftNum, datasRight, 0, (pivot) - (leftNum));



    //            for (int i = 0; i < datasRight.Length; i++)
    //            {
    //                dataResult[leftW + leftNum + 1 + i] = datasRight[i];

    //            }

    //            for (int i = 0; i < datasRight.Length; i++)
    //            {

    //                Vector3 tempPos = images[imagesBox[rightW]].transform.localPosition;
    //                tempPos.x = images[imagesBox[leftW + rightNum + 1 + i]].transform.localPosition.x;




    //                Vector3 tempPosI = images[imagesBox[leftW + rightNum + 1 + i]].transform.localPosition;
    //                tempPosI.x = images[imagesBox[rightW]].transform.localPosition.x;

    //                images[imagesBox[rightW]].transform.localPosition = tempPos;
    //                images[imagesBox[leftW + rightNum + 1 + i]].transform.localPosition = tempPosI;

    //                int temp = imagesBox[leftW + rightNum + 1 + i];
    //                imagesBox[leftW + rightNum + 1 + i] = imagesBox[rightW];
    //                imagesBox[rightW] = temp;

    //                yield return new WaitForSeconds(0.5f);

    //            }

    //            if (datasLeft.Length > 1)
    //            {



    //                ////¿ÞÂÊ
    //                yield return StartCoroutine(Sort(leftW + rightNum, datasLeft, leftW, rightNum));
    //            }
    //            else if (datasLeft.Length == 1)
    //            {


    //                if (datasLeft[0] > datas[pivot])
    //                {


    //                    dataResult[leftW + 1] = datasLeft[0];
    //                    dataResult[leftW] = datas[pivot];

    //                    int temp = datasLeft[0];
    //                    datasLeft[0] = datas[pivot];
    //                    datas[pivot] = temp;


    //                    Debug.Log(images[imagesBox[leftW + 1]].transform.GetChild(0).GetComponent<Text>().text);
    //                    Debug.Log(images[imagesBox[leftW]].transform.GetChild(0).GetComponent<Text>().text);

    //                    int a;
    //                    int b;
    //                    int.TryParse(images[imagesBox[leftW + 1]].transform.GetChild(0).GetComponent<Text>().text, out a);
    //                    int.TryParse(images[imagesBox[leftW]].transform.GetChild(0).GetComponent<Text>().text, out b);
    //                    if (a < b)
    //                    {

    //                        Vector3 tempPosR = images[imagesBox[leftW + 1]].transform.localPosition;
    //                        tempPosR.x = images[imagesBox[leftW]].transform.localPosition.x;

    //                        Vector3 tempPos1R = images[imagesBox[leftW]].transform.localPosition;
    //                        tempPos1R.x = images[imagesBox[leftW + 1]].transform.localPosition.x;

    //                        int tempImaNR = imagesBox[leftW + 1];


    //                        images[imagesBox[leftW]].transform.localPosition = tempPos1R;
    //                        images[imagesBox[leftW + 1]].transform.localPosition = tempPosR;

    //                        imagesBox[leftW + 1] = imagesBox[leftW];

    //                        imagesBox[leftW] = tempImaNR;
    //                        yield return new WaitForSeconds(0.5f);
    //                    }
    //                }
    //            }

    //            if (datasRight.Length > 1)
    //            {


    //                //¿À¸¥ÂÊ
    //                yield return StartCoroutine(Sort(datasRight.Length - 1, datasRight, leftNum, pivot));



    //            }
    //            else if (datasRight.Length == 1)
    //            {

    //                if (datasRight[0] < datas[pivot])
    //                {
    //                    Debug.Log(11111111);

    //                    dataResult[rightW - 1] = datasRight[0];
    //                    dataResult[rightW] = datas[pivot];

    //                    int temp = datasRight[0];
    //                    datasRight[0] = datas[pivot];
    //                    datas[pivot] = temp;

    //                    Debug.Log(data[imagesBox[leftW - 1]]);
    //                    Debug.Log(data[imagesBox[leftW]]);

    //                    int a;
    //                    int b;
    //                    int.TryParse(images[imagesBox[leftW - 1]].transform.GetChild(0).GetComponent<Text>().text, out a);
    //                    int.TryParse(images[imagesBox[leftW]].transform.GetChild(0).GetComponent<Text>().text, out b);
    //                    if (a > b)
    //                    {
    //                        Vector3 tempPosR = images[imagesBox[rightW - 1]].transform.localPosition;
    //                        tempPosR.x = images[imagesBox[rightW]].transform.localPosition.x;

    //                        Vector3 tempPos1R = images[imagesBox[rightW]].transform.localPosition;
    //                        tempPos1R.x = images[imagesBox[rightW - 1]].transform.localPosition.x;

    //                        int tempImaNR = imagesBox[rightW];
    //                        images[imagesBox[rightW]].transform.localPosition = tempPos1R;
    //                        images[imagesBox[rightW - 1]].transform.localPosition = tempPosR;

    //                        imagesBox[rightW] = imagesBox[rightW - 1];
    //                        imagesBox[rightW - 1] = tempImaNR;
    //                        yield return new WaitForSeconds(0.5f);
    //                    }
    //                }
    //            }
    //            break;
    //        }
    //        else
    //        {





    //            Vector3 tempPos = images[imagesBox[right]].transform.localPosition;
    //            tempPos.x = images[imagesBox[left]].transform.localPosition.x;

    //            Vector3 tempPos1 = images[imagesBox[left]].transform.localPosition;
    //            tempPos1.x = images[imagesBox[right]].transform.localPosition.x;



    //            int temp = datas[right];
    //            datas[right] = datas[left];
    //            datas[left] = temp;

    //            int tempImaN = imagesBox[left];
    //            images[imagesBox[left]].transform.localPosition = tempPos1;
    //            images[imagesBox[right]].transform.localPosition = tempPos;

    //            imagesBox[left] = imagesBox[right];
    //            imagesBox[right] = tempImaN;
    //            yield return new WaitForSeconds(0.5f);

    //        }
    //    }


    //}


    ////       for (int j = 0; j<data.Length-1; j++)
    ////        { 
    ////            for (int i = 0; i<data.Length-1-j; i++)
    ////            {
    ////                int temp = data[i];
    ////    Vector3 tempPos = images[imagesBox[i + 1]].transform.localPosition;
    ////    tempPos.x = images[imagesBox[i]].transform.localPosition.x;

    ////                Vector3 tempPos1 = images[imagesBox[i]].transform.localPosition;
    ////    tempPos1.x = images[imagesBox[i + 1]].transform.localPosition.x;

    ////                if (data[i] > data[i + 1])
    ////                    {
    ////                        data[i] = data[i + 1];

    ////                        data[i + 1] = temp;

    ////                    int tempImaN = imagesBox[i];
    ////    images[imagesBox[i]].transform.localPosition = tempPos1;
    ////                    images[imagesBox[i + 1]].transform.localPosition = tempPos;

    ////                    imagesBox[i] = imagesBox[i + 1];
    ////                    imagesBox[i + 1] = tempImaN;
    ////                    yield return new WaitForSeconds(0.5f);
    ////}              
    ////            }
    ////        }


    //int count;

    //private void Awake()
    //{

    //    imagesBox = new int[data.Length];

    //    for (int i = 0; i < imagesBox.Length; i++)
    //    {
    //        imagesBox[i] = i;
    //        count += 2;
    //    }


    //    int tempNum = -120 * (data.Length / 2);
    //    images = new GameObject[data.Length];

    //    for (int i = 0; i < data.Length; i++)
    //    {
    //        images[i] = GameObject.Instantiate(image, this.transform.position, Quaternion.identity, image1.transform);
    //        Vector3 temp = Vector3.zero;
    //        temp.x = tempNum;
    //        temp.y = -120 * (data.Length / 2) - 120 + 120 * data[i];
    //        images[i].transform.localPosition = temp;

    //        images[i].transform.GetChild(0).GetComponent<Text>().text = data[i].ToString();
    //        images[i].SetActive(true);

    //        tempNum += 120;
    //    }


    //}




    ////// Start is called before the first frame update
    ////void Start()
    ////{
    ////    dataResult = new int[data.Length];
    ////    int pivot = data.Length - 1;
    ////    StartCoroutine(Sort(pivot, data, 0, pivot));




    ////}

    //// Update is called once per frame
    //void Update()
    //{

    //}

}
