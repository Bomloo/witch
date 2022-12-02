using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CardManager : MonoBehaviour
{
    GameObject instance;

    #region UI_elements
    [SerializeField]
    private Image[] cardImages;
    [SerializeField]
    private string[] tips;
    #endregion

    #region Card_vars

    private string[] suits = { "Heart", "Diamond", "Club", "Spade" };
    [SerializeField]
    private List<int> drawn;
    private Card[] player_cards;
    private int current_card;
    [SerializeField]
    private PlayerController p;
    [SerializeField]
    private HeartCard  HCard;
    [SerializeField]
    private DiamondCard DCard;
    [SerializeField]
    private ClubCard CCard;
    [SerializeField]
    private SpadeCard SCard;

    #endregion

    #region Unity_funcs
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this.gameObject;
        DontDestroyOnLoad(this.gameObject);
        player_cards = new Card[3];
        drawn = new List<int>();
        current_card = 0;
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
            s = suits[Random.Range(0, 4)];
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
        Card c = null;
        bool draw = true;
        string s = "";
        int i = 0;
        while (draw)
        {
            s = suits[Random.Range(0, 4)];
            i = Random.Range(1, 14);
            switch (s)
            {
                case "Heart":
                    if (!drawn.Contains(i))
                    {
                        draw = false;
                        drawn.Add(i);
                        c = Instantiate<HeartCard>(HCard);
                    }
                    continue;
                case "Diamond":
                    if (!drawn.Contains(i+13))
                    {
                        draw = false;
                        drawn.Add(i+13);
                        c = Instantiate<DiamondCard>(DCard);
                    }
                    continue;
                case "Club":
                    if (!drawn.Contains(i + 26))
                    {
                        draw = false;
                        drawn.Add(i+26);
                        c = Instantiate<ClubCard>(CCard);
                    }
                    continue;
                case "Spade":
                    if (!drawn.Contains(i + 39))
                    {
                        draw = false;
                        drawn.Add(i+39);
                        c = Instantiate<SpadeCard>(SCard);
                    }
                    continue;
            }

        }


        c.SetSuitandNumber(s, i);
        if(s == "Diamond" && i == 1)
        {
            c.isActive = true;
        } else if(s=="Heart")
        {
            switch (i)
            {
                case 2:
                    c.isActive = true;
                    break;
                case 3:
                    c.isActive = true;
                    break;
                case 4:
                    c.isActive = true;
                    break;
            }
        }
        p.add_hand(c);
        if(current_card < 3)
        {
            player_cards[current_card] = c;
            current_card++;
        }
        
        return c;

    }

    //public Card ReplaceCard(int i)
    //{

    //}
    #endregion
}
