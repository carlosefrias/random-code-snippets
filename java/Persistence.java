public class Persistence{

    private boolean is_one_digit(int number){
        return ("" + number).length() == 1;
    }

    private int product_digits(int number){
        String str = "" + number;
        int prd = 1;
        for (char c : str.toCharArray()) {
            prd *= Integer.parseInt("" + c);
        }
        return prd;
    }

    public int persistence(int number){
        int persistence = 0;
        while(!is_one_digit(number)){
            number = product_digits(number);
            System.out.println(number);
            persistence++;
        }
        return persistence;
    }
}
