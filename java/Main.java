public class Main{

    public static void main(String[] args){
        Persistence per = new Persistence();
        int val = 341137;
        int persistence = per.persistence(val);
        System.out.println("The persistence of "+val +" is "+ persistence);
    }
}