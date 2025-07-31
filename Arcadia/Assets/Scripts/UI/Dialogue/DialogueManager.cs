using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arcadia.UI.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public TextMeshProUGUI dialogueText;
        public GameObject scanObject;
        public GameObject dialoguePanel;
        public bool isAction;
        public TalkManager talkManager;
        public int talkIndex;

        public void Action(GameObject scanObj)
        {
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNPC);
            
            dialoguePanel.SetActive(isAction);
        }

        public void Talk(int id, bool isNPC)
        {
            string talk = talkManager.GetTalk(id, talkIndex);
            if (talk == null)
            {
                isAction = false;
                talkIndex = 0;
                return;
            }
            if (isNPC)
            {
                dialogueText.text = talk;
            }
            else
            {
                dialogueText.text = talk;
            }
            isAction = true;
            talkIndex++;
        }
    }
}