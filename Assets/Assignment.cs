
/*
This RPG data streaming assignment was created by Fernando Restituto with 
pixel RPG characters created by Sean Browning.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;


#region Assignment Instructions

/*  Hello!  Welcome to your first lab :)

Wax on, wax off.

    The development of saving and loading systems shares much in common with that of networked gameplay development.  
    Both involve developing around data which is packaged and passed into (or gotten from) a stream.  
    Thus, prior to attacking the problems of development for networked games, you will strengthen your abilities to develop solutions using the easier to work with HD saving/loading frameworks.

    Try to understand not just the framework tools, but also, 
    seek to familiarize yourself with how we are able to break data down, pass it into a stream and then rebuild it from another stream.


Lab Part 1

    Begin by exploring the UI elements that you are presented with upon hitting play.
    You can roll a new party, view party stats and hit a save and load button, both of which do nothing.
    You are challenged to create the functions that will save and load the party data which is being displayed on screen for you.

    Below, a SavePartyButtonPressed and a LoadPartyButtonPressed function are provided for you.
    Both are being called by the internal systems when the respective button is hit.
    You must code the save/load functionality.
    Access to Party Character data is provided via demo usage in the save and load functions.

    The PartyCharacter class members are defined as follows.  */

public partial class PartyCharacter
{
    public int classID;

    public int health;
    public int mana;

    public int strength;
    public int agility;
    public int wisdom;

    public LinkedList<int> equipment;

}


/*
    Access to the on screen party data can be achieved via …..

    Once you have loaded party data from the HD, you can have it loaded on screen via …...

    These are the stream reader/writer that I want you to use.
    https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter
    https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader

    Alright, that’s all you need to get started on the first part of this assignment, here are your functions, good luck and journey well!
*/


#endregion


#region Assignment Part 1

static public class AssignmentPart1
{

    static public void SavePartyButtonPressed()
    {
        foreach (PartyCharacter pc in GameContent.partyCharacters)
        {
            Debug.Log("PC class id == " + pc.classID);

            // Get the directories currently on the C drive.
            DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\").GetDirectories();

            // Write each directory name to a file.
            using (StreamWriter sw = new StreamWriter("TestFile.txt"))
            {
                foreach (PartyCharacter pcSave in GameContent.partyCharacters)
                {
                    sw.WriteLine(pcSave.classID);
                    sw.WriteLine(pcSave.health);
                    sw.WriteLine(pcSave.mana);
                    sw.WriteLine(pcSave.strength);
                    sw.WriteLine(pcSave.agility);
                    sw.WriteLine(pcSave.wisdom);
                    foreach (int EQMI in pcSave.equipment)
                    {
                        sw.WriteLine(EQMI);
                    }
                    //sw.WriteLine(pcSave.equipment);
                    //sw.WriteLine(pcSave.equipment.First.Value);
                    //sw.WriteLine(pcSave.equipment.Last.Value);
                    sw.WriteLine("");
                    //sw.WriteLine(pcSave.equipment.First);
                }
            }

            using (StreamWriter sw = new StreamWriter("TestFileEquipment.txt"))
            {
                foreach (PartyCharacter pcSave in GameContent.partyCharacters)
                {
                    foreach (int EQMI in pcSave.equipment)
                    {
                        sw.WriteLine(EQMI);
                        
                        //pc.equipment.AddLast(pcSave.equipment.First.Value);
                        //sw.WriteLine(pcSave.equipment.Count);
                    }
                    //sw.WriteLine(pcSave.equipment.First.Value);
                    //pc.equipment.AddLast(pcSave.equipment.First.Value);
                    //sw.WriteLine(pcSave.equipment.First.Value);
                    //pc.equipment.AddLast(pcSave.equipment.First.Value);
                    //sw.WriteLine(pcSave.equipment.First.Value);
                    //pc.equipment.AddLast(pcSave.equipment.First.Value);
                    //sw.WriteLine("\n");
                }
            }

            // Read and show each line from the file.
            //string line = "";
            //using (StreamReader sr = new StreamReader("TestFile.txt"))
            //{
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}

        }
    }

    static public void LoadPartyButtonPressed()
    {
        GameContent.partyCharacters.Clear();
        //foreach (PartyCharacter pcCheckLoad in GameContent.partyCharacters)
        //{
        //    Debug.Log("PC class id == " + pcCheckLoad.classID);
        //}
        using (StreamReader sr = new StreamReader("TestFile.txt"))
        {
            string IDCode;
            string HP;
            string PP;
            string STR;
            string AG;
            string WIS;
            string EQM;
            string EQM1;
            string EQM2;
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((IDCode = sr.ReadLine()) != null && (HP = sr.ReadLine()) != null
                && (PP = sr.ReadLine()) != null && (STR = sr.ReadLine()) != null
                && (AG = sr.ReadLine()) != null && (WIS = sr.ReadLine()) != null
                && (EQM = sr.ReadLine()) != null && (EQM1 = sr.ReadLine()) != null
                && (EQM2 = sr.ReadLine()) != null)
            {
                
                Debug.Log("PC class id from last save == " + IDCode);
                PartyCharacter pc = new PartyCharacter(int.Parse(IDCode), int.Parse(HP), int.Parse(PP), 
                int.Parse(STR), int.Parse(AG), int.Parse(WIS));
                pc.equipment.AddLast(int.Parse(EQM));
                pc.equipment.AddLast(int.Parse(EQM1));
                GameContent.partyCharacters.Skip(1);
                if (EQM2 != "")
                {
                    Debug.Log("Works!");
                    pc.equipment.AddLast(int.Parse(EQM2));
                }
                else
                {
                    Debug.Log("Doesn't Works!");
                }
                //Debug.Log("PC class equipment == " + EQM);
                GameContent.partyCharacters.AddLast(pc);

                
                //break;
                
                //foreach (PartyCharacter pcSave in GameContent.partyCharacters)
                //{
                //    Console.WriteLine(pcSave);
                //}
            }
        }
        //PartyCharacter pc = new PartyCharacter(1, 10, 10, 10, 10, 10);
        //GameContent.partyCharacters.AddLast(pc);
        //pc = new PartyCharacter(2, 11, 11, 11, 11, 11);
        //GameContent.partyCharacters.AddLast(pc);
        //pc = new PartyCharacter(3, 12, 12, 12, 12, 12);
        //GameContent.partyCharacters.AddLast(pc);

        GameContent.RefreshUI();
    }

}


#endregion


#region Assignment Part 2

//  Before Proceeding!
//  To inform the internal systems that you are proceeding onto the second part of this assignment,
//  change the below value of AssignmentConfiguration.PartOfAssignmentInDevelopment from 1 to 2.
//  This will enable the needed UI/function calls for your to proceed with your assignment.
static public class AssignmentConfiguration
{
    public const int PartOfAssignmentThatIsInDevelopment = 1;
}

/*

In this part of the assignment you are challenged to expand on the functionality that you have already created.  
    You are being challenged to save, load and manage multiple parties.
    You are being challenged to identify each party via a string name (a member of the Party class).

To aid you in this challenge, the UI has been altered.  

    The load button has been replaced with a drop down list.  
    When this load party drop down list is changed, LoadPartyDropDownChanged(string selectedName) will be called.  
    When this drop down is created, it will be populated with the return value of GetListOfPartyNames().

    GameStart() is called when the program starts.

    For quality of life, a new SavePartyButtonPressed() has been provided to you below.

    An new/delete button has been added, you will also find below NewPartyButtonPressed() and DeletePartyButtonPressed()

Again, you are being challenged to develop the ability to save and load multiple parties.
    This challenge is different from the previous.
    In the above challenge, what you had to develop was much more directly named.
    With this challenge however, there is a much more predicate process required.
    Let me ask you,
        What do you need to program to produce the saving, loading and management of multiple parties?
        What are the variables that you will need to declare?
        What are the things that you will need to do?  
    So much of development is just breaking problems down into smaller parts.
    Take the time to name each part of what you will create and then, do it.

Good luck, journey well.

*/

static public class AssignmentPart2
{

    static List<string> listOfPartyNames;

    static public void GameStart()
    {
        listOfPartyNames = new List<string>();
        listOfPartyNames.Add("sample 1");
        listOfPartyNames.Add("sample 2");
        listOfPartyNames.Add("sample 3");

        GameContent.RefreshUI();
    }

    static public List<string> GetListOfPartyNames()
    {
        return listOfPartyNames;
    }

    static public void LoadPartyDropDownChanged(string selectedName)
    {
        GameContent.RefreshUI();
    }

    static public void SavePartyButtonPressed()
    {
        GameContent.RefreshUI();
    }

    static public void DeletePartyButtonPressed()
    {
        GameContent.RefreshUI();
    }

}

#endregion


