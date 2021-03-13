#ifndef TEULER_H
#define TEULER_H
#include "TAbstractIntegrator.h"
#include <iostream>
#include <fstream>
using namespace std;

class TEuler:public TAbstractIntegrator
{
public:
	TEuler(TDynamicModel *Model);
	~TEuler();

	TVector	OneStep();
	TVector	MoveTo();
};

TEuler::TEuler(TDynamicModel *Model) : TAbstractIntegrator(Model)
{}

TEuler::~TEuler()
{}

TVector TEuler::OneStep()
{
	TVector NewVec;
	NewVec = Model->GetVector() + Model->RightParts()*step;
	Model->SetVector(NewVec);

	return (NewVec);
}

TVector TEuler::MoveTo()
{
	TVector Vec;
	ofstream out("result_TEuler.txt", ios::app);
	double Radius;
	if (!out.is_open())
	{
		cout << "Error" << endl;
		return (Vec);
	}
	for (double i = start_time; i < end_time; i += step)
	{
		Vec = OneStep();
		Radius = sqrt(pow(Vec.x0, 2) + pow(Vec.x1, 2)+ pow(Vec.x2,2));
		cout << Vec.x0 << " " << Vec.x1 << " " << Vec.x2 << " " << Vec.x3 << " "
		<< Vec.x4 << " " << Vec.x5 << endl;
		if (Radius <= 7000000)
		{
			cout << "Спутник упал на Землю" << endl;
			break;
		}
		if (Radius >= 50000000)
		{
			cout << "Спутник улетел с орбиты" << endl;
			break;
		}
		out << Vec.x0 << "|" << Vec.x1 << "|" << Vec.x2 << "|" << Vec.x3 << "|"
		<< Vec.x4 << "|" << Vec.x5 << endl;
	}
	return (Vec);
}
#endif
