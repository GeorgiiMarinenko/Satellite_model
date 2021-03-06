#ifndef TRUNGEKUTTA_H
#define TRUNGEKUTTA_H
#include "TAbstractIntegrator.h"

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

}

TVector TRungeKutta::MoveTo()
{
	TVector vec;
	return (vec);
}
#endif
