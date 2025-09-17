#include "Exam.h"
#include <iostream>
using namespace std;

Exam::Exam() : name(""), date(""), mark(0)
{
    cout << "Викликано конструктор без параметрів " << this << endl;
}

Exam::Exam(string n, string d, int m) : name(n), date(d), mark(m)
{
    cout << "Викликано конструктор з параметрами " << this << endl;
}

Exam::Exam(const Exam& other)
{
    name = other.name;
    date = other.date;
    mark = other.mark;
    cout << "Викликано конструктор копіювання " << this << endl;
}

Exam::~Exam()
{
    cout << "Викликано деструктор " << this << endl;
}

string Exam::getName() { return name; }
string Exam::getDate() { return date; }
int Exam::getMark() { return mark; }

void Exam::setName(string n) { name = n; }
void Exam::setDate(string d) { date = d; }
void Exam::setMark(int m) { mark = m; }

void Exam::printExam()
{
    cout << "Ім'я: " << name << "\tДата: " << date << "\tОцінка: " << mark << endl;
}

void Exam::setExam(string n, string d, int m)
{
    name = n;
    date = d;
    mark = m;
    cout << "Ім'я: " << name << "\tДата: " << date << "\tОцінка: " << mark << endl;
}
