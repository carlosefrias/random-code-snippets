#include <string>

class Person
{
    private:
        std::string firstName;
        std::string lastName;
        int age;

    public:
        Person(std::string first, std::string last, int yearsOld);
        Person() = default;
        std::string getName();
};
