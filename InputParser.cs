namespace DracirAdvent2017
{
    public class InputParser
    {
        public static int[] StringToIntArray(string str){
            int[] arr = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = (int)char.GetNumericValue(str[i]);
            }
            return arr;
        }
    }
}