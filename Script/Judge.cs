using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Judge : MonoBehaviour
{
    public GameObject Lflag;
    public GameObject Rflag;

    public GameObject Redbox;
    public GameObject Whitebox;

    GameObject Redb;
    GameObject Whiteb;


    public Text UI;
    public Text Scoretext;

    public Text limit;

    public float rstrTime;
    public float rest;

    public static bool Red;
    public static bool White;

    public bool advance;
    public bool Judgement;
    public bool onemode;

    private Transform tr_L;
    private Vector3 v_L;

    private Transform tr_R;
    private Vector3 v_R;

    public int Score;
    public int Miss;
    public int level;

    public AudioClip sound1;
    public AudioClip right;
    public AudioClip wrong;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        Miss = 3;
        Score = 0;
        Red = false;
        White = false;
        StartCoroutine("Check");

        if (advance) level = 18;
        else level = 11;


    }

    // Update is called once per frame
    void Update()
    {
       
        rest -= Time.deltaTime;
        if(rest>=0)limit.text = string.Format("残り{0:0.0}秒", rest);
        

    }

    public IEnumerator Check()
    {
        while (true)
        {

            if (Score == 0)
            {
                yield return new WaitForSeconds(5);
                rstrTime = 5;
            }
            if (Score == 5) rstrTime = 4f;
            if (Score == 8) rstrTime = 3.5f;
            if (Score > 15 && rstrTime > 1) rstrTime = rstrTime - 0.2f;
            if (onemode) rstrTime = 1;

            int time_10x = (int)rstrTime * 10;

            yield return new WaitForSeconds(1);
            Judgement = false;
            int r = Random.Range(1, level);


            switch (r)
            {
                case 1: //右手上げ
                    Soundquestion();
                    UI.text = "右手上げて";

                    rest =rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_R = Rflag.GetComponent<Transform>();
                    v_R = tr_R.position;
                    if (v_R.y > 1.18f)
                    {
                        Judgement = true;
                    }
                    RightJ();
                    break;
                case 2://左手上げ
                    Soundquestion();
                    UI.text = "左手上げて";

                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_L = Lflag.GetComponent<Transform>();
                    v_L = tr_L.position;
                    if (v_L.y > 1.18f)
                    {
                        Judgement = true;
                    }
                    RightJ();
                    break;

                case 3://両上げ
                    Soundquestion();
                    UI.text = "両手上げて";

                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_R = Rflag.GetComponent<Transform>();
                    v_R = tr_R.position;

                    tr_L = Lflag.GetComponent<Transform>();
                    v_L = tr_L.position;

                    if (v_R.y > 1.18f && v_L.y > 1.18f)
                    {
                        Judgement = true;
                    }
                    RightJ();


                    break;

                case 4://両下げ
                    Soundquestion();
                    UI.text = "両手下げて";

                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_R = Rflag.GetComponent<Transform>();
                    v_R = tr_R.position;

                    tr_L = Lflag.GetComponent<Transform>();
                    v_L = tr_L.position;

                    if (v_R.y < 1.18f && v_L.y < 1.18f)
                    {
                        Judgement = true;
                    }
                    RightJ();


                    break;

                case 5://右下げ
                    Soundquestion();
                    UI.text = "右手下げて";

                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_R = Rflag.GetComponent<Transform>();
                    v_R = tr_R.position;
                    if (v_R.y < 1.18f)
                    {
                        Judgement = true;
                    }
                    RightJ();

                    break;

                case 6://左下げ
                    Soundquestion();
                    UI.text = "左手下げて";

                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_L = Lflag.GetComponent<Transform>();
                    v_L = tr_L.position;
                    if (v_L.y < 1.18f)
                    {
                        Judgement = true;
                    }
                    RightJ();

                    break;

                case 7://水平
                    Soundquestion();
                    UI.text = "腕を水平に";
                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_R = Rflag.GetComponent<Transform>();
                    v_R = tr_R.position;

                    tr_L = Lflag.GetComponent<Transform>();
                    v_L = tr_L.position;
                    if (-0.4f < v_R.y - v_L.y && v_R.y - v_L.y < 0.4f)
                    {
                        Judgement = true;
                    }
                    RightJ();


                    break;

                case 12://夜叉の構え
                    Soundquestion();
                    UI.text = "　夜　叉　の　構　え　";
                    Redb = Instantiate(Redbox, new Vector3(-0.77f, 1.1f, -10f), Quaternion.identity) as GameObject;
                    Whiteb = Instantiate(Whitebox, new Vector3(0f, 1.79f, -10), Quaternion.identity) as GameObject;
                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    Boxjudge();
                    

                    break;

                case 13://夜叉の構えから左手回して八時の方角
                    Soundquestion();
                    UI.text = "夜叉の構えから左手回して八時の方角";
                    Redb = Instantiate(Redbox, new Vector3(-0.77f, 1.1f, -10), Quaternion.identity) as GameObject;
                    Whiteb = Instantiate(Whitebox, new Vector3(-0.34f, 0.6f, -10.114f), Quaternion.identity) as GameObject;
                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    Boxjudge();
                    

                    break;

                case 8://槍投げ
                    Soundquestion();
                    UI.text = "槍投げ(筑高体操)";
                    Redb = Instantiate(Redbox, new Vector3(-0.58f, 1.65f, -10), Quaternion.identity) as GameObject;
                    Whiteb = Instantiate(Whitebox, new Vector3(0.126f, 1.214f, -10), Quaternion.identity) as GameObject;
                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    Boxjudge();
                    

                    break;

                case 9://旗を交差
                    Soundquestion();
                    UI.text = "旗を交差";

                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_R = Rflag.GetComponent<Transform>();
                    v_R = tr_R.position;

                    tr_L = Lflag.GetComponent<Transform>();
                    v_L = tr_L.position;

                    if (v_R.x > v_L.x)
                    {
                        Judgement = true;
                    }
                    RightJ();

                    break;

                case 14://
                    Soundquestion();
                    UI.text = "Daisuke";
                    Redb = Instantiate(Redbox, new Vector3(0.26f, 1.35f, -10.2f), Quaternion.identity) as GameObject;
                    Whiteb = Instantiate(Whitebox, new Vector3(-0.24f, 1.0f, -10.25f), Quaternion.identity) as GameObject;
                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    Boxjudge();
                    
                    break;

                case 10://赤前
                    Soundquestion();
                    UI.text = "赤旗を前に";

                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_R = Rflag.GetComponent<Transform>();
                    v_R = tr_R.position;

                    tr_L = Lflag.GetComponent<Transform>();
                    v_L = tr_L.position;

                    if (v_R.z < v_L.z)
                    {
                        Judgement = true;
                    }
                    RightJ();

                    break;

                case 11://白前
                    Soundquestion();
                    UI.text = "白旗を前に";

                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    tr_R = Rflag.GetComponent<Transform>();
                    v_R = tr_R.position;

                    tr_L = Lflag.GetComponent<Transform>();
                    v_L = tr_L.position;

                    if (v_R.z > v_L.z)
                    {
                        Judgement = true;
                    }
                    RightJ();

                    break;

                case 15://天地魔闘の構え
                    Soundquestion();
                    UI.text = "天地魔闘の構え";
                    Redb = Instantiate(Redbox, new Vector3(-0.31f, 0.846f, -10.572f), Quaternion.identity) as GameObject;
                    Whiteb = Instantiate(Whitebox, new Vector3(0.179f, 1.682f, -10.19f), Quaternion.identity) as GameObject;
                    rest=rstrTime; yield return new WaitForSeconds(rstrTime);

                    Boxjudge();
                    

                    break;

                case 16://荒ぶる鷹のポーズ
                    Soundquestion();
                    UI.text = "荒ぶる鷹のポーズ";
                    Redb = Instantiate(Redbox, new Vector3(-0.51f, 1.654f, -10.08f), Quaternion.identity) as GameObject;
                    Whiteb = Instantiate(Whitebox, new Vector3(0.36f, 1.655f, -10.08f), Quaternion.identity) as GameObject;
                    rest = rstrTime; yield return new WaitForSeconds(rstrTime);

                    Boxjudge();
                    break;

                case 17:
                    Soundquestion();
                    UI.text = "そげぶ";
                    Redb = Instantiate(Redbox, new Vector3(0.012f, 1.4f, -10.48f), Quaternion.identity) as GameObject;
                    Whiteb = Instantiate(Whitebox, new Vector3(0.27f, 0.53f, -10.07f), Quaternion.identity) as GameObject;
                    rest = rstrTime; yield return new WaitForSeconds(rstrTime);
                    Boxjudge();
                    break;

                default:
                    UI.text = "えらーえらーです！これを御覧の方はすぐに部員を呼んでください";
                    break;
            }
            Scoretext.text = "Score:" + Score;
            if (Miss == 0) Judgement = false;
            if (!Judgement) break;
        }
        UI.text = "おわり";
    }

    public void RightJ()
    {
        //座標を使って判定するパターン
        if (Judgement)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = right;
            audioSource.Play();

            UI.text = "正解！";

            Score++;

        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = wrong;
            audioSource.Play();
            UI.text = "残念！";
            Miss--;
            Judgement = true;

        }
    }

    public void Boxjudge()
    {
        //bool使って判定するパターン
        if (Red && White)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = right;
            audioSource.Play();
            UI.text = "正解！";
            Judgement = true;
            Destroy(Redb);
            Destroy(Whiteb);

            Score++;
        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = wrong;
            audioSource.Play();
            UI.text = "残念！";
            Destroy(Redb);
            Destroy(Whiteb);
            Miss--;
            Judgement = true;
        }

    }

    public void Soundquestion()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = sound1;
        audioSource.Play();
    }
    
    
}
