using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

// for seshu:
// update pointer( current position on the nameList )
// remaining_num ( how many number left )
// incorrect_view
// lastCorrectNumber, targetNumber
// startTime, timeElapsed

// for Sudeep
// need to compared user voice input with targetNumber
// update incorrect_voice

public class crossHair : MonoBehaviour {
    //IDictionary<string, int> dict = new Dictionary<string, int>();
    public Camera CameraFacing;
    //public Text m_MyText1;
    [SerializeField] private LayerMask m_ExclusionLayers;
    //private GameDataBus gameDatabus;
    [SerializeField] private float m_RayLength = 30000f;


    // cube information from scene
    private List<string> item_nameList;
    private List<int> item_valueList;

    private int pointer;
    private int totalNumber;
    private int remaining_num;
    private int incorrect_view;
    private int incoorect_voice;
    private float startTime;
    private float timeElapsed;
    private int currentSceneNum;

    private int lastCorrectNumber_index;
    private int targetNumber_value;

    // TODO: 
    void moveToNextNumber()
    {
        pointer++;
        remaining_num--;

    }

    public void update_crosshair(List<string> _nameList, List<int> _valueList, int currentScene_num)
    {
        item_nameList = _nameList;
        item_valueList = _valueList;
        pointer = 0;
        currentSceneNum = currentScene_num;
        totalNumber = _nameList.Count;
        remaining_num = totalNumber + 1;
        incorrect_view = 0;
        incoorect_voice = 0;
        startTime = 0.0f;
        timeElapsed = 0.0f;
    }

    public void setCurrenceSceneNum(int _currentScene_num)
    {
        currentSceneNum = _currentScene_num;
    }

    public void emptyData()
    {
        currentSceneNum = 0;
        totalNumber = 0;
        remaining_num = 100;
        incorrect_view = 0;
        incoorect_voice = 0;
        startTime = 0.0f;
        timeElapsed = 0.0f;
    }

    void UploadSceneResult()
    {
        DataStore dataControl = GameObject.FindObjectOfType<DataStore>();
        Report_template scene_result = new Report_template(currentSceneNum, timeElapsed, totalNumber, remaining_num, incorrect_view, incoorect_voice);
        //dataControl.pushResult(scene_result);
    }

    //   // Use this for initialization
    //   void Start () {
    //       //dict.Add("Scene1", 1);
    //       //dict.Add("Scene2", 2);
    //       //dict.Add("Scene3", 3);
    //       //dict.Add("Scene4", 4);
    //}

    //void Awake()
    //{
    //   // gameDatabus = GameDataBus.FindObjectsOfType<GameDataBus>()[0];
    //}


    int is_finished()
    {
        if (remaining_num == 0)
        {
            return 1;
        }

        return 0;
    }

    private readonly string[] scene_sequence = { "Menu", "Scene1", "T1", "Scene2", "T2", "Scene3", "T3", "Scene4", "Summary" };

    // Update is called once per frame
    void Update()
    {
        transform.position = CameraFacing.transform.position +
                           CameraFacing.transform.rotation * Vector3.forward * 60f;
        transform.LookAt(CameraFacing.transform.position);
        transform.Rotate(0.0f, 180.0f, 0.0f);

        RaycastHit hit;

        if (Physics.Raycast(new Ray(CameraFacing.transform.position,
                                CameraFacing.transform.rotation * Vector3.forward),
                            out hit, m_RayLength, m_ExclusionLayers))
        {
            //Debug.Log(hit.collider.gameObject.name);

            // transition to next scene
            string object_tag = hit.collider.gameObject.tag;

            if (object_tag != "Untagged" && object_tag != "Player")
            {
                if (object_tag == "Start Test")
                {
                    SceneManager.LoadScene("Scene2");
                }
                else if (object_tag == "Tutorial")
                {
                    SceneManager.LoadScene("Scene1");
                }
                else if (object_tag == "Next")
                {
                    //  only test scene has odd scene number
                    if (currentSceneNum % 2 == 1)
                    {
                        UploadSceneResult();
                    }

                    int next_Scene_position = currentSceneNum + 1;
                    string Scene_to_load = scene_sequence[next_Scene_position];
                    string Scene_to_unload = scene_sequence[currentSceneNum];
                    SceneManager.LoadScene(Scene_to_load);
                    SceneManager.UnloadSceneAsync(Scene_to_unload);
                }
                else if (object_tag == "Restart")
                {
                    SceneManager.LoadScene("Menu");
                }

            }




            //if (hit.collider.gameObject.tag == "Player")
            //{
            //    string objValue = transform.GetComponent<Renderer>().material.name;
            //    if (gameDatabus.isContinue() == 1)
            //    {
            //        string objName = hit.collider.gameObject.name;

            //        int result = gameDatabus.checkObject(objName);

            //        if( result == 1)
            //        {
            //            transform.GetComponent<Renderer>().material.color = Color.yellow;
            //        }
            //        else
            //        {
            //            transform.GetComponent<Renderer>().material.color = Color.red;
            //        }
            //        int incorrectCount = gameDatabus.returnWrongViewCount();
            //        //m_MyText1.text = "Incorrect Score : " + incorrectCount;
            //    }
            //    Debug.Log("hit number target");
            //}
            //else
            //{
            //    transform.GetComponent<Renderer>().material.color = Color.blue;
            //    Debug.Log("hit not number target");
            //}


            //string objectName = hit.collider.gameObject.name;
            //string[] ObjArray = objectName.Split('a');
            //Debug.Log(ObjArray[0]);
            //if (ObjArray[0] == "0")
            //{
            //    //Scene currentScene = SceneManager.GetActiveScene();
            //    //change_scene(currentScene.name);

            //    Debug.Log("hit menu");
            //}

            //}
            //else
            //{
            //    transform.GetComponent<Renderer>().material.color = Color.blue;
            //}
        }




        //void change_scene(string activeScene)
        //{
        //    Debug.Log(dict[activeScene]);
        //    switch (dict[activeScene])
        //    {
        //        case 1:
        //            SceneManager.LoadScene("Scene2");
        //            break;
        //        case 2:
        //            SceneManager.LoadScene("Scene3");
        //            break;
        //        case 3:
        //            SceneManager.LoadScene("Scene4");
        //            break;
        //        case 4:
        //            SceneManager.LoadScene("Results");
        //            break;
        //        default:
        //            SceneManager.LoadScene("Main");
        //            break;
        //    }
        //}

        //void changeColor(Color color)
        //{
        //    //Fetch the Renderer from the GameObject
        //    Renderer rend = GetComponent<Renderer>();

        //    //Set the main Color of the Material to green
        //    rend.material.color = color;
        //}

    }
}
