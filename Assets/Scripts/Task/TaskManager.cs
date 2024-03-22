using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public TaskUI taskUI;
    public GameEvent isClicked; //gir det mer mening å legge GameEventet i oppgave1? Nei? Her?
    public GameEventListener listener; //tenker den trenger en liste, men det har jo GameEventet. Men jeg skjønner ikke hvorfor.
    //pluss at denne ER en listener? Men det skal den kanskje ikke være da........?! Æææææ!
    public UnityEvent SetTaskActiveEvent;
    public AllTasks allTasks;
    //kanskje denne bare skal ha en referanse til TaskUI? (men vil helst ikke det da, vil heller at noe skal høre og gi beskjed)

    public void SetTaskActive(TaskSO task)
    {
        task.IsActive = true;
        SetTaskActiveEvent?.Invoke();
        taskUI.ShowActiveTask(task);
    }
}