using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Core : MonoBehaviour
{
    private int P1Score, P2Score;
    [SerializeField]private int Limit;

    public Action onWin;

    [SerializeField]private TextMeshProUGUI ScoretextP1, ScoretextP2;

    public int P1Score_Acc{
        get{return P1Score;}
        set{P1Score = value;}
    }
    public int P2Score_Acc{
        get{return P2Score;}
        set{P2Score = value;}
    }

    public int Limit_Acc{
        get{return Limit;}
        set{Limit = value;}
    }   
    
    // Start is called before the first frame update
    async void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoretextP1.text = P1Score.ToString();
        ScoretextP2.text = P2Score.ToString();
        if(P1Score >= Limit || P2Score >= Limit){
            onWin.Invoke();
        }
    }
}
