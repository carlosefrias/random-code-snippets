public class SmallestSubstringAllChars {
    static boolean containsAlls(String str, char[] chars){
        if(str.length()!=chars.length)
            return false;
        for(char element : chars){
            if(!str.contains("" + element)){
                return false;
            }
        }
        return true;
    }

    static String getShortestUniqueSubString(char[] arr, String str){
        if(arr != null && str != null && str.length() >= arr.length){
            for(int start = 0; start <str.length(); start++){
                if(start + arr.length > str.length()) return "";
                String subString = str.substring(start, start + arr.length);
                if(containsAlls(subString, arr)){
                    return subString;
                }
            }
        }
        return "";
    }

    public static void main(String[] args){
        System.out.println(getShortestUniqueSubString(new char[]{'x','y','z'}, "yzyzyxzyx"));
    }

}
