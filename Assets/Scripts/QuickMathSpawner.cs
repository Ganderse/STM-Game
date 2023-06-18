using System.Collections.Generic;
using UnityEngine;
using System.Collections;


/*
        The difficulty will change like this :

        Succesful target hit -> Score + 20 + (Multiplier * 20)

        Multiplier -> (Difficulty) * (Time between shots) / 10

        Time between target shots ->  Total time = Difficulty/2

                                   if Time between target spawn and hit < difficulty / 4 --> difficulty - difficulty*0.1
                                   if Time between target spawn and hit < 3 * difficulty / 4 --> difficulty + difficulty*0.1

        Missed shots -> Score - 10
        */


public class QuickMathSpawner : MonoBehaviour
{

    public enum OperationType
    {
        PLUS,
        MINUS,
        TIMES,
        DIV
    }

    public class Operation
    {
        public int LeftOperand { get; set; }
        public int RightOperand { get; set; }

        public OperationType oOperator { get; set; }

        public int AnswerCandidate { get; set; }
        public int CorrectAnswer { get
            {
                int returnValue = 0;
                switch (oOperator)
                {
                    case OperationType.PLUS:
                        returnValue = LeftOperand + RightOperand;
                        break;
                    case OperationType.MINUS:
                        returnValue = LeftOperand - RightOperand ;
                        break;
                    case OperationType.TIMES:
                        returnValue = LeftOperand * RightOperand;
                        break;
                    case OperationType.DIV:
                        returnValue = LeftOperand / RightOperand;
                        break;
                }
                return returnValue;
            } }
        

        public bool isCorrect {
            get
            {
                return CorrectAnswer == AnswerCandidate;
            }

        }
    }

    private Animations animate;
    public float timer = 0.0f; //Time since last target spawn
    public GameObject target;
    public GameObject Parent;
    private Material material;
    private float difficulty = 5.0f; //The higher the number, the lower the difficulty. The difficulty corresponds to the time between spawns of the target
    public GameHud hud;
    private float score;
    private float timeLastHit = 0.0f;
    private float timeTargetSpawn = 0.0f;
    private float timeBetweenSpawnAndHit = 0.0f;
    private float timeSinceLastQuestion = 0.0f;
    private Dictionary<GameObject, float> targetAgesAndStates = new Dictionary<GameObject, float>();
    private string[] easyList = { "+", "-" };
    private string[] middleList = { "*", "/" };
    private int QuestionOperator;

    public List<Operation> QuestionsAndAnswers { get; set; }
    //public IDictionary<int, int[]> QuestionAndAnswers  { get; set; }


    private void Start()
    {
        hud = GameObject.Find("Canvas").GetComponent<GameHud>();
        hud.UpdateDifficulty(difficulty);
        QuestionsAndAnswers = new List<Operation> { };

    }



    // Determines what question the game is gonna ask

    public void QuestionCreator()
    {
        System.Random rnd = new System.Random();
        int Value1;
        int Value2;
        int Value3;
        int Value4;
        int Answer;
        int fakeAnswer;

        //FORMAT OF THE DICTIONARY
        //VALUE1

        //OPERATOR :
        //+, -, *, /
        //0, 1, 2, 3

        //VALUE2

        //ANSWER

        //CORRECT:
        //FALSE, TRUE
        //0    ,    1


        //int[][] QuestionAndAnswer = new int[] { };



        //TODO Adjust the difficulty
        if (difficulty <= 7.0f)
        {

            //ADDITION SUBSTRACTION {+, -}
            QuestionOperator = rnd.Next(2);

            switch (QuestionOperator)
            {
                case 0:
                    //Correct value 1
                    Value1 = rnd.Next(100);
                    //Correct Value 2
                    Value2 = rnd.Next(100);
                    //Wrong value 1
                    Value3 = rnd.Next(-11,11);
                    fakeAnswer = Value1 + Value1 + Value3;
                    Answer = Value1 + Value2;
                    QuestionsAndAnswers.Add(new Operation {
                        LeftOperand = Value1,
                        oOperator = OperationType.PLUS,
                        RightOperand = Value2,
                        AnswerCandidate = Answer }) ;
                    QuestionsAndAnswers.Add(new Operation {
                        LeftOperand = Value1,
                        oOperator = OperationType.PLUS,
                        RightOperand = Value2,
                        AnswerCandidate = fakeAnswer });
                    break;

                case 1:
                    Value1 = rnd.Next(100);
                    Value2 = rnd.Next(100);
                    Answer = Value1 - Value2;
                    //QuestionAndAnswer = new int[] { Value1, 1, Value2, Answer };
                    break;
                default:
                    break;
            }

            Debug.Log("Question and Answer" + QuestionsAndAnswers);
            


        }
        //TODO REMOVE TEMP *************************
        //*******************

        /*else if (difficulty)
        {
            //MULTIPLICATION
        } else if (difficulty)
        {
            //HARDER
        }*/

             
    }

    public void QuestionDelete(int index)
    {
        QuestionsAndAnswers.RemoveAt(index);
    }


    public void SetLastHitTime(float time)
    {
        timeLastHit = time;
        timeBetweenSpawnAndHit = timeLastHit - timeTargetSpawn;

        //SETTING THE DIFFICULTY
        if (timeBetweenSpawnAndHit <= difficulty / 3)
        {
            difficulty -= difficulty * 0.1f;
            score = 100 + (100 * difficulty / 10);
        }
        else
        {
            score = 100;
        }


        //Update the UI
        hud.UpdateDifficulty(difficulty);
        hud.UpdateScore(score);
        /*
        Debug.Log("Difficulty : " + difficulty);
        Debug.Log("Time of Last Hit:" + timeLastHit);
        Debug.Log("Time target Spawn:" + timeTargetSpawn);
        Debug.Log("Time between Spawn and Hit:" + timeBetweenSpawnAndHit);
        Debug.Log("Time to hit:" + difficulty / 3);*/
    }


    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    public void AdjustDifficulty(bool isCorrect)
    {
        if (isCorrect)
        {
            difficulty += 1;
        }
        else difficulty -= 1;
    }

    


    // Update is called once per frame
    void Update()
    {


        timeSinceLastQuestion += Time.deltaTime;


        //Debug.Log("Time since last Question :" + timeSinceLastQuestion);



        ///////////////////////////////////////////////////////////////
        ///Age of the target
        /*
        foreach (GameObject target in new List<GameObject>(targetAgesAndStates.Keys))
        {
            // Update the target's age
            targetAgesAndStates[target] += Time.deltaTime;
            // Check if the target is dead or not
            CheckTargetAlive(target);
        }
        */
        //Calls the question creator
        //QuestionCreator(difficulty);

        ///////////////////////////////////////////////////////////////


        //timer += Time.deltaTime;
        Debug.Log("number of targets : " + targetAgesAndStates.Count);
        if (targetAgesAndStates.Count == 0 && timeSinceLastQuestion >= 2.0f)
        {
            /*TODO CURRENT TASK: WHEN INITATING, WE NEED TO PASS THE QUESTION AND ANSWER TO THE TARGET. THE TARGET HAS A BOOL CORRECTANSWER. */


            hud.UpdateTotalHit();
            //obj.AddComponent<Target>();
            //obj.transform.localScale

            //Spawning the targets
            GameObject firstTarget = Instantiate(target);
            firstTarget.transform.position = new Vector3(-2, 2, transform.position[2]);
            Debug.Log("Spawning first target");

            GameObject secondTarget = Instantiate(target);
            secondTarget.transform.position = new Vector3(2, 2, transform.position[2]);

            
            timeTargetSpawn = Time.time;
            // Store the target's age and dead state
            targetAgesAndStates.Add(firstTarget, 0);
            targetAgesAndStates.Add(secondTarget, 0);
            //Debug.Log("Targets age at spawn"+targetAgesAndStates[obj]);*/
        }
    }



    void CheckTargetAlive(GameObject target)
    {
        // Check if the target is dead or not
        if (target.GetComponent<MathTarget>().IsDestroyed())
        {
            Destroy(target);
            targetAgesAndStates.Remove(target); // Remove the target from the dictionary
        }
    }


    public void RemoveTargetFromDictionary(GameObject target)
    {
        if (targetAgesAndStates.ContainsKey(target))
        {
            targetAgesAndStates.Remove(target);
        }
    }

    public void DestroyAllTargets()
    {
        Debug.Log("Destroying all targets");
        foreach (GameObject target in new List<GameObject>(targetAgesAndStates.Keys))
        {
            targetAgesAndStates.Remove(target);
            DestroyImmediate(target);

        }
        timeSinceLastQuestion = 0;
    }



}
