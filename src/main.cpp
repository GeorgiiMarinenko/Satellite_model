#include <iostream>
#include "TEuler.h"
#include "TSpaceCraft.h"
#include <fstream>
using namespace std;

int main(void)
{
	ofstream out("result.txt", ios::app);
	TVector Vec;
	Vec.x0 = 1000000;
	Vec.x1 = 1000000;
	Vec.x2 = 0;
	Vec.x3 = 2900;
	Vec.x4 = -1400;
	Vec.x5 = 800;

	TDynamicModel* model = new TSpaceCraft();
	model->SetVector(Vec);
	TAbstractIntegrator * integ = new TEuler(model);
	integ->step = 1;
	// Vec = integ->OneStep();
	int i = 0;
	while ((i < 100) && (out.is_open()))
	{
		out << Vec.x0 << " " << Vec.x1 << " " << Vec.x2 << " " << Vec.x3 << " "
		<< Vec.x4 << " " << Vec.x5 << endl;
		Vec = integ->OneStep();
		i++;
	}
	out.close();
	return (0);
}
