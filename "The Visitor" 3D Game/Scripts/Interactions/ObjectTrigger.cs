using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectTrigger : MonoBehaviour
{
    public int objectIndex;
    public GameObject interactUI, buttonYes, buttonNo, buttonOk, button1, button2, button3, button4, button5, button6, button7, button8, button9, button0, hiddenButton;
    public bool screenLock;
    bool recordOn;
    bool inPhone, triggerSequence, Co_active, phoneSolved, gameSolved;

    public Text displayText, hintText;

    public AudioSource recordAudio, phoneAudio, shelfMove, doorOpening;
   

    public Camera ShelfCam, PlayerCam;
    public bool playerCam = true;

    public Animator animator;
    public Animator shelfAnim;


    /// <summary>
    /// Indexes:
    ///     0: Record Player
    ///     1: Dresser
    ///     2: Window
    ///     3: Bookshelf
    ///     4: Individual Book
    ///     5: phone
    ///     6: Bed Book
    ///     7: Bed
    ///     8: Escape Door
    /// </summary>

    private static ObjectTrigger instance;
    public static ObjectTrigger Instance { get { return instance; } }
    public void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        ShelfCam.gameObject.SetActive(false);
        PlayerCam.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        inPhone = false;
        recordOn = false;
        triggerSequence = true;
        Co_active = false;
        gameSolved = false;
        phoneSolved = false;
        ShelfCam.gameObject.SetActive(false);
        PlayerCam.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggerSequence)
        {
            if (!Co_active)
            {
                StartCoroutine("MrDude");
            }
        }
    }
    IEnumerator MrDude()
    {
        Co_active = true;
        int delay = Random.Range(30, 70);
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("BeginLightSequence");
        Co_active = false;

    }
    public void triggerActivated(int index, bool b_yes, bool b_no, bool b_ok, string message)
    {
        
        objectIndex = index;
        displayText.text = message;
        if(index ==0 && recordOn)
        {
            displayText.text = "There is a record player here. Turn it off?";
        }
        if(index != 2)
        {
            Time.timeScale = 0f;
        }
        
        else
        {
            MouseLook.screenLock = true;
            PlayerMovement.Instance.moveLock = true;
        }
        if (index == 3)
        {
            ShelfCam.gameObject.SetActive(true);
            PlayerCam.gameObject.SetActive(false);
            playerCam = false;
            if (gameSolved)
            {
                objectIndex = 8;
                displayText.text = "Escape the room?";
                buttonYes.SetActive(true);
                buttonNo.SetActive(true);
                buttonOk.SetActive(false);
                interactUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                return;
            }
            else
            {
                hiddenButton.SetActive(true);
            }
            

        }
        if(index == 5 && phoneSolved){
            displayText.text = "Rows upon rows of knowledge and wisdom" +
                            "\nOf all of these friends, one came unwelcome" +
                            "\n17, 11, 13, 16, 2" +
                            "\nThe 3rd of the 4th, nobody knew" +
                            "\n\n What could that mean?";
            b_yes = false;
            b_no = false;
            b_ok = true;
        }

        buttonYes.SetActive(b_yes);
        buttonNo.SetActive(b_no);
        buttonOk.SetActive(b_ok);
            
        interactUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        
    }
    public void yes()
    {
        switch (objectIndex) {
            case 0:
                if (!recordOn)
                {
                    recordAudio.Play();
                    recordOn = true;
                    if (triggerSequence)
                    {
                        animator.SetTrigger("BeginLightSequence");
                        triggerSequence = false;
                    }
                    buttonOk.SetActive(true);
                    buttonYes.SetActive(false);
                    buttonNo.SetActive(false);
                    displayText.text = "There's something inscribed on the record that you can see as it's being played. \n\n\"It's coming. Hide and pray it does not find you\"";
                    return;
                }
                else
                {
                    recordAudio.Stop();
                    recordOn = false;
                    displayText.text = "";
                    hintText.text = "";
                    interactUI.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
                
                
                break;
            case 4:
                displayText.text = "";
                hintText.text = "\"I have to find a way out of here. _̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝ something out there. _̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝ fear _̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝\n" +
                "_̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝ phone, _̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝ _̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝ the window _̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝_̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝_̵̪̬͍̺́̌͒̀̒̇͒͛̉̌̽͒͘͝͠_̵͔̪̦̦̭̳͇̱͍̯͌̍̎̾̆̅͐̔͒͐̎̉̀͑͊̈́̈̽͠_̵̨̧̲̭̣̳̦͖̜̟̳͙̪̽̿̽͒̿̒̅̈́̕_̶̨̧̩͖͚̲̼͓̥̥͔̯̎̎̄̉͐̊̓̕͠_̶̨̧̮͉̺̖̀͒̔̈́͐̏̽́̽̀̔̃_̷͙̞̮̼̲͙̣̫̤̗̝̫̣̝͇̜̥̱̭͕̍̈́̄̍͑̈̓̓͌͗̂̃̓͐͗͝  escape\n" +
                "The Music The MUSIC THE MUSIC THE MUSIC̸̛̺͙̯̘͂̋̀̿̇͐̃̇͐͘͝͝T̷̢̯͕̳̟͖̆Ḩ̶̯̰͚͇͙̬̪̩͇̅̋͜͝Ḙ̷͉̤͍̬̖̤̘͖͈̹̻͇̟̞̮͎̥̦͒̈́̽̿̄̇̂̒͑̔́́͗̏̌̋͜͝͠͝ ̸̻͐̉̆̑̽̿͌̏̑̑̌͊̎̊͠͠͝M̵̫̝̪͔͎̟͙̻̑̈́͜Ư̶̱̼̘̋͋̿̑̐̋͝͠S̷͍̬͈̜̺̠̙̰̭͖̱̝̲̻̘͔̏͑̅͑ͅĮ̶̧̳͖͚̙̬͚̙͌̓̒́̿̄̑͆C̸̛̺͙̯̘͂̋̀̿̇͐̃̇͐͘͝͝T̷̢̯͕̳̟͖̆Ḩ̶̯̰͚͇͙̬̪̩͇̅̋͜͝Ḙ̷͉̤͍̬̖̤̘͖͈̹̻͇̟̞̮͎̥̦͒̈́̽̿̄̇̂̒͑̔́́͗̏̌̋͜͝͠͝ ̸̻͐̉̆̑̽̿͌̏̑̑̌͊̎̊͠͠͝M̵̫̝̪͔͎̟͙̻̑̈́͜Ư̶̱̼̘̋͋̿̑̐̋͝͠S̷͍̬͈̜̺̠̙̰̭͖̱̝̲̻̘͔̏͑̅͑ͅĮ̶̧̳͖͚̙̬͚̙͌̓̒́̿̄̑͆C̸̛̺͙̯̘͂̋̀̿̇͐̃̇͐͘͝͝T̷̢̯͕̳̟͖̆Ḩ̶̯̰͚͇͙̬̪̩͇̅̋͜͝Ḙ̷͉̤͍̬̖̤̘͖͈̹̻͇̟̞̮͎̥̦͒̈́̽̿̄̇̂̒͑̔́́͗̏̌̋͜͝͠͝ ̸̻͐̉̆̑̽̿͌̏̑̑̌͊̎̊͠͠͝M̵̫̝̪͔͎̟͙̻̑̈́͜Ư̶̱̼̘̋͋̿̑̐̋͝͠S̷͍̬͈̜̺̠̙̰̭͖̱̝̲̻̘͔̏͑̅͑ͅĮ̶̧̳͖͚̙̬͚̙͌̓̒́̿̄̑͆C̸̛̺͙̯̘͂̋̀̿̇͐̃̇͐͘͝͝T̷̢̯͕̳̟͖̆Ḩ̶̯̰͚͇͙̬̪̩͇̅̋͜͝Ḙ̷͉̤͍̬̖̤̘͖͈̹̻͇̟̞̮͎̥̦͒̈́̽̿̄̇̂̒͑̔́́͗̏̌̋͜͝͠͝ ̸̻͐̉̆̑̽̿͌̏̑̑̌͊̎̊͠͠͝M̵̫̝̪͔͎̟͙̻̑̈́͜Ư̶̱̼̘̋͋̿̑̐̋͝͠S̷͍̬͈̜̺̠̙̰̭͖̱̝̲̻̘͔̏͑̅͑ͅĮ̶̧̳͖͚̙̬͚̙͌̓̒́̿̄̑͆C̸̛̺͙̯̘͂̋̀̿̇͐̃̇͐͘͝͝T̷̢̯͕̳̟͖̆Ḩ̶̯̰͚͇͙̬̪̩͇̅̋͜͝Ḙ̷͉̤͍̬̖̤̘͖͈̹̻͇̟̞̮͎̥̦͒̈́̽̿̄̇̂̒͑̔́́͗̏̌̋͜͝͠͝ ̸̻͐̉̆̑̽̿͌̏̑̑̌͊̎̊͠͠͝M̵̫̝̪͔͎̟͙̻̑̈́͜Ư̶̱̼̘̋͋̿̑̐̋͝͠S̷͍̬͈̜̺̠̙̰̭͖̱̝̲̻̘͔̏͑̅͑ͅĮ̶̧̳͖͚̙̬͚̙͌̓̒́̿̄̑͆C̸̛̺͙̯̘͂̋̀̿̇͐̃̇͐͘͝͝T̷̢̯͕̳̟͖̆Ḩ̶̯̰͚͇͙̬̪̩͇̅̋͜͝Ḙ̷͉̤͍̬̖̤̘͖͈̹̻͇̟̞̮͎̥̦͒̈́̽̿̄̇̂̒͑̔́́͗̏̌̋͜͝͠͝ ̸̻͐̉̆̑̽̿͌̏̑̑̌͊̎̊͠͠͝M̵̫̝̪͔͎̟͙̻̑̈́͜Ư̶̱̼̘̋͋̿̑̐̋͝͠S̷͍̬͈̜̺̠̙̰̭͖̱̝̲̻̘͔̏͑̅͑ͅĮ̶̧̳͖͚̙̬͚̙͌̓̒́̿̄̑͆C̸̛̺͙̯̘͂̋̀̿̇͐̃̇͐͘͝͝T̷̢̯͕̳̟͖̆Ḩ̶̯̰͚͇͙̬̪̩͇̅̋͜͝Ḙ̷͉̤͍̬̖̤̘͖͈̹̻͇̟̞̮͎̥̦͒̈́̽̿̄̇̂̒͑̔́́͗̏̌̋͜͝͠͝ ̸̻͐̉̆̑̽̿͌̏̑̑̌͊̎̊͠͠͝M̵̫̝̪͔͎̟͙̻̑̈́͜Ư̶̱̼̘̋͋̿̑̐̋͝͠S̷͍̬͈̜̺̠̙̰̭͖̱̝̲̻̘͔̏͑̅͑ͅĮ̶̧̳͖͚̙̬͚̙͌̓̒́̿̄̑͆C̸̛̺͙̯̘͂̋̀̿̇͐̃̇͐͘͝͝ \"    \n\nParts of it are illegible. There's something written at the bottom\n\n" +
                "                 \"5 _ 5 -_ 2 _ _\"              \n" +
                "                                    -"; //545-7297

                Time.timeScale = 0f;
                buttonOk.SetActive(true);
                buttonYes.SetActive(false);
                buttonNo.SetActive(false);
                interactUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                return;
                break;
            case 5:
                Time.timeScale = 0f;
                buttonOk.SetActive(true);
                buttonYes.SetActive(false);
                buttonNo.SetActive(false);
                interactUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);
                button4.SetActive(true);
                button5.SetActive(true);
                button6.SetActive(true);
                button7.SetActive(true);
                button8.SetActive(true);
                button9.SetActive(true);
                button0.SetActive(true);
                inPhone = true;
                return;
                break;
            case 6:
                displayText.text = "\"I̵t̷'̸s̴ ̵a̷ ̶f̷i̴n̶e̸ ̸d̷a̸y̵.̷ ̷P̷e̵o̶p̷l̵e̴ ̷o̴p̵e̶n̵ ̴w̵i̶n̶d̷o̶w̴s̵.̸ ̶T̸h̸e̶y̴ ̴l̸o̴o̷k̶ ̴o̸u̶t̵s̸i̶d̶e̴,̷ ̴j̵u̷s̵t̵ ̷f̴o̶r̵ ̷a̸ ̸s̵h̷o̴r̴t̸ ̸w̴h̸i̵l̷e̷.̶ ̴T̸h̴e̴y̸ ̴l̵o̵o̵k̵ ̸a̴t̸ ̶t̷h̴e̸ ̸g̵r̴a̵s̸s̶,̶ ̷a̴n̷d̴ ̷t̵h̴e̴y̸ ̵l̵o̶o̷k̵ ̶a̶t̷ ̵t̷h̴e̵ ̶g̵r̶a̷s̶s̷.̷ ̶T̷h̸e̶y̵ ̸w̶a̵i̴t̶ ̵f̶o̶r̷ ̶t̵h̸e̸ ̸s̷k̵y̶.̴ ̶I̶t̴'̵s̵ ̶g̴o̴i̵n̶g̷ ̶t̸o̷ ̸b̶e̶ ̶a̵ ̵f̸i̵n̶e̵ ̴n̷i̸g̵h̴t̷ ̸t̴o̴n̷i̸g̶h̴t̷.̶ ̶I̷t̶'̵s̶ ̸g̷o̴i̶n̵g̴ ̶t̵o̸ ̶b̴e̵ ̷a̷ ̶f̴i̶n̷e̴ ̷d̴a̶y̸ ̷t̵o̶m̷o̷r̸r̵o̴w̵.̵\"\nWhat could this mean?"; 
                hintText.text = "";
                Time.timeScale = 0f;
                buttonOk.SetActive(true);
                buttonYes.SetActive(false);
                buttonNo.SetActive(false);
                interactUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                return;
                break;
            case 8:
                doorOpening.Play();
                displayText.text = "";
                hintText.text = "";
                buttonOk.SetActive(false);
                buttonYes.SetActive(false);
                buttonNo.SetActive(false);
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene("CreditsScene");
                break;
        }
        Time.timeScale = 1f;

    }
    public void no() //This can also be used for "Okay"
    {
        switch (objectIndex)
        {
            case 0:
                displayText.text = "";
                hintText.text = "";
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case 1:
                displayText.text = "";
                hintText.text = "";
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case 2:
                displayText.text = "";
                hintText.text = "";
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                MouseLook.screenLock = false;
                PlayerMovement.Instance.moveLock = false;
                break;
            case 3:
                ShelfCam.gameObject.SetActive(false);
                PlayerCam.gameObject.SetActive(true);
                playerCam = true;
                hiddenButton.SetActive(false);
                displayText.text = "";
                hintText.text = "";
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case 4:
                displayText.text = "";
                hintText.text = "";
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case 5:
                if (inPhone && !phoneSolved)
                {
                    if (hintText.text.Equals("5457297"))
                    {
                        button1.SetActive(false);
                        button2.SetActive(false);
                        button3.SetActive(false);
                        button4.SetActive(false);
                        button5.SetActive(false);
                        button6.SetActive(false);
                        button7.SetActive(false);
                        button8.SetActive(false);
                        button9.SetActive(false);
                        button0.SetActive(false);
                        hintText.text = "";
                        displayText.text = "\"Rows upon rows of knowledge and wisdom" +
                            "\nOf all of these friends, one came unwelcome" +
                            "\n17, 11, 13, 16, 2" +
                            "\nThe 3rd of the 4th, nobody knew\"" +
                            "\n\n What could that mean?";
                        phoneAudio.Play();
                        inPhone = false;
                        phoneSolved = true;
                        return;
                    }
                    else
                    {
                        button1.SetActive(false);
                        button2.SetActive(false);
                        button3.SetActive(false);
                        button4.SetActive(false);
                        button5.SetActive(false);
                        button6.SetActive(false);
                        button7.SetActive(false);
                        button8.SetActive(false);
                        button9.SetActive(false);
                        button0.SetActive(false);
                        displayText.text = "... Nothing happened";
                        hintText.text = "";
                        phoneAudio.Stop();
                        inPhone = false;
                    }
                }
                else
                {
                    displayText.text = "";
                    hintText.text = "";
                    interactUI.SetActive(false);
                    button1.SetActive(false);
                    button2.SetActive(false);
                    button3.SetActive(false);
                    button4.SetActive(false);
                    button5.SetActive(false);
                    button6.SetActive(false);
                    button7.SetActive(false);
                    button8.SetActive(false);
                    button9.SetActive(false);
                    button0.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case 6:
                displayText.text = "";
                hintText.text = "";
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case 7:
                displayText.text = "";
                hintText.text = "";
                interactUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                break;
        }
        Time.timeScale = 1f;

    }
    public void hidden()
    {
        Time.timeScale = 1f;
        shelfMove.Play();
        shelfAnim.SetTrigger("OpenPassage");
        gameSolved = true;
    }
    public void one()
    {
        hintText.text += "1";
    }
    public void two()
    {
        hintText.text += "2";
    }
    public void three()
    {
        hintText.text += "3";
    }
    public void four()
    {
        hintText.text += "4";
    }
    public void five()
    {
        hintText.text += "5";
    }
    public void six()
    {
        hintText.text += "6";
    }
    public void seven()
    {
        hintText.text += "7";
    }
    public void eight()
    {
        hintText.text += "8";
    }
    public void nine()
    {
        hintText.text += "9";
    }
    public void zero()
    {
        hintText.text += "0";
    }
}
