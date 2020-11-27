public class Main{
    public static void main(String[] args){
        
        Regex r = new Regex();

        // System.out.println(r.matchTemplateString("aba", "ab"));
        // System.out.println(r.matchTemplateString("aa", "a*"));
        // System.out.println(r.matchTemplateString("ab", ".*"));
        // System.out.println(r.matchTemplateString("ab", "."));
        System.out.println(r.matchTemplateString("aab", "c*a*b"));
        System.out.println(r.matchTemplateString("aaa", "a*."));

    }
}
