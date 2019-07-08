// Challenge 3

// Create a program that will:

// Iterate up to 1 million (1,000,000 or 1.000.000 
// for those of you that use . instead of ,)
// Check each number to see if it is a palindrome
// Count how many palindromes there are between 1 and 1 million, 
// count how many of these palindromes are prime
// Store each number that is both a palindrome and a prime number 
// and output them at the end of the loop
// Program to try to reduce runtime efficiency 
// (hint: Your prime loop will likely take the most resources)

#include<iostream>
#include<string>
#include<vector>
#include<algorithm>

using namespace std;

bool is_prime(long number)
{
    if(number == 1) return false;
    bool is_prime = true;
    long divisor = 2;
    while(is_prime && divisor < int(number / 2) + 1)
    {
        is_prime = !(number % divisor == 0);
        divisor++;
    }
    return is_prime;
}

bool is_palindrome(long &number)
{
    string str = to_string(number);
    string copy(str);
    reverse(copy.begin(), copy.end());
    return !str.compare(copy);
}

vector<long> get_palindromes()
{
    vector<long> palindromes = {};
    for(long i = 1; i <= 1000000; i++)
    {
        if(is_palindrome(i))
            palindromes.push_back(i);
    }
    return palindromes;
}

vector<long> get_prime_palindromes(vector<long> &palindromes)
{
    vector<long> prime_palindromes = {};
    for(long palindrome : palindromes)
    {
        if(is_prime(palindrome))
            prime_palindromes.push_back(palindrome);
    }
    return prime_palindromes;
}

void display(vector<long> vec)
{
    for(long val : vec)
        cout << val << endl;
}

int main()
{
    vector<long> palindromes = get_palindromes();
    cout << "There are " << palindromes.size() << " palindromes from 1 to 1000000" << endl;
    vector<long> prime_palindromes = get_prime_palindromes(palindromes);
    cout << prime_palindromes.size() << " of those are prime" << endl;
    cout << "Here are all of them:" << endl;
    display(prime_palindromes);
    return 0;
}