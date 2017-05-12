using UnityEngine;
using System.Collections;

public class OpenQuest : MonoBehaviour {

    public static OpenQuest instance;
    public animaController openQuestao;
    
    void Awake()
    {

        instance = this;
    }

   public  void Open ()
    {
        print("veiaqui");
       openQuestao.ShowQuestion();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
