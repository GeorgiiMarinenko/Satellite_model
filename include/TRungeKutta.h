#ifndef TRUNGEKUTTA_H
#define TRUNGEKUTTA_H
#include "TAbstractIntegrator.h"
#include <iostream>
#include <fstream>
using namespace std;

class TRungeKutta:public TAbstractIntegrator
{
private:
	/* data */
public:
	TRungeKutta(TDynamicModel *Model);
	~TRungeKutta();

	TVector	OneStep();
	TVector	MoveTo();
};

TRungeKutta::TRungeKutta(TDynamicModel *Model) : TAbstractIntegrator(Model)
{
}

TRungeKutta::~TRungeKutta()
{
}

TVector TRungeKutta::OneStep()
{
	TVector NewVec;
	TVector K1;
	TVector K2;
	TVector K3;
	TVector K4;

	K1 = Model->RightParts();
	K2 = Model->RightParts() + K1 * (step * 0.5);
	K3 = Model->RightParts() + K2 * (step * 0.5);
	K4 = Model->RightParts() + K3 * step;

	NewVec = Model->GetVector() + (K1 + K2 + K3 + K4) * (step/6);
	Model->SetVector(NewVec);
	return (NewVec);
}

TVector TRungeKutta::MoveTo()
{
	TVector Vec;
	ofstream out("result_TRungeKutta.txt", ios::app);
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
