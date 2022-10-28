using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    #region Card_vars

    private string[] suits = { "Hearts", "Daimonds", "Club", "Spade" };
    private List<int> drawn = new List<int>();
    [SerializeField]
    [Tooltip("Used to make cards")]
    public Card pref;
    private Card[] player_cards;

    #endregion

    #region Unity_funcs
    // Start is called before the first frame update
    void Start()
    {
        player_cards = new Card[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Card_funcs

    public Card[] DrawCardBoss()
    {
        Card[] cards = new Card[3];
        bool draw = true;
        string s = "";
        int i = 0;
        int ind = 0;
        while (draw)
        {
            s = suits[Random.Range(0, 3)];
            i = Random.Range(1, 13);
            switch (s)
            {
                case "Heart":
                    if (!drawn.Contains(i))
                    {
                        if(ind == 2)
                        {
                            draw = false;
                        }
                        cards[ind] = new Card();
                        cards[ind].SetSuitandNumber(s, i);
                        drawn.Add(i);
                    }
                    break;
                case "Daimond":
                    if (!drawn.Contains(i + 13))
                    {
                        if (ind == 2)
                        {
                            draw = false;
                        }
                        cards[ind] = new Card();
                        cards[ind].SetSuitandNumber(s, i);
                        drawn.Add(i + 13);
                    }
                    break;
                case "Club":
                    if (!drawn.Contains(i + 26))
                    {
                        if (ind == 2)
                        {
                            draw = false;
                        }
                        cards[ind] = new Card();
                        cards[ind].SetSuitandNumber(s, i);
                        drawn.Add(i + 26);
                    }
                    break;
                case "Spade":
                    if (!drawn.Contains(i + 39))
                    {
                        if (ind == 2)
                        {
                            draw = false;
                        }
                        cards[ind] = new Card();
                        cards[ind].SetSuitandNumber(s, i);
                        drawn.Add(i + 39);
                    }
                    break;
            }

        }

        return cards;
    }


    public Card DrawCardPlayer()
    {
        Card c = new Card();
        bool draw = true;
        string s = "";
        int i = 0;
        while (draw)
        {
            s = suits[Random.Range(0, 3)];
            i = Random.Range(1, 13);
            switch (s)
            {
                case "Heart":
                    if (!drawn.Contains(i))
                    {
                        draw = false;
                        drawn.Add(i);
                    }
                    continue;
                case "Diamond":
                    if (!drawn.Contains(i+13))
                    {
                        draw = false;
                        drawn.Add(i+13);
                    }
                    continue;
                case "Club":
                    if (!drawn.Contains(i + 26))
                    {
                        draw = false;
                        drawn.Add(i+26);
                    }
                    continue;
                case "Spade":
                    if (!drawn.Contains(i + 39))
                    {
                        draw = false;
                        drawn.Add(i+39);
                    }
                    continue;
            }

        }


        c.SetSuitandNumber(s, i);
        for(int j =0; j< 3; j++)
        {
            if(player_cards[j] == null)
            {
                player_cards[j] = c;
                break;
            }
        }
        return c;

    }
    #endregion
}
