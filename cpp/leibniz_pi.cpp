// Calculate an approximation of pi in cpp
// Using the Leibniz formula for pi
// 1-1/3+1/5-1/7+1/9 - ... = pi / 4

#include <iostream>o
using namespace std;

bool is_signal_plus(int idx)
{
    return (idx % 2 == 0);
}

int n_st_odd_number(int n)
{
    return 2 * n + 1;
}

double calculate_pi()
{
    double sum = 0.0;
    for(int i = 0; i < MAX_ITERATIONS; i++)
    {
        int next_odd_number = n_st_odd_number(i);
        if(is_signal_plus(i))
        {
            sum += 1 / ((double) next_odd_number);
        }
        else
        {
            sum -= 1 / ((double) next_odd_number);
        }
    }
    return 4 * sum;
}

int main()
{
    double pi_approx = calculate_pi();
    cout << "pi is approximately " << pi_approx << endl;
    return 0;
}