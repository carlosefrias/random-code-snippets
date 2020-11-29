public class BracketMatcher {    
    /*
    input:  text = “(()”
    output: 1

    input:  text = “(())”
    output: 0

    input:  text = “())(”
    output: 2
    */
    static int bracketMatch(String text) {
        if(text == null || text.length() < 1 || text.length() > 5000) 
            return -1;
        int countOpen = 0;
        int countClose = 0;
        for(int i=0; i<text.length(); i++){
            if(text.charAt(i) == '('){
                countOpen++;
            }
            if(text.charAt(i) == ')'){
                if(countOpen > 0){
                    countOpen--;
                }
                else{
                    countClose++;
                }
            }
        }
        return countOpen+countClose;
    }

    public static void main(String[] args) {
        System.out.println(bracketMatch(")("));
    }

}