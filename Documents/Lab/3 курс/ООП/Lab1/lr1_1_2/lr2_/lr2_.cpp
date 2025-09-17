#include "Exam.h"
#include <iostream>
#include <conio.h>
using namespace std;

void print(Exam ob)
{
    cout << "Друк з функції: ";
    ob.printExam();
}

int main()
{
    setlocale(0, "ukr");
    Exam ex1;             // об’єкт
    Exam* exPtr = new Exam; // покажчик на об’єкт
    Exam arr[2];          // масив об’єктів

    ex1.setExam("Andriy", "12.12.2025", 12);
    exPtr->setExam("Mark", "11.12.2025", 9);

    ex1.printExam();
    exPtr->printExam();

    
    void (Exam:: * ptrPrint)() = &Exam::printExam;
    cout << "Виклик через покажчик на метод класу:\n";
    (ex1.*ptrPrint)();

    
    print(ex1);


    exPtr->~Exam();
    ex1.~Exam();
    arr[0].~Exam();
    arr[1].~Exam();

    _getch();
    return 0;
}
