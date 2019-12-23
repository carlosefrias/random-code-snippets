#include <iostream>
#define NUMBER_COINS 8
using namespace std;

int coin_values[NUMBER_COINS] = {200, 100, 50, 20, 10, 5, 2, 1};
int number_coins[NUMBER_COINS] = {5, 10, 10, 20, 30, 40, 50, 50};

int get_avaliable_amount()
{
    auto sum = 0;
    for(auto i = 0; i < NUMBER_COINS; i++)
    {
        sum += coin_values[i] * number_coins[i];
    }
    return sum;
}


void get_change(int total_amount)
{
    // if get_available_amount() < total_amount:
    //     return "not enough money"
    if(get_avaliable_amount() < total_amount)
    {
        cout << "not enough money" << endl;
        return;
    }

    for(auto i = 0; i < NUMBER_COINS; i++)
    {
        auto value = coin_values[i];
        if(total_amount >= value)
        {
            auto q = total_amount / value;
            auto nr_coins = number_coins[i] >= q ? q: number_coins[i];
            total_amount -= nr_coins * value;
            cout << nr_coins << " coin(s) of " << value << " cents" << endl;
            number_coins[i] -= nr_coins;
        }
        if (total_amount == 0)
        {
            break;
        }
    }

    if (total_amount > 0)
    {
        cout << "not enough money" << endl;
    }
}

int main()
{
    get_change(1234);
    cout << get_avaliable_amount() << endl;    
}