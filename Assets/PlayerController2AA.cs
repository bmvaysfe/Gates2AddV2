using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // for scene names and scene management
using System.Collections;
using System.Text; // for StringBuilder
using System.Linq;


public class PlayerController2AA : MonoBehaviour
{

    public float speed;

    private Rigidbody rb1;  // rename for cube as of 09.12.17

    private int count;  // count collectible objects

    public Text countText;  // reference to count text component

    public Text winText;

    //  time capturing section
    bool[] isVisited;  // Gates 0-4
    string SPACE_DOT = ". "; // after gate number before time
    
    float[] times;   // Time capturing
    StringBuilder sb; // put gate number followed by . and time for all the gates at the end;
    
    StringBuilder error;  // for debugging only, uncomment in SetCountText() if needed!
    

    //  init, often 1st scene of the game
    void Start()
    {
        Debug.Log("PlayerController2AA.Start()!");
        rb1 = GetComponent<Rigidbody>();  
        count = 0;
        
        winText.text = "";  // as of 9:31pm
        isVisited = new bool[5];  // array set up keep track of visited gates;
        times = new float[5];  // keep times in seconds of gate visiting 
        sb = new StringBuilder();
     
        SetCountText();
        
        // AAA
        error = new StringBuilder();        
    }

    //  Physics code is here
    void FixedUpdate()    
    {
        float moveHorizontal1 = Input.GetAxis("Horizontal");
        float moveVertical1 = Input.GetAxis("Vertical");

        Vector3 movement1 = new Vector3(moveHorizontal1, 0.0f, moveVertical1); // y=0, no vertical movement
        
        rb1.AddForce(movement1 * speed);        
     }


    //  Detect collision and update visited gates counter.
    void OnTriggerEnter(Collider other)
    {
        
       int pos=-1;  // no gates visited

       //  Get gate number here
       if ((other.gameObject.CompareTag("pCube0")) == true) {
           pos = 0;
       }
       else if ((other.gameObject.CompareTag("pCube1")) == true) {
           pos = 1;
       }
       else if ((other.gameObject.CompareTag("pCube2")) == true) {
           pos = 2 ;
       }
       else if ((other.gameObject.CompareTag("pCube3"))==true) {
           pos = 3;
       }
       else if ((other.gameObject.CompareTag("pCube4"))==true) {
           pos = 4;
       } 
       else
       {
            // Get name of problematic tag here - it's an Untagged Object
            // tag field will be "Untagged".
            error.Append(other.gameObject.tag);
       }

       // update for gates 0-4, for scenes Test0 and Test1 as of 07.28.17
        if (pos >= 0 && pos <= 4)
        {
            if (isVisited[pos] == false)
            {
                isVisited[pos] = true;
                times[pos] = Time.realtimeSinceStartup;  //  for initial gate visit time capturing
                count = count + 1;
                SetCountText();
            }
            else
            { // gates visited already, no changes in counting
            }
        }

        
    }



    void SetCountText()
    {
        int i;
        countText.text = "Count: " + count.ToString();
        if (count >= 5)
        {
            sb.Append("You Won!\n\n");  // Win text
            //  stats go here
            for(i=0;i<isVisited.Length;i++)
            {               
                sb.Append(i + 1);  // gate number
                sb.Append(SPACE_DOT);
                sb.Append(times[i]);
                sb.AppendLine();
            }

            // Final string
            //  winText.text = "You Won! "+Time.realtimeSinceStartup.ToString();  

            //  Add Total time here
            sb.AppendLine();
            sb.Append("Total time: ");
            sb.Append(Time.realtimeSinceStartup.ToString());


            // AAA - debugging only!
            /*
            sb.AppendLine();
            sb.Append(SceneManager.GetActiveScene().name); // Test0 or Test1
            sb.Append(speed);
            sb.Append(error.ToString());
            */
            // End of AAA
            winText.text = sb.ToString();  // Final text here

            // Load next scene, as of 07.31.17, it is scene Test1
            // There is NO buttons or waiting time, scene Test1
            // will be loading automatically with NO exit ability.
            //  SceneManager.LoadScene("Test1");
        }
    } // End of SetCountText()

/*
    //  BBB TEST ONLY 4 Box Collider in Scene Test2
    //  Detect collision and update visited gates counter.
    // Behaviour should be the same as for sphere collider, as of 8/29/17
    void OnCollisionEnter(Collision another)
    {
        //  Detect collision and update visited gates counter.
        //    OnTriggerEnter( other);  // use pre-existing routine.
        Debug.Log("OnCollisionEnter()");
        Debug.Log(another.gameObject.tag);
    }
    */
}
