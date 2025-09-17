#pragma once
#include <string>
using namespace std;

class Exam
{
public:
    string name;   // ім'я студента
    string date;   // дата
    int mark;      // оцінка

public:
    Exam();
    Exam(string n, string d, int m);
    Exam(const Exam& other);
    ~Exam();

    string getName();
    string getDate();
    int getMark();

    void setExam(string n, string d, int m);
    void setName(string n);
    void setDate(string d);
    void setMark(int m);

    void printExam();
};
