public class Regex {

    /*
    White a function that takes two strings s and p and returns a boolean denoting weather s matches p pattern

    p can be any number of the following:
    a-z which stands for itself
    . which stands for any character
    * which must follow another single character and stands 0 or more occurences of that character
    
    s="aba" p="ab"  => false
    aa      a*      => true   
    ab      .*      => true
    ab      .       => false
    aab     a*a*b   => true
    aaa     a*.     => true
    */

    public boolean matchTemplateString(String s, String p){
        for(int i = 0; i < s.length(); ++i){
            if(s.length() != p.length() && !p.contains("*"))
                return false;
            if(p.charAt(i)=='.') continue;
            if(p.charAt(i)=='*'){
                char letter=s.charAt(i);
                do{
                    if(i+1<s.length())
                        i++;
                    else
                        break;
                }while(s.charAt(i)==letter && i <s.length());
            }
            if(s.charAt(i) != p.charAt(i) && p.charAt(i) != '*')
                return false;
        }
        return true;
    }
}
