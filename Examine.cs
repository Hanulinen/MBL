using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Examine : MonoBehaviour
{

    string myText;
    string fullText;
    float textDelay = 0.005f;
    [SerializeField]
    Text textField;

    public void RecieveText(string examinedObject)
    {
        switch (examinedObject)
        {
            case "door":
                typeWriter("This door is locked during night time. (6pm - 6am)");
                break;
            case "gravestone":
                typeWriter("This is a final resting place for the townsfolk it seems.");
                break;
            case "streetsign":
                typeWriter("Sign tells that there is Ustiol that way. It must be another town.");
                break;
            case "roadclosed":
                typeWriter("The road out of town seems to be closed for everyone.");
                break;
            case "fountain":
                typeWriter("It is a fountain, but it seems to be deactivated.");
                break;
            case "bench":
                typeWriter("It is just a regular wooden bench.");
                break;
            case "lantern":
                typeWriter("These lanterns have a weird aura surrounding them.");
                break;
            case "statues":
                typeWriter("These creatures must be some kind of guardian spirits.");
                break;
            case "pumpkins":
                typeWriter("These pumpkins seem to be ripe enough to be eaten.");
                break;
            case "sand":
                typeWriter("A vast desert lies ahead. Only sandstorm roam there.");
                break;
            case "water":
                typeWriter("The water is so clean you can see the pebbles in the bottom.");
                break;
            case "outhouse":
                typeWriter("This outhouse is too tiny to be used by humans.");
                break;
            case "giantmushroom":
                typeWriter("This huge mushroom is emitting light. Must be handy during nights.");
                break;
            case "bookshelf":
                typeWriter("There are only books of witchcraft and demonology.");
                break;
            case "altar":
                typeWriter("These candles feel magical. They seem to burn eternally.");
                break;
            case "bed":
                typeWriter("The bed appears comfortable, but now is not the time to sleep. (You can sleep between 6pm - 6am)");
                break;
            case "window":
                typeWriter("The curtains are closed for a reason. Light might interrupt rituals.");
                break;
            case "symbol":
                typeWriter("The markings on the floor are supposed to allow demon summoning. But there is no demons in sight.");
                break;
            case "cthulhuhead":
                typeWriter("The head of the sea monster seems familiar.");
                break;
            case "poster":
                typeWriter("Hmm, I wonder what counts as a weapon here...");
                break;
            case "bear":
                typeWriter("This bear has been HUGE. But it really doesn’t look so frightening without fur.");
                break;
            case "mead":
                typeWriter("The smell of mead is warm and sweet.");
                break;
            case "bard":
                typeWriter("This jumping plague epidemic seems to be a big problem here.");
                break;
            case "table":
                typeWriter("Someone has clearly been feasting here.");
                break;
            case "barrels":
                typeWriter("A weird, disgusting smell permeates the air, originating from the barrels.");
                break;
            case "waterfarm":
                typeWriter("This water seems to be drinkable.");
                break;
            case "bedgrandma":
                typeWriter("The colour of the sheets are reminiscent of your grandma.");
                break;
            case "bookshelfgrandma":
                typeWriter("There are lots of books but the language is unfamiliar.");
                break;
            case "map":
                typeWriter("This seems to be the map of the town.");
                break;
            case "vampire":
                typeWriter("This painting looks familiar but it clearly represents a vampire.");
                break;
            case "portrait":
                typeWriter("This seems to be a portrait of a noble.");
                break;
            case "stairs":
                typeWriter("Access to the higher floor is restricted.");
                break;
            case "benches":
                typeWriter("These benches are made of solid stone.They feel cold.");
                break;
            case "altarchurch":
                typeWriter("It’s a mummified potato lying on the altar bed, surrounded by candles.");
                break;
            case "ograve":
                 typeWriter("This coffin appears to be too comfortable to be someone’s grave.");
                 break;
             case "cgrave":
                 typeWriter("This coffin is shut tight.");
                 break;
             case "vases":
                 typeWriter("These vases are clearly for flowers but at the moment there are no alive ones left.");
                 break;
             case "grave":
                 typeWriter("This seems to be a grave of some noble.");
                 break;
             case "cauldron":
                 typeWriter("It is a HUGE cauldron filled with animal carcasses.");
                 break;
             case "shelfsword":
                 typeWriter("The shelf is stocked with warriors’ apparel.");
                 break;
             case "shelfstaff":
                 typeWriter("A lot of sorcerer stuff is laid out on the shelf before you.");
                 break;
            case "shelfback":
                typeWriter("There are lots of items for adventurers on the shelf.");
                break;
            case "display":
                typeWriter("Golden jewellery is protected by a locked display case.");
                break;
            case "closedchest":
                typeWriter("It is locked.");
                break;
            case "openchest":
                typeWriter("The chest is filled with various items.");
                break;
            case "cauldronhole":
                typeWriter("There is nothing in the cauldron.");
                break;
            case "bedhole":
                typeWriter("The bed is only a haystack with some animal fur.");
                break;
            case "mushrooms":
                typeWriter("These mushroom emit faint light.");
                break;
            case "posterhole":
                typeWriter("Hole sweet hole. This place must be very dear to it’s owner.");
                break;
            default:
                typeWriter("Missing information");
                break;
        }
    }

    void typeWriter(string myText)
    {
        fullText = myText;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i - 1 < fullText.Length; i++)
        {
            textField.text = fullText.Substring(0, i);
            yield return new WaitForSecondsRealtime(textDelay);
        }
    }
}
