using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public Text high_score_text;
    public Text last_score_text;
    int high_score;
    int last_score;
    public XmlDocument xml;

    public int HighScore
    {
        get { return high_score; }
    }

    public int LastScore
    {
        get { return last_score; }
        set { last_score = value; 
            if(xml != null)
            {
                xml.SelectNodes("root/last_score")[0].InnerXml = last_score.ToString();

                if(last_score > high_score)
                {
                    xml.SelectNodes("root/high_score")[0].InnerXml = last_score.ToString();
                }

                xml.Save("Assets/Scripts/high_scores.xml");
            }
        
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            xml = new XmlDocument();
            xml.Load("Assets/Scripts/high_scores.xml");
            high_score = Int16.Parse(xml.SelectNodes("root/high_score")[0].InnerXml);
            last_score = Int16.Parse(xml.SelectNodes("root/last_score")[0].InnerXml);
            try
            {
                UpdateHighScoreText();
            }

            catch
            { }

            try
            {
                UpdateLastScoreText();
            }

            catch { }
            
        }

        catch(Exception e)
        {
            Debug.Log(e.Message + " " + e.StackTrace);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLastScoreText()
    {
        last_score_text.text = "Your Score: " + last_score;
    }

    public void UpdateHighScoreText()
    {
        high_score_text.text = "High Score: " + high_score;
    }

}
