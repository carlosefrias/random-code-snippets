public class EncryptDecrypt {
    
    static String Encrypt(String word){
        //Convert letters to ASCII
        int[] wordInAscii = new int[word.length()];
        for(int i=0; i<word.length(); i++){
            wordInAscii[i]=(int) word.charAt(i);
        }

        //Add one to first letter
        wordInAscii[0]++;
        
        //Add first number to all letters
        for(int i=1; i<wordInAscii.length; i++){
            wordInAscii[i] += wordInAscii[i-1];
        }

        //Keep subtracting 26 until letters become from a-z
        for (int i=0; i<wordInAscii.length; i++) {
            while(wordInAscii[i] > 122){
                wordInAscii[i] -= 26;
            }
        }
        //convert back to string
        String ret = "";
        for (int element : wordInAscii) {
            ret += (char) element;
        }
        
        return ret;
    }
    
    static String Decrypt(String encrypted){
        int[] encryptedAscii = new int[encrypted.length()];

        for(int i=0; i<encrypted.length(); i++){
            encryptedAscii[i] = (int) encrypted.charAt(i);
        }
        
        for(int i=encryptedAscii.length - 1; i>=1; i--){
            encryptedAscii[i] -= encryptedAscii[i-1]; 
        }

        for(int i=0; i<encryptedAscii.length; i++){
            while(encryptedAscii[i]<97){
                encryptedAscii[i] +=26;
            }
        }

        encryptedAscii[0]--;
        String decrypted = "";
        for (int element : encryptedAscii) {
            decrypted += (char) element;
        }
        return decrypted;
    }

    public static void main(String[] args){
        String encrypted = Encrypt("maravilha");
        // Decrypt(encrypted);
        System.out.println(Decrypt(encrypted));
    }
}
