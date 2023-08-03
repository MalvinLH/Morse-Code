using System.Collections.Generic;
using UnityEngine;

public class MorseCodeData : MonoBehaviour
{
    public static readonly Dictionary<char, string> morseCodeDictionary = new Dictionary<char, string>
    {
        {'A', ".-.."}, {'B', "-....-"}, {'C', "....-."}, {'D', "..--"},
        {'E', "----"}, {'F', "....--"}, {'G', "--.-"}, {'H', "......"},
        {'I', "."}, {'J', "-...--"}, {'K', "-.-.."}, {'L', "...."},
        {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', "..-."},
        {'Q', "--..-"}, {'R', "..-"}, {'S', "..."}, {'T', "-"},
        {'U', "...-"}, {'V', "..--."}, {'W', ".--"}, {'X', "-..-."},
        {'Y', "-.--"}, {'Z', "--.."}, {'0', "..---"}, {'1', "....-"},
        {'2', "---.."}, {'3', "....."}, {'4', "--..."}, {'5', ".----"},
        {'6', "...--"}, {'7', "----."}, {'8', "-----"}, {'9', "-...."}
    };

    public static readonly string[] wordVariations = { "dobel", "pijit", "riset", "gatal", "acawi", "fungi", "kadet", "dadih",
                                                       "kakao", "ciduk", "rubin", "bahna", "detas", "kubul", "tepik", "kilus",
                                                       "rajin", "abaka", "istri", "pulen", "barut", "setal" };
    
    public static readonly Dictionary<string, float> correctAnswers = new Dictionary<string, float>
    {
        {"dobel", 3.505f}, {"pijit", 3.515f}, {"riset", 3.518f}, {"gatal", 3.522f},
        {"acawi", 3.532f}, {"fungi", 3.535f}, {"kadet", 3.537f}, {"dadih", 3.542f},
        {"kakao", 3.543f}, {"ciduk", 3.545f}, {"rubin", 3.552f}, {"bahna", 3.555f},
        {"detas", 3.565f}, {"kubul", 3.572f}, {"tepik", 3.575f}, {"kilus", 3.582f},
        {"rajin", 3.592f}, {"abaka", 3.595f}, {"istri", 3.600f}, {"pulen", 3.605f},
        {"barut", 3.615f}, {"setal", 3.619f}
    };
}