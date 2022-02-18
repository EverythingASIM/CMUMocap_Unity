using UnityEngine;
using UnityEngine.UI;

public class PlayCMU : MonoBehaviour
{
    readonly int SubjectMaxIndex = 143;
    readonly int[] SubjectMaxTakeIndex = 
    {
        14,10,4,0,20,
        15,12,11,12,6,
        1,4,42,37,14,
        58,10,15,15,13,
        13,25,25,1,1,
        11,11,19,25,23,
        21,22,2,2,34,
        37,1,4,14,12,
        11,1,3,0,1,
        1,1,0,22,0,
        0,0,0,27,28,
        8,0,0,0,15,
        15,25,30,30,0,
        0,0,0,75,13,
        0,0,13,20,20,
        11,34,35,96,73,
        18,18,68,20,15,
        15,5,11,6,36,
        62,0,7,16,0,
        0,0,0,0,0,
        0,33,8,57,62,
        34,14,28,0,0,
        41,0,29,16,10,
        0,15,32,0,22,
        36,68,13,13,7,
        14,38,11,0,0,
        14,56,26,15,11,
        33,42,55,34,9,
        34,22,42,34
    };
    int Subject_Index = 0;
    int Take_Index = 0;
    public Animator CMUAnimator;
    public InputField StateName;

    private void Start()
    {
        Play(Subject_Index, Take_Index);
    }
    public void Next()
    {
        Take_Index++;

        while (Take_Index > SubjectMaxTakeIndex[Subject_Index]-1)
        {
            Take_Index = 0;
            Subject_Index++;

            if (Subject_Index > SubjectMaxIndex)
            {
                Subject_Index = 0;
            }
        }

        Play(Subject_Index, Take_Index);
    }
    public void Previous()
    {
        Take_Index--;

        while (Take_Index < 0)
        {
            Subject_Index--;

            if (Subject_Index < 0)
            {
                Subject_Index = SubjectMaxIndex;
            }
            
            Take_Index = SubjectMaxTakeIndex[Subject_Index]-1;
        }

        Play(Subject_Index, Take_Index);
    }
    void Play(int subject,int take)
    {
        subject += 1;
        take += 1;

        string statename = string.Empty;

        if (subject < 10)
            statename += "0";

        statename += subject + "_";

        if (take < 10)
            statename += "0";

        statename += take;

        CMUAnimator.Play(statename);

        StateName.text = statename;
    }
    public void Play(string statename)
    {
        CMUAnimator.Play(statename);

        StateName.text = statename;
    }
}