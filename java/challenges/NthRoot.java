public class NthRoot {
    /*
    x_{k+1}=1/n ((n-1)x_k+A/x^{n-1})
    */

    static double nthPower(double x, int n){
        if(n<0) return 1;
        double result = 1;
        for(int i = 0; i < n; i++){
            result *=x;
        }
        return result;
    }
    static double TOLERANCE = 0.001;
    static double nthRoot(double x, int n){
        double guess = x;
        double diff = Double.MAX_VALUE;
        double result = 1;
        double oldResult = result;
        while (diff > TOLERANCE){
            result = (1/((double) n))*((n-1)*oldResult+guess/(nthPower(oldResult, n-1)));
            diff = result - oldResult;
            if(diff < 0) 
                diff *=-1;
            oldResult = result;
        }
        return result;
    }

    public static void main(String[] args){
        System.out.println(nthRoot(7, 3));
    }   
}
