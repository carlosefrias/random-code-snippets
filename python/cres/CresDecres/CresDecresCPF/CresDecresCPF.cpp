#include <iostream>
#include <cmath>
#include <iomanip>

int pow(int a, int n) 
{
    int r = 1;
    if (n > 0) 
    {
        for (int i = 0; i < n; i++) 
        {
            r *= a;
        }
    }
    return r;
}

bool igual(int a, int b) 
{
    return a == b;
}


int menor(int a, int b) 
{
    return a < b;
}

int* numeroEmLista(int n) 
{
    static int lista[6];
    for (int i = 5; i >= 0; i--) 
    {
        lista[i] = (n % pow(10, 6 - i)) / pow(10, 5 - i);
    }
    return lista;
}

int main()
{
    int c = 0, d = 0;

    for (int i = 123456; i <= 987654; ++i) 
    {
        auto lista = numeroEmLista(i);
        auto breakOut = false;
        for (int j = 0; j < 5; ++j) 
        {
            for (int k = j + 1;k < 6; ++k) 
            {
                if (igual(*(lista + j), *(lista + k))) 
                {
                    //Existem algarismos iguals, então saltar para o próximo número
                    breakOut = true;
                    break;
                };
            }
            if (breakOut) 
            { 
                break;
            }
        }
        if (breakOut) 
        {
            breakOut = false;
            continue;
        }
        int s = 0;
        for (int i = 0; i < 5; i++) 
        {
            //TODO com um pouco de jeito aqui dá para optimizar um pouco mais
            s += menor(*(lista + i), *(lista + i + 1));
        }
        if (s == 5) { c++; };
        if (s == 0) { d++; };
    }

    std::cout << "ordem crescente: " << c << std::endl;
    std::cout << "ordem decrescente: " << d << std::endl;
    std::cout << "total: " << c + d << std::endl;
    return 0;
}
