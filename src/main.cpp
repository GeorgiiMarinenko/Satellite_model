#include <iostream>
#include "TEuler.h"
#include "TRungeKutta.h"
#include "TSpaceCraft.h"
#include <fstream>
using namespace std;

int main(void)
{
	TVector Vec;
	Vec.x0 = 31200000;
	Vec.x1 = 31200000;
	Vec.x2 = 0;
	Vec.x3 = -1700;
	Vec.x4 = 1200;
	Vec.x5 = -1900;

	TDynamicModel* model = new TSpaceCraft();
	model->SetVector(Vec);
	TAbstractIntegrator * integTEuler = new TEuler(model);
	TAbstractIntegrator * integRungeKutta = new TRungeKutta(model);

	integRungeKutta->step = 1;
	integRungeKutta->start_time = 0;
	integRungeKutta->end_time = 750000;
	integRungeKutta->MoveTo();


	cout << "Спутник вышел на орбиту";
	return (0);
}
